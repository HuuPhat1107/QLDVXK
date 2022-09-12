using QLBH.Common.Req;
using QLDV.Common.BLL;
using QLDV.Common.Rsp;
using QLDV.DAL;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.BLL
{
    public class ChuyenXeSvc : GenericSvc<ChuyenXeRep, ChuyenXe>
    {
        private ChuyenXeRep chuyenxeRep;
        public ChuyenXeSvc()
        {
            chuyenxeRep = new ChuyenXeRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp CreateChuyenXe(ChuyenXeReq chuyenXeReq)
        {
            var res = new SingleRsp();
            ChuyenXe chuyenxe = new ChuyenXe();
            chuyenxe.GarageId = chuyenXeReq.GarageId;
            chuyenxe.Start = chuyenXeReq.Start;
            chuyenxe.Finish = chuyenXeReq.Finish;

            res = chuyenxeRep.CreateChuyenXe(chuyenxe);
            var c = res;
            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Remove(id);
            return res;
        }
    }
}