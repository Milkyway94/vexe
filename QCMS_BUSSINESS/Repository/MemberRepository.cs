using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class MemberRepository : Repository<tbl_Member>
    {
        private vexedtEntities ChildDataContext;

        public MemberRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_Member>();
            this.DataContext = ChildDataContext;
        }
    }
}
