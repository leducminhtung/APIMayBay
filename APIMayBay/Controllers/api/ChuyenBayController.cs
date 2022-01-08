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
    public class ChuyenBayController : ControllerBase
    {
        private ChuyenBayService chuyenBayService;
        public ChuyenBayController(ChuyenBayService chuyenBayService)
        {
            this.chuyenBayService = chuyenBayService;
        }

        [HttpGet("get-chuyenbay")]
        //[Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetChuyenBayList()
        {
            List<ChuyenBayViewModel> chuyenBayList = chuyenBayService.GetChuyenBays();
            return Ok(new { status = true, data = chuyenBayList });
        }

        [HttpPost("insert-chuyenbay")]
        public async Task<ActionResult> InsertChuyenBay(ChuyenBayInsertModel chuyenbay)
        {
            /*ChuyenBayViewModel st = new ChuyenBayViewModel();
            st.Id = Guid.NewGuid();
            st.Name = chuyenbay.Name;
            st.Code = chuyenbay.Code;
            st.Phone = chuyenbay.Phone;
            st.Picture = chuyenbay.Picture;
            chuyenBayService.InsertChuyenBay(st);*/
            return Ok(new { status = true, message = "" });
        }
    }

}