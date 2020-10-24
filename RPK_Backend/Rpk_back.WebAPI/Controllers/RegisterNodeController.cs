using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rpk_back.Domain.Models;

namespace Rpk_back.WebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class RegisterNodeController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> RegisterNode([FromBody] RegisterNode registerNodeQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            
        }
    }
}