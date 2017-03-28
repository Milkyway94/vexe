using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class DistrictRepository : Repository<QuanHuyen>
    {
        private vexedtEntities ChildDataContext;

        public DistrictRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<QuanHuyen>();
            dataContext.Configuration.ProxyCreationEnabled = false;
            this.DataContext = dataContext;
        }
    }
}
