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
    public class KongresController : ControllerBase
    {
        IKongreService _kongreService;

        public KongresController(IKongreService kongreService)
        {
            _kongreService = kongreService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _kongreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _kongreService.GetKongreById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Kongre kongre)
        {
            var result = _kongreService.Add(kongre);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Kongre kongre)
        {
            var result = _kongreService.Delete(kongre);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getkongresdetails")]
        public IActionResult GetDetails(int kongreId)
        {
            var result = _kongreService.GetKongreDetails(kongreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Kongre kongre)
        {
            var result = _kongreService.Update(kongre);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
