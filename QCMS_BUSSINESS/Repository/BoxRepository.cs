using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class BoxRepository : Repository<tbl_Box>
    {
        private vexedtEntities ChildDataContext;

        public BoxRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_Box>();
            this.DataContext = ChildDataContext;
        }
    }
}
