using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Dtos.Payments;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : Controller
    {
 
         
            private readonly IPaymentService _paymentService;
            public PaymentController(IPaymentService categoriesService)
            {

                this._paymentService = categoriesService;
            }

            [HttpGet]

            public async Task<ActionResult<ResponseDto<List<PaymentDto>>>> GetAll()
            {

                var response = await _paymentService.GetCategoriesListAsync();
                return StatusCode(response.StatusCode, response);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult> Get(Guid id)
            {

                var response = await _paymentService.GetCategoriesByUdAsync(id);


                return StatusCode(response.StatusCode, response);
                 

            }

            [HttpPost]

            public async Task<ActionResult<ResponseDto<PaymentDto>>> Create(CreatePaymentDto dto)
            {

                

                await _paymentService.CreateAsync(dto);

                

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

