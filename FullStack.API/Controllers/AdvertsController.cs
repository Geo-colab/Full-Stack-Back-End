using FullStack.API.Helpers;
using FullStack.API.Services;
using FullStack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{   

    [ApiController]
    [Route ("[controller]")]
    public class AdvertsController : ControllerBase
    {
        private IAdvertService _advertService; 

        public AdvertsController(
            IAdvertService advertService
            )
        {
            _advertService = advertService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var adverts = _advertService.GetAll();
            return Ok(adverts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var advert = _advertService.GetById(id);
            return Ok(advert);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetAdvertsByUserId(int id)
        {
            var adverts = _advertService.GetAdvertsByUserId(id);
            return Ok(adverts);
        }

        [HttpGet("provinces")]
        public IActionResult GetAllProvinces()
        {
            var provinces = _advertService.GetAllProvinces();
            return Ok(provinces);
        }

        [HttpGet("provinces/cities/{id}")]
        public IActionResult GetCitiesByProvinceId(int id)
        {
            var cities = _advertService.GetCitiesByProvinceId(id);
            return Ok(cities);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,  AdvertModel model)
        {
            try
            {
                // update user 
                _advertService.Update(model);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public IActionResult CreateAdvert([FromBody] CreateAdvertModel model)
        {
            try
            {
                // create user
                var createdUserModel = _advertService.CreateAdvert(model);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

