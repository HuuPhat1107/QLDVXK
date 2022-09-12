using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class ChuyenXeReq
    {
        public int? GarageId { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
    }
}