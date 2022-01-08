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
    public class TaiKhoanController : ControllerBase
    {
        private TaiKhoanService taiKhoanService;
        public TaiKhoanController(TaiKhoanService taiKhoanService)
        {
            this.taiKhoanService = taiKhoanService;
        }

        [HttpGet("get-TaiKhoan")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetTaiKhoanList()
        {
            List<TaiKhoanViewModel> taiKhoanList = taiKhoanService.GetTaiKhoans();
            return Ok(new { status = true, data = taiKhoanList });
        }

        [HttpPost("insert-TaiKhoan")]
        public async Task<ActionResult> InsertTaiKhoan(TaiKhoanInsertModel taiKhoan)
        {
            TaiKhoanViewModel st = new TaiKhoanViewModel();
            st.MaTK = Guid.NewGuid();
            st.UserName = taiKhoan.UserName;
            st.Password = taiKhoan.Password;
            st.Status = "Đang hoạt động";
            taiKhoanService.InsertTaiKhoan(st);
            return Ok(new { status = true, message = "" });
        }
    }

}