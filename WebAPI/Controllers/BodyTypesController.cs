using Business.Abstract;
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
    public class BodyTypesController : ControllerBase
    {
        IBodyTypeService _bodyTypeService;

        public BodyTypesController(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bodyTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
