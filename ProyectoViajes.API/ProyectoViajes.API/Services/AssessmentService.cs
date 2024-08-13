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

        public AssessmentService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<AssessmentDto>>> GetAssessmentsListAsync()
        {
            var assessmentEntity = await _context.Assessments.ToListAsync();

            var assessmentDto = _mapper.Map<List<AssessmentDto>>(assessmentEntity);

            return new ResponseDto<List<AssessmentDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = assessmentDto
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