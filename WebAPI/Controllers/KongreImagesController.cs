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
    public class KongreImagesController : ControllerBase
    {
        IKongreImageService _kongreImageService;

        public KongreImagesController(IKongreImageService kongreImageService)
        {
            _kongreImageService = kongreImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _kongreImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbykongreid")]
        public IActionResult GetAllByAnnounceId(int kongreId)
        {
            var result = _kongreImageService.GetKongreImage(kongreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int kongreId, [FromForm] IFormFile kongreImage)
        {
            var result = _kongreImageService.Add(kongreImage, kongreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(KongreImage kongreImage)
        {
            var result = _kongreImageService.Delete(kongreImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] KongreImage kongreImage, [FromForm] IFormFile imageFile)
        {
            var result = _kongreImageService.Update(kongreImage, imageFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
