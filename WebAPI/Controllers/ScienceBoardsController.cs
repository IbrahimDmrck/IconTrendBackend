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
    public class ScienceBoardsController : ControllerBase
    {
        private readonly IScienceBoardService _scienceBoardService;

        public ScienceBoardsController(IScienceBoardService scienceBoardService)
        {
            _scienceBoardService = scienceBoardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _scienceBoardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _scienceBoardService.GetScienceBoardById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult Add(ScienceBoard scienceBoard)
        {
            var result = _scienceBoardService.Add(scienceBoard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("delete")]
        public IActionResult Delete(ScienceBoard scienceBoard)
        {
            var result = _scienceBoardService.Delete(scienceBoard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        public IActionResult Update(ScienceBoard scienceBoard)
        {
            var result = _scienceBoardService.Update(scienceBoard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
