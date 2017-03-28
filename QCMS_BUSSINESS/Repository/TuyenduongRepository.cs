using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class TuyenduongRepository : Repository<TuyenDuong>
    {
        private vexedtEntities ChildDataContext;

        public TuyenduongRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<TuyenDuong>();
            this.DataContext = ChildDataContext;
        }
    }
}
