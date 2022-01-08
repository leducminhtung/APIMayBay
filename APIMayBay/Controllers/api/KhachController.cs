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
    public class KhachController : ControllerBase
    {
        private KhachService khachService;
        public KhachController(KhachService khachService)
        {
            this.khachService = khachService;
        }

        [HttpGet("get-Khach")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetKhachList()
        {
            List<KhachViewModel> khachList = khachService.GetKhachs();
            return Ok(new { status = true, data = khachList });
        }

        [HttpPost("insert-Khach")]
        public async Task<ActionResult> InsertKhach(KhachInsertModel khach)
        {
            KhachViewModel st = new KhachViewModel();
            st.MaKhach = Guid.NewGuid();
            st.CCCD = khach.CCCD;
            st.Email = khach.CCCD;
            st.GioiTinh = khach.GioiTinh;
            st.HoTen = khach.HoTen;
            st.NgaySinh = khach.NgaySinh;
            st.SDT = khach.SDT;
            st.Ten = khach.Ten;
           
            khachService.InsertKhach(st);
            return Ok(new { status = true, message = "" });
        }
    }

}