using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class ProvinceRepository : Repository<TinhThanh>
    {
        private vexedtEntities ChildDataContext;

        public ProvinceRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<TinhThanh>();
            this.DataContext = dataContext;
        }
    }
}
