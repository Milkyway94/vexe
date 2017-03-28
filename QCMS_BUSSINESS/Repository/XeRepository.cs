using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class XeRepository : Repository<Xe>
    {
        private vexedtEntities ChildDataContext;

        public XeRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<Xe>();
            dataContext.Configuration.ProxyCreationEnabled = false;
            this.DataContext = dataContext;
        }
        public List<Xe> GetXeTheoNhaXe(int nhaxe)
        {
            return this.SearchFor(o => o.Nhaxe.Value == nhaxe).ToList();
        }
        public List<SoDienThoai> GetSDTCuaXe(int maxe)
        {
            return this.Find(maxe).SoDienThoais.ToList();
        }
        public string GetHinhAnhCuaXe(int maxe)
        {
            CodeRepository codeRepo = new CodeRepository();
            var code = codeRepo.SearchFor(o => o.TABLE_NAME == "Xe" && o.TYPE == "IMG" && o.TABLE_PK == maxe);
            if (code != null && code.Count() > 0)
            {
                return code.SingleOrDefault().VALUE;
            }
            else
            {
                return "{}";
            }
        }
        public List<ChuyenXe> GetChuyenXeFromXe(int maxe)
        {
            return this.Find(maxe).ChuyenXes.ToList();
        }
    }
}
