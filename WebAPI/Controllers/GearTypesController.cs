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
    public class GearTypesController : ControllerBase
    {
        IGearTypeService _gearTypeService;

        public GearTypesController(IGearTypeService gearTypeService)
        {
            _gearTypeService = gearTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _gearTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
