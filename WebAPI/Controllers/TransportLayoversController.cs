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
    public class TransportLayoversController : ControllerBase
    {
        private ITransportLayoverService _transportLayoverService;

        public TransportLayoversController(ITransportLayoverService transportLayoverService)
        {
            _transportLayoverService = transportLayoverService;
        }

        [HttpGet("gettransportlayoverdetails")]
        public IActionResult GetDetails(int congressId)
        {
            var result = _transportLayoverService.GetTransportDetails(congressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transportLayoverService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _transportLayoverService.GetTransportLayoverById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult Add(TransportLayover transportLayover)
        {
            var result = _transportLayoverService.Add(transportLayover);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("delete")]
        public IActionResult Delete(TransportLayover transportLayover)
        {
            var result = _transportLayoverService.Delete(transportLayover);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        public IActionResult Update(TransportLayover transportLayover)
        {
            var result = _transportLayoverService.Update(transportLayover);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
