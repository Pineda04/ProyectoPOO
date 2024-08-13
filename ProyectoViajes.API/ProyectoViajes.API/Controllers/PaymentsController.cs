using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Payments;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> GetAll(){
            var response = await _paymentService.GetPaymentsListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Traer por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> Get(Guid id){
            var response = await _paymentService.GetPaymentByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear un pago
        [HttpPost]
        public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> Create(PaymentCreateDto dto){
            var response = await _paymentService.CreatePaymentAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar un pago
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> Edit(PaymentEditDto dto, Guid id){
            var response = await _paymentService.EditPaymentAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar un pago
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> Delete(Guid id){
            var response = await _paymentService.DeletePaymentAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}