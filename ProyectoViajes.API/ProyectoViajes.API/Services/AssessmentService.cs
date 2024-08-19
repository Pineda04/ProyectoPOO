using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;
        private readonly int PAGE_SIZE;

        public AssessmentService(ProyectoViajesContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
        }

        public async Task<ResponseDto<PaginationDto<List<AssessmentDto>>>> GetAssessmentsListAsync(int page = 1)
        {
            int startIndex = (page - 1) * PAGE_SIZE;

            var assessmentsQuery = _context.Assessments.AsQueryable();

            int totalAssessments = await assessmentsQuery.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalAssessments / PAGE_SIZE);

            var assessments = await assessmentsQuery
                .OrderByDescending(a => a.RatingDate)
                .Skip(startIndex)
                .Take(PAGE_SIZE)
                .ToListAsync();

            var assessmentDtos = _mapper.Map<List<AssessmentDto>>(assessments);

            return new ResponseDto<PaginationDto<List<AssessmentDto>>>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = new PaginationDto<List<AssessmentDto>>
                {
                    CurrentPage = page,
                    PageSize = PAGE_SIZE,
                    TotalItems = totalAssessments,
                    Items = assessmentDtos,
                    HasPreviousPage = page > 1,
                    HasNextPage = page < totalPages
                }
            };
        }

        public async Task<ResponseDto<AssessmentDto>> GetAssessmentByIdAsync(Guid id)
        {
            var assessmentEntity = await _context.Assessments.FirstOrDefaultAsync(a => a.Id == id);

            if(assessmentEntity == null){
                return new ResponseDto<AssessmentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var assessmentDto = _mapper.Map<AssessmentDto>(assessmentEntity);

            return new ResponseDto<AssessmentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = assessmentDto
            };
        }

        public async Task<ResponseDto<AssessmentDto>> CreateAssessmentAsync(AssessmentCreateDto dto)
        {
            var assessmentEntity = _mapper.Map<AssessmentEntity>(dto);

            _context.Assessments.Add(assessmentEntity);

            await _context.SaveChangesAsync();

            var assessmentDto = _mapper.Map<AssessmentDto>(assessmentEntity);

            return new ResponseDto<AssessmentDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = assessmentDto
            };
        }

        public async Task<ResponseDto<AssessmentDto>> EditAssessmentAsync(AssessmentEditDto dto, Guid id)
        {
            var assessmentEntity = await _context.Assessments.FirstOrDefaultAsync(a => a.Id == id);

            if(assessmentEntity == null){
                return new ResponseDto<AssessmentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, assessmentEntity);

            _context.Assessments.Update(assessmentEntity);

            await _context.SaveChangesAsync();

            var assessmentDto = _mapper.Map<AssessmentDto>(assessmentEntity);

            return new ResponseDto<AssessmentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = assessmentDto
            };
        }

        public async Task<ResponseDto<AssessmentDto>> DeleteAssessmentAsync(Guid id)
        {
            var assessmentEntity = await _context.Assessments.FirstOrDefaultAsync(a => a.Id == id);

            if(assessmentEntity == null){
                return new ResponseDto<AssessmentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Assessments.Remove(assessmentEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<AssessmentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}