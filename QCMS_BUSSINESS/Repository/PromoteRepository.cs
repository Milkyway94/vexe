using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class PromoteRepository : Repository<tbl_PromoteCode>
    {
        private vexedtEntities ChildDataContext;

        public PromoteRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_PromoteCode>();
            this.DataContext = dataContext;
        }
    }
}
