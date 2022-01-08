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
    public class HoaDonController : ControllerBase
    {
        private HoaDonService hoaDonService;
        public HoaDonController(HoaDonService hoaDonService)
        {
            this.hoaDonService = hoaDonService;
        }

        [HttpGet("get-HoaDon")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetHoaDonList()
        {
            List<HoaDonViewModel> hoaDonList = hoaDonService.GetHoaDons();
            return Ok(new { status = true, data = hoaDonList });
        }

        [HttpPost("insert-HoaDon")]
        public async Task<ActionResult> InsertHoaDon(HoaDonInsertModel hoadon)
        {
            HoaDonViewModel st = new HoaDonViewModel();
            st.MaHD = Guid.NewGuid();
            st.MaKhach = hoadon.MaKhach;
            st.NgayLap = hoadon.NgayLap;
            st.SL_EmBe = hoadon.SL_EmBe;
            st.SL_NguoiLon = hoadon.SL_NguoiLon;
            st.SL_TreEm = hoadon.SL_TreEm;
            st.TongTien = hoadon.TongTien;
            
            hoaDonService.InsertHoaDon(st);
            return Ok(new { status = true, message = "" });
        }
    }

}