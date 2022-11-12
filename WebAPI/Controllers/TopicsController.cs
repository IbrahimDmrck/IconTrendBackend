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
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _topicService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_topicService.GetTopicById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

      
        [HttpPost("add")]
        public IActionResult Add(Topic topic)
        {
            var result = _topicService.Add(topic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

  
        [HttpPost("update")]
        public IActionResult Update(Topic topic)
        {
            var result = _topicService.Update(topic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost("delete")]
        public IActionResult Delete(Topic topic)
        {
            var result = _topicService.Delete(topic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
