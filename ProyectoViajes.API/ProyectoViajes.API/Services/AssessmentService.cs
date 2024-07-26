using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Dtos.Common;

namespace ProyectoViajes.API.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly ProyectoViajesContext _context;

        public AssessmentService(ProyectoViajesContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<AssessmentDto>>> GetAssessmentsAsync()
        {
            var assessments = await _context.Assessments.ToListAsync();
            var assessmentDtos = assessments.Select(a => new AssessmentDto
            {
                Id = a.Id,
                UserId = a.UserId,
                PackageId = a.PackageId,
                Rating = a.Rating,
                Comment = a.Comment,
                Date = a.Date
            }).ToList();

            return new ResponseDto<List<AssessmentDto>>
            {
                StatusCode = 200,
                Status = true,  
                Data = assessmentDtos,
                Message = "Assessments retrieved successfully",
              
            };
        }

        public async Task<ResponseDto<AssessmentDto>> GetAssessmentByIdAsync(Guid id)
        {
            var assessment = await _context.Assessments.FindAsync(id);

            if (assessment == null)
            {
                return new ResponseDto<AssessmentDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Data = null,
                    Message = "Assessment not found",
                 
                };
            }

            var assessmentDto = new AssessmentDto
            {
                Id = assessment.Id,
                UserId = assessment.UserId,
                PackageId = assessment.PackageId,
                Rating = assessment.Rating,
                Comment = assessment.Comment,
                Date = assessment.Date
            };

            return new ResponseDto<AssessmentDto>
            {
                StatusCode = 200,
                Status = true,
                Data = assessmentDto,
                Message = "Assessment retrieved successfully",
               
            };
        }

        public async Task<ResponseDto<AssessmentDto>> CreateAsync(CreateAssessmentDto dto)
        {
            var assessment = new AssessmentEntity
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                PackageId = dto.PackageId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                Date = dto.Date
            };

            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            var assessmentDto = new AssessmentDto
            {
                Id = assessment.Id,
                UserId = assessment.UserId,
                PackageId = assessment.PackageId,
                Rating = assessment.Rating,
                Comment = assessment.Comment,
                Date = assessment.Date
            };

            return new ResponseDto<AssessmentDto>
            {
                StatusCode = 201,
                Status = true,
                Data = assessmentDto,
                Message = "Assessment created successfully",
                
            };
        }

        public async Task<ResponseDto<AssessmentDto>> EditAsync(EditAssessmentDto dto, Guid id)
        {
            var assessment = await _context.Assessments.FindAsync(id);

            if (assessment == null)
            {
                return new ResponseDto<AssessmentDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Data = null,
                    Message = "Assessment not found",
                    
                };
            }

            assessment.Rating = dto.Rating;
            assessment.Comment = dto.Comment;
            assessment.Date = dto.Date;

            _context.Assessments.Update(assessment);
            await _context.SaveChangesAsync();

            var assessmentDto = new AssessmentDto
            {
                Id = assessment.Id,
                UserId = assessment.UserId,
                PackageId = assessment.PackageId,
                Rating = assessment.Rating,
                Comment = assessment.Comment,
                Date = assessment.Date
            };

            return new ResponseDto<AssessmentDto>
            {
                StatusCode = 200,
                Status = true,
                Data = assessmentDto,
                Message = "Assessment updated successfully",
               
            };
        }

        public async Task<ResponseDto<AssessmentDto>> DeleteAsync(Guid id)
        {
            var assessment = await _context.Assessments.FindAsync(id);

            if (assessment == null)
            {
                return new ResponseDto<AssessmentDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Data = null,
                    Message = "Assessment not found",
                   
                };
            }

            _context.Assessments.Remove(assessment);
            await _context.SaveChangesAsync();

            return new ResponseDto<AssessmentDto>
            {
                StatusCode = 200,
                Status = true,
                Data = null,
                Message = "Assessment deleted successfully",
               
            };
        }
    }
}
