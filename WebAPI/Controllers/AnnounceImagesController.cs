using Business.Abstract;
using Entities.Concrete;
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
    public class AnnounceImagesController : ControllerBase
    {
        private readonly IAnnounceImageService _announceImageService;

        public AnnounceImagesController(IAnnounceImageService announceImageService)
        {
            _announceImageService = announceImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _announceImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyannounceid")]
        public IActionResult GetAllByAnnounceId(int announceId)
        {
            var result = _announceImageService.GetAnnounceImage(announceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int announceId, [FromForm] IFormFile announceImage)
        {
            var result = _announceImageService.Add(announceImage, announceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AnnounceImage announceImage)
        {
            var result = _announceImageService.Delete(announceImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] AnnounceImage announceImage, [FromForm] IFormFile imageFile)
        {
            var result = _announceImageService.Update(announceImage, imageFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
