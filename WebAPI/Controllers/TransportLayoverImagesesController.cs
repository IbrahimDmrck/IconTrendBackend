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
    public class TransportLayoverImagesesController : ControllerBase
    {
        private readonly ITransportLayoverImageService _transportLayoverImageService;

        public TransportLayoverImagesesController(ITransportLayoverImageService transportLayoverImageService)
        {
            _transportLayoverImageService = transportLayoverImageService;
        }

        [HttpGet("getall")]
        public IActionResult getAll()
        {
            var result = _transportLayoverImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbytransportlayoverid")]
        public IActionResult GetAllByCongressId(int transportId)
        {
            var result = _transportLayoverImageService.GetTransportImage(transportId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] int transportId, [FromForm] IFormFile transportImage)
        {
            var result = _transportLayoverImageService.Add(transportImage, transportId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TransportLayoverImage transportLayoverImage)
        {
            var result = _transportLayoverImageService.Delete(transportLayoverImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] TransportLayoverImage transportLayoverImage, [FromForm] IFormFile imageFile)
        {
            var result = _transportLayoverImageService.Update(transportLayoverImage, imageFile);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
