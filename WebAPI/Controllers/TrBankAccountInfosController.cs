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
    public class TrBankAccountInfosController : ControllerBase
    {
        ITrBankAccountInfoService _trBankAccountInfoService;

        public TrBankAccountInfosController(ITrBankAccountInfoService trbankAccountInfoService)
        {
            _trBankAccountInfoService = trbankAccountInfoService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var resutl = _trBankAccountInfoService.GetAll();
            if (resutl.Success)
            {
                return Ok(resutl);
            }
            return BadRequest(resutl);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _trBankAccountInfoService.GetTrBankAccountInfoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TrBankAccountInfo trBank)
        {
            var result = _trBankAccountInfoService.Add(trBank);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TrBankAccountInfo trBank)
        {
            var result = _trBankAccountInfoService.Update(trBank);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TrBankAccountInfo trBank)
        {
            var result = _trBankAccountInfoService.Delete(trBank);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
