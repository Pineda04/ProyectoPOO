using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Payments;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;
        public PaymentService(ProyectoViajesContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseDto<List<PaymentDto>>> GetPaymentsListAsync()
        {
            var paymentsEntity = await _context.Payments.ToListAsync();

            var paymentsDto = _mapper.Map<List<PaymentDto>>(paymentsEntity);

            return new ResponseDto<List<PaymentDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = paymentsDto
            };
        }

        public async Task<ResponseDto<PaymentDto>> GetPaymentByIdAsync(Guid id)
        {
            var paymentsEntity = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

            if(paymentsEntity == null){
                return new ResponseDto<PaymentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var paymentsDto = _mapper.Map<PaymentDto>(paymentsEntity);

            return new ResponseDto<PaymentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = paymentsDto
            };
        }

        public async Task<ResponseDto<PaymentDto>> CreatePaymentAsync(PaymentCreateDto dto)
        {
            var paymentsEntity = _mapper.Map<PaymentEntity>(dto);

            _context.Payments.Add(paymentsEntity);

            await _context.SaveChangesAsync();

            var paymentsDto = _mapper.Map<PaymentDto>(paymentsEntity);

            return new ResponseDto<PaymentDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = paymentsDto
            };
        }

        public async Task<ResponseDto<PaymentDto>> EditPaymentAsync(PaymentEditDto dto, Guid id)
        {
            var paymentsEntity = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

            if(paymentsEntity == null){
                return new ResponseDto<PaymentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, paymentsEntity);

            _context.Payments.Update(paymentsEntity);

            await _context.SaveChangesAsync();

            var paymentsDto = _mapper.Map<PaymentDto>(paymentsEntity);

            return new ResponseDto<PaymentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = paymentsDto
            };
        }

        public async Task<ResponseDto<PaymentDto>> DeletePaymentAsync(Guid id)
        {
            var paymentsEntity = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

            if(paymentsEntity == null){
                return new ResponseDto<PaymentDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Payments.Remove(paymentsEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<PaymentDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}