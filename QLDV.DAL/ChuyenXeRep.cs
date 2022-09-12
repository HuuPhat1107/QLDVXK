using QLDV.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDV.DAL.Models;
using System.Linq;
using QLDV.Common.Rsp;

namespace QLDV.DAL
{
    public class ChuyenXeRep : GenericRep<QLDVXKContext, ChuyenXe>
    {
        public ChuyenXeRep()
        {

        }

        public override ChuyenXe Read(int id)
        {
            var res = All.FirstOrDefault(c => c.ChuyenXeId == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.ChuyenXeId == id);
            m = base.Delete(m);
            return m.ChuyenXeId;
        }

        public SingleRsp CreateChuyenXe(ChuyenXe chuyenxe)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.ChuyenXes.Add(chuyenxe);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}