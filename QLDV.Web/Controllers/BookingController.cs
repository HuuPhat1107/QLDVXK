using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDV.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingSvc bookingSvc;
        public BookingController()
        {
            bookingSvc = new BookingSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllBooking()
        {
            var res = new SingleRsp();
            res.Data = bookingSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult GetBookingByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = bookingSvc.Read(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("create-booking")]
        public IActionResult GetUserById([FromBody] BookingReq bookingReq)
        {
            var res = bookingSvc.CreateBooking(bookingReq);
            return Ok(res);
        }

        [HttpPut("update-booking")]
        public IActionResult UpdateBooking([FromBody] BookingReq reqBooking, int id)
        {
            var res = bookingSvc.UpdateBooking(reqBooking, id);
            return Ok(res);
        }
        [HttpDelete("delete-by-id")]
        public IActionResult DeleteBookingId(int id)
        {
            var res = new SingleRsp();
            res = bookingSvc.Delete(id);
            return Ok(res);
        }


    }
}
