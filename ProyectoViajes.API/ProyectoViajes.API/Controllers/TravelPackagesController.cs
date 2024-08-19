using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.TravelPackages;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/travel_packages")]
    public class TravelPackagesController : ControllerBase
    {
        private readonly ITravelPackagesService _travelPackagesService;

        public TravelPackagesController(ITravelPackagesService travelPackagesService)
        {
            _travelPackagesService = travelPackagesService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<TravelPackageDto>>>> GetAll(string searchTerm = "", int page = 1)
        {
            var response = await _travelPackagesService.GetTravelPackagesListAsync(searchTerm, page);
            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<TravelPackageDto>>>> Get(Guid id){
            var response = await _travelPackagesService.GetTravelPackageByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear un paquete de viaje
        [HttpPost]
        public async Task<ActionResult<ResponseDto<List<TravelPackageDto>>>> Create(TravelPackageCreateDto dto){
            var response = await _travelPackagesService.CreateTravelPackageAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar un paquete de viaje
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<TravelPackageDto>>>> Edit(TravelPackageEditDto dto, Guid id){
            var response = await _travelPackagesService.EditTravelPackageAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar un paquete de viaje
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<List<TravelPackageDto>>>> Delete(Guid id){
            var response = await _travelPackagesService.DeleteTravelPackageAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}