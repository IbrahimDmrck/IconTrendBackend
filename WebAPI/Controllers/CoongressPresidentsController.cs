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
    public class CoongressPresidentsController : ControllerBase
    {
        private readonly ICongressPresidentService _congressPresidentService;

        public CoongressPresidentsController(ICongressPresidentService congressPresidentService)
        {
            _congressPresidentService = congressPresidentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _congressPresidentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _congressPresidentService.GetCongressPresidentById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult Add(CongressPresident congressPresident)
        {
            var result = _congressPresidentService.Add(congressPresident);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("delete")]
        public IActionResult Delete(CongressPresident congressPresident)
        {
            var result = _congressPresidentService.Delete(congressPresident);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        public IActionResult Update(CongressPresident congressPresident)
        {
            var result = _congressPresidentService.Update(congressPresident);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
