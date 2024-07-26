using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Payments;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> GetAll()
        {
            var response = await _paymentService.GetPaymentsListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PaymentDto>>> Get(Guid id)
        {
            var response = await _paymentService.GetPaymentByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<PaymentDto>>> Create(CreatePaymentDto dto)
        {
            var response = await _paymentService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<PaymentDto>>> Edit(EditPaymentDto dto, Guid id)
        {
            var response = await _paymentService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<PaymentDto>>> Delete(Guid id)
        {
            var response = await _paymentService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}

