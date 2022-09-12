using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Common.Req;
using QLDV.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenXeController : ControllerBase
    {
        private ChuyenXeSvc chuyenxeSvc;
        public ChuyenXeController()
        {
            chuyenxeSvc = new ChuyenXeSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult GetChuyenXeById([FromBody] SimpleReq simpleReq)
        {
            try
            {
                var res = new SingleRsp();
                res = chuyenxeSvc.Read(simpleReq.Id);
                if (res.Data == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy chuyến xe");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("delete-by-id")]
        public IActionResult DeleteChuyenXeById([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = chuyenxeSvc.Delete(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("create-chuyenxe")]
        public IActionResult CreateProduct([FromBody] ChuyenXeReq reqChuyenxe)
        {
            var res = new SingleRsp();
            res = chuyenxeSvc.CreateChuyenXe(reqChuyenxe);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllChuyenXe()
        {
            var res = new SingleRsp();
            res.Data = chuyenxeSvc.All;
            return Ok(res);
        }
    }
}
