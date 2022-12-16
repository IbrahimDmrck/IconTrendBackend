using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongressImagesesController : ControllerBase
    {
        private readonly ICongressImageService _congressImageService;

        public CongressImagesesController(ICongressImageService congressImageService)
        {
            _congressImageService = congressImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _congressImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycongressid")]
        public IActionResult GetAllByCongressId(int congressId)
        {
            var result = _congressImageService.GetCongressImage(congressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       
        [HttpPost("add")]
        public IActionResult Add([FromForm] int congressId,[FromForm] IFormFile congressImage)
        {
            var result = _congressImageService.Add(congressImage, congressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    

        [HttpPost("delete")]
        public IActionResult Delete(CongressImage congressImage)
        {
            var result = _congressImageService.Delete(congressImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

     
        [HttpPost("update")]
        public IActionResult Update([FromForm] CongressImage congressImage, [FromForm] IFormFile imageFile)
        {
            var result = _congressImageService.Update(congressImage, imageFile);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
