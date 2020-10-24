﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rpk_back.Application.Service;
using Rpk_back.Application.Service.Interface;
using Rpk_back.Domain.Enums;

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

        [HttpGet("{guid}/{dateStart}/{dateEnd}")]
        public async Task<IActionResult> GetSensorById([FromRoute] Guid guid, DateTime dateStart, DateTime dateEnd)
        {
            if (dateStart > dateEnd)
                return BadRequest();

            var sensor = await _sensorService.GetByIdAndTime(guid, dateStart, dateEnd);

           return Ok(sensor);
        }

        [HttpGet("groupById/{groupGuid}/{dateStart}/{dateEnd}")]
        public async Task<IActionResult> GetSensorsByGroupId([FromRoute] Guid groupGuid, DateTime dateStart, DateTime dateEnd)
        {
            if (dateStart > dateEnd)
                return BadRequest();

            var sensorGroup = await _sensorService.GetGroupByIdAndTime(groupGuid, dateStart, dateEnd);

            return Ok(sensorGroup);
        }

        [HttpGet("groupByLocalization/{localization}/{dateStart}/{dateEnd}")]
        public async Task<IActionResult> GetSensorsByLocalization([FromRoute] string localization, DateTime dateStart, DateTime dateEnd)
        {
            if (string.IsNullOrEmpty(localization) || dateStart > dateEnd)
                return BadRequest();

            var sensor = await _sensorService.GetByLocalizationAndTIme(Enum.Parse<SensorLocalizationEnum>(localization), dateStart, dateEnd);

            return Ok(sensor);
        }

        [HttpGet("groupByType/{type}/{dateStart}/{dateEnd}")]
        public async Task<IActionResult> GetSensorsByType([FromRoute] string type, DateTime dateStart, DateTime dateEnd)
        {
            if (string.IsNullOrEmpty(type) || dateStart > dateEnd)
                return BadRequest();

            var sensor = await _sensorService.GetByTypeAndTIme(Enum.Parse<SensorTypeEnum>(type), dateStart, dateEnd);

            return Ok(sensor);
        }
    }
}