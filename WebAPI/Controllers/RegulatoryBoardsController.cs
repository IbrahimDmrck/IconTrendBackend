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
    public class RegulatoryBoardsController : ControllerBase
    {
        private readonly IRegulatoryBoardService _regulatoryBoardService;

        public RegulatoryBoardsController(IRegulatoryBoardService regulatoryBoardService)
        {
            _regulatoryBoardService = regulatoryBoardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _regulatoryBoardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _regulatoryBoardService.GetRegulatoryBoardById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

     
        [HttpPost("add")]
        public IActionResult Add(RegulatoryBoard regulatoryBoard)
        {
            var result = _regulatoryBoardService.Add(regulatoryBoard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);     
        }

     
        [HttpPost("delete")]
        public IActionResult Delete(RegulatoryBoard regulatoryBoard)
        {
            var result = _regulatoryBoardService.Delete(regulatoryBoard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        public IActionResult Update(RegulatoryBoard regulatoryBoard)
        {
            var result = _regulatoryBoardService.Update(regulatoryBoard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
