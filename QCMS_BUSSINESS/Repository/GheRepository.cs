using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class GheRepository : Repository<Ghe>
    {
        private vexedtEntities ChildDataContext;

        public GheRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<Ghe>();
            this.DataContext = ChildDataContext;
        }
    }
}
