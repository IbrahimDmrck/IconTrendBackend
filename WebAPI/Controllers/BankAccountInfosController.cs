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
    public class BankAccountInfosController : ControllerBase
    {
        IBankAccountInfoService _bankAccountInfoService;

        public BankAccountInfosController(IBankAccountInfoService bankAccountInfoService)
        {
            _bankAccountInfoService = bankAccountInfoService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var resutl = _bankAccountInfoService.GetAll();
            if (resutl.Success)
            {
                return Ok(resutl);
            }
            return BadRequest(resutl);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bankAccountInfoService.GetBankAccountInfoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(BankAccountInfo accountInfo)
        {
            var result = _bankAccountInfoService.Add(accountInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BankAccountInfo accountInfo)
        {
            var result = _bankAccountInfoService.Update(accountInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BankAccountInfo accountInfo)
        {
            var result = _bankAccountInfoService.Delete(accountInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
