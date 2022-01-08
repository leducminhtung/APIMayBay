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
    public class VeMayBayController : ControllerBase
    {
        private VeMayBayService veMayBayService;
        public VeMayBayController(VeMayBayService veMayBayService)
        {
            this.veMayBayService = veMayBayService;
        }

        [HttpGet("get-VeMayBay")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetVeMayBayList()
        {
            List<VeMayBayViewModel> veMayBayList = veMayBayService.GetVeMayBays();
            return Ok(new { status = true, data = veMayBayList });
        }

        [HttpPost("insert-VeMayBay")]
        public async Task<ActionResult> InsertVeMayBay(VeMayBayInsertModel veMayBay)
        {
            VeMayBayViewModel st = new VeMayBayViewModel();
            st.Id = veMayBay.Id;
            st.LoaiVe = veMayBay.LoaiVe;
            st.MaHD = veMayBay.MaHD;
            st.NgayLap = veMayBay.NgayLap;
            st.TongTien = veMayBay.TongTien;
            veMayBayService.InsertVeMayBay(st);
            return Ok(new { status = true, message = "" });
        }
    }

}