using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;


namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class phancong
    {
        public static DataTable loadphancong()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.PHANCONGs
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã GV");
            dt.Columns.Add(" Lớp");
            dt.Columns.Add("Phòng");
            dt.Columns.Add("Ngày dạy");

            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaGV, q.MaLop, q.Phong,q.ngayday);
            }
            return dt;

        }
        public static bool themphancong(string magv,string malop,string phong ,DateTime ngayday)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            PHANCONG pc = new PHANCONG();
            pc.MaGV = magv;
            pc.MaLop = malop;
            pc.Phong = phong;
            pc.ngayday = ngayday;
            qltt.PHANCONGs.Add(pc);
            qltt.SaveChanges();
            return true;

        }
        public static bool suaphancong(string magv, string malop, string phong, DateTime ngayday)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var pc = (from PC in qltt.PHANCONGs
                      where PC.MaGV == magv && PC.MaLop == malop
                   //   where PC.MaLop = malop
                      select PC).SingleOrDefault();
            if (magv != null && malop!=null)
            {
               // pc.MaLop = malop;
                pc.Phong = phong;
                pc.ngayday = ngayday;
                qltt.SaveChanges();
          
            }
            return true;
        }
    }
}
