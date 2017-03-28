using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class FldRepository : Repository<ModFLD>
    {
        private vexedtEntities ChildDataContext;

        public FldRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }
        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<ModFLD>();
            dataContext.Configuration.ProxyCreationEnabled = false;
            this.DataContext = dataContext;
        }

    }
}
