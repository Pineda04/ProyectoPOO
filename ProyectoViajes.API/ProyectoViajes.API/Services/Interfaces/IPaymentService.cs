using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Payments;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<ResponseDto<List<PaymentDto>>> GetPaymentsListAsync();

        Task<ResponseDto<PaymentDto>> GetPaymentByIdAsync(Guid id);

        Task<ResponseDto<PaymentDto>> CreatePaymentAsync(PaymentCreateDto dto);

        Task<ResponseDto<PaymentDto>> EditPaymentAsync(PaymentEditDto dto, Guid id);

        Task<ResponseDto<PaymentDto>> DeletePaymentAsync(Guid id);
    }
}