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
    public class CongressesController : ControllerBase
    {
        private ICongressService _congressService;

        public CongressesController(ICongressService congressService)
        {
            _congressService = congressService;
        }

        [HttpGet("getcongressdetails")]
        public IActionResult GetDetails(int congressId)
        {
            var result = _congressService.GetCongressDetails(congressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _congressService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _congressService.GetCongressById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult Add(Congress congress)
        {
            var result = _congressService.Add(congress);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("delete")]
        public IActionResult Delete(Congress congress)
        {
            var result = _congressService.Delete(congress);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        public IActionResult Update(Congress congress)
        {
            var result = _congressService.Update(congress);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
