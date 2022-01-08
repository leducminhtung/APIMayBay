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
    public class LoTuyenController : ControllerBase
    {
        private LoTuyenService loTuyenService;
        public LoTuyenController(LoTuyenService loTuyenService)
        {
            this.loTuyenService = loTuyenService;
        }

        [HttpGet("get-LoTuyen")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetLoTuyenList()
        {
            List<LoTuyenViewModel> loTuyenList = loTuyenService.GetLoTuyens();
            return Ok(new { status = true, data = loTuyenList });
        }

        [HttpPost("insert-LoTuyen")]
        public async Task<ActionResult> InsertLoTuyen(LoTuyenInsertModel loTuyen)
        {
            LoTuyenViewModel st = new LoTuyenViewModel();
            
            st.Id1 = loTuyen.Id1;
            st.Id2 = loTuyen.Id2;
            st.MaCangDen = loTuyen.MaCangDen;
            st.MaCangDi = loTuyen.MaCangDi;
            loTuyenService.InsertLoTuyen(st);
            return Ok(new { status = true, message = "" });
        }
    }

}