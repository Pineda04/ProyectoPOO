﻿using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Payments;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IPaymentService
    {

        Task<ResponseDto<List<PaymentDto>>> GetPaymentsListAsync();

        Task<ResponseDto<PaymentDto>> GetPaymentByIdAsync(Guid id);

        Task<ResponseDto<PaymentDto>> CreateAsync(CreatePaymentDto dto);

        Task<ResponseDto<PaymentDto>> EditAsync(EditPaymentDto dto, Guid id);

        Task<ResponseDto<PaymentDto>> DeleteAsync(Guid id);

    }
}
