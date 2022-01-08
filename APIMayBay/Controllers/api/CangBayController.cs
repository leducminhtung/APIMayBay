using APIMayBay.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APIMayBay.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CangBayController : ControllerBase
    {
        private CangBayService cangBayService;
        public CangBayController(CangBayService cangBayService)
        {
            this.cangBayService = cangBayService;
        }

        [HttpGet("get-cangbay")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetCangBayList()
        {
            List<CangBayViewModel> cangBayList = cangBayService.GetCangBays();
            return Ok(new { status = true, data = cangBayList });
        }


    }

}