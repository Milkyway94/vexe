using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class OtherRepository : Repository<tbl_Other>
    {
        private vexedtEntities ChildDataContext;

        public OtherRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_Other>();
            this.DataContext = ChildDataContext;
        }
        public tbl_Other GetOtherByCode(string otherCode)
        {
            var rs= this.SearchFor(o => o.Other_Mod == otherCode);
            if (rs != null)
            {
                return rs.SingleOrDefault();
            }
            else
            {
                return new tbl_Other();
            }
        }
    }
}
