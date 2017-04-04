using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public class ModRepository : Repository<tbl_Mod>
    {
        private vexedtEntities ChildDataContext;

        public ModRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<tbl_Mod>();
            this.DataContext = ChildDataContext;
        }
        public List<tbl_Mod> GetModByBoxId(int boxid)
        {
            BoxRepository boxRepo = new BoxRepository();
            return boxRepo.Find(boxid).tbl_Mod.ToList();
        }
        public List<tbl_Mod> GetModByBoxCode(string boxcode)
        {
            BoxRepository boxRepo = new BoxRepository();
            var boxes= boxRepo.SearchFor(o=>o.Box_Code==boxcode).SingleOrDefault();
            if (boxes != null)
            {

                var mods= boxes.tbl_Mod.OrderBy(o=>o.Mod_Pos);
                if (mods != null)
                {
                    return mods.ToList();
                }
                else
                {
                    return new List<tbl_Mod>();
                }
            }
            else
            {
                return new List<tbl_Mod>();
            }
        }
    }
}
