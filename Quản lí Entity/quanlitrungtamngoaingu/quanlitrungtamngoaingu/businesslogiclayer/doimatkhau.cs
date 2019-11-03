using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class doimatkhau
    {
        public static bool suamk(string username, string pass)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var hv = (from hvien in qltt.NGUOIDUNGs
                      where hvien.Username == username
                      select hvien).SingleOrDefault();
            if (username != null)
            {
                hv.Password = pass;
                qltt.SaveChanges();
            }
            return true;
        }
        public static bool kiemtra(string username,string pass)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.NGUOIDUNGs
                      where p.Username==username && p.Password==pass
                      select p;
            //  DataTable dt = new DataTable();
            foreach (var p in gvs)
            {
                dem++;
            }
            if (dem == 0)
                return false;
            return true;
        }
    }
}
