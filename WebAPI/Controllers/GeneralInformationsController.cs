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
    public class GeneralInformationsController : ControllerBase
    {
        IGeneralInformationService _generalInformationService;

        public GeneralInformationsController(IGeneralInformationService generalInformationService)
        {
            _generalInformationService = generalInformationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _generalInformationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _generalInformationService.GetGeneralInfoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(GeneralInformation generalInformation)
        {
            var result = _generalInformationService.Add(generalInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(GeneralInformation generalInformation)
        {
            var result = _generalInformationService.Update(generalInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(GeneralInformation generalInformation)
        {
            var result = _generalInformationService.Delete(generalInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
