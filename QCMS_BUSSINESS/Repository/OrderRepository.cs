using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class OrderRepository : Repository<tbl_Order>
    {
        private vexedtEntities ChildDataContext;

        public OrderRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_Order>();
            this.DataContext = ChildDataContext;
        }
    }
}
