using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class RequestRepository : Repository<RequestTravel>
    {
        private vexedtEntities ChildDataContext;

        public RequestRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<RequestTravel>();
            this.DataContext = ChildDataContext;
        }
    }
}
