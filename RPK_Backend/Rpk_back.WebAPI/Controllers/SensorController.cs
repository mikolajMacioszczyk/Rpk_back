using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rpk_back.Application.Service;
using Rpk_back.Application.Service.Interface;

namespace Rpk_back.WebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class SensorController : Controller
    {
        private readonly ISensorService _sensorService;

        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSensorById([FromRoute] Guid guid)
        {

        }

        [HttpGet("{groupGuid}")]
        public async Task<IActionResult> GetSensorsByGroupId([FromRoute] Guid groupGuid)
        {

        }

        [HttpGet("{localization}")]
        public async Task<IActionResult> GetSensorsByLocalization([FromQuery] string localization)
        {

        }
    }
}