using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class MethodRepository : Repository<tbl_PhuongThucThanhToan>
    {
        private vexedtEntities ChildDataContext;

        public MethodRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_PhuongThucThanhToan>();
            this.DataContext = ChildDataContext;
        }
    }
}
