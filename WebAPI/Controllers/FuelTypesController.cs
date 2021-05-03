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
    public class FuelTypesController : ControllerBase
    {
        IFuelTypeService _fuelTypeService;

        public FuelTypesController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fuelTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
