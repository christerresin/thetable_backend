using Microsoft.AspNetCore.Mvc;

namespace TheTableBackend.Controllers
{
    [ApiController]
    // The controller "name" is injected from the Controllers class name, Appetizer (from this AppetizerController.cs file)
    [Route("api/[controller]")]
    public class AppetizerController : ControllerBase
    {

        private readonly IAppetizerService _appetizerService;

        public AppetizerController(IAppetizerService appetizerService)
        {
            _appetizerService = appetizerService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetMealDto>>>> GetAllAppetizers()
        {

            return Ok(await _appetizerService.GetAllAppetizers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMealDto>>> GetAppetizerById(int id)
        {
            return Ok(await _appetizerService.GetAppetizerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetMealDto>>> AddNewAppetizer(AddMealDto newAppetizer)
        {
            return Ok(await _appetizerService.AddNewAppetizer(newAppetizer));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetMealDto>>> UpdateAppetizer(UpdateMealDto updatedAppetizer)
        {
            var serviceResponse = await _appetizerService.UpdateAppetizer(updatedAppetizer);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetMealDto>>> DeleteAppetizer(int id)
        {
            var serviceResponse = await _appetizerService.DeleteAppetizer(id);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
