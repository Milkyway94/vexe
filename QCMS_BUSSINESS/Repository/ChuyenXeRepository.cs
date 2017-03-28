using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMS_BUSSINESS.Repositories
{
    public class ChuyenXeRepository : Repository<ChuyenXe>
    {
        private vexedtEntities ChildDataContext;

        public ChuyenXeRepository()
        {
            this.ChildDataContext = new vexedtEntities();
            SetUp(ChildDataContext);
        }


        protected override void SetUp(DbContext dataContext)
        {
            this.DbSet = ChildDataContext.Set<ChuyenXe>();
            dataContext.Configuration.ProxyCreationEnabled = false;
            this.DataContext = dataContext;
        }
        public List<ChuyenXe> TimChuyenXeTheoThoiGian(DateTime ngaydi)
        {
            return this.SearchFor(o => o.Ngaydi == ngaydi).ToList();
        }
        public List<ChuyenXe> TimChuyenXeTheoTuyenDuong(int tuyenduong)
        {
            return this.SearchFor(o => o.TuyenDuong == tuyenduong).ToList();
        }
        public List<ChuyenXe> TimChuyenXeTheoThoiGianVaTuyenDuong(DateTime ngaydi, int tuyenduong)
        {
            return this.SearchFor(o => o.TuyenDuong == tuyenduong && o.Ngaydi == ngaydi).ToList();
        }
        public List<Code> LayThongTinVeCuaChuyenXe(int machuyen)
        {
            CodeRepository coderepo = new CodeRepository();
            var codes = coderepo.SearchFor(o => o.TABLE_NAME == "Ghe" && o.TABLE_PK == machuyen);
            return codes.ToList();
        }
        public bool Datve(int machuyen, string code, int sovedat)
        {
            try
            {
                CodeRepository coderepo = new CodeRepository();
                var codes = coderepo.SearchFor(o => o.TABLE_NAME == "Ghe" && o.TABLE_PK == machuyen && o.TYPE == "TICTYPE" && o.CODE1 == code);
                if (codes != null && code.Count() > 0)
                {
                    var res = codes.SingleOrDefault();
                    int tongve = int.Parse(res.VALUE);
                    res.CODE1 = (tongve - sovedat).ToString();
                    coderepo.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }
    }
}
