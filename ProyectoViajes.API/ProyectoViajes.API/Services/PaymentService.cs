using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Dtos.Payments;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<PaymentDto>>> GetPaymentsListAsync()
        {
            var payments = await _context.Payments
                .Select(p => new PaymentDto
                {
                    PaymentId = p.PaymentId,
                    ReservationId = p.ReservationId,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                    Status = p.Status
                }).ToListAsync();

            return new ResponseDto<List<PaymentDto>>
            {
                StatusCode = 200,
                Status = true,
                Data = payments,
                Message = "Success"
            };
        }

        public async Task<ResponseDto<PaymentDto>> GetPaymentByIdAsync(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return new ResponseDto<PaymentDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Payment not found"
                };
            }

            var paymentDto = new PaymentDto
            {
                PaymentId = payment.PaymentId,
                ReservationId = payment.ReservationId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status
            };

            return new ResponseDto<PaymentDto>
            {
                StatusCode = 200,
                Status = true,
                Data = paymentDto,
                Message = "Success"
            };
        }

        public async Task<ResponseDto<PaymentDto>> CreateAsync(CreatePaymentDto dto)
        {
            var payment = new PaymentEntity
            {
                PaymentId = Guid.NewGuid(),
                ReservationId = dto.ReservationId,
                Amount = dto.Amount,
                PaymentDate = dto.PaymentDate,
                PaymentMethod = dto.PaymentMethod,
                Status = dto.Status
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            var paymentDto = new PaymentDto
            {
                PaymentId = payment.PaymentId,
                ReservationId = payment.ReservationId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status
            };

            return new ResponseDto<PaymentDto>
            {
                StatusCode = 201,
                Status = true,
                Data = paymentDto,
                Message = "Payment created successfully"
            };
        }

        public async Task<ResponseDto<PaymentDto>> EditAsync(EditPaymentDto dto, Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return new ResponseDto<PaymentDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Payment not found"
                };
            }

            payment.ReservationId = dto.ReservationId;
            payment.Amount = dto.Amount;
            payment.PaymentDate = dto.PaymentDate;
            payment.PaymentMethod = dto.PaymentMethod;
            payment.Status = dto.Status;

            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();

            var paymentDto = new PaymentDto
            {
                PaymentId = payment.PaymentId,
                ReservationId = payment.ReservationId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status
            };

            return new ResponseDto<PaymentDto>
            {
                StatusCode = 200,
                Status = true,
                Data = paymentDto,
                Message = "Payment updated successfully"
            };
        }

        public async Task<ResponseDto<PaymentDto>> DeleteAsync(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return new ResponseDto<PaymentDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Payment not found"
                };
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return new ResponseDto<PaymentDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Payment deleted successfully"
            };
        }
    }
}
