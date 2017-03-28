using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class CodeRepository : Repository<Code>
    {
        private vexedtEntities ChildDataContext;

        public CodeRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<Code>();
            dataContext.Configuration.ProxyCreationEnabled = false;
            this.DataContext = dataContext;
        }
    }
}
