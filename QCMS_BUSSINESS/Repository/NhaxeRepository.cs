using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class NhaxeRepository : Repository<NhaXe>
    {
        private vexedtEntities ChildDataContext;

        public NhaxeRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<NhaXe>();
            dataContext.Configuration.ProxyCreationEnabled = false;
            this.DataContext = dataContext;
            
        }
    }
}
