using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class diemdanh
    {
        public static DataTable loaddiemdanh()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      join q in qltrungtamentity.TINHTRANGs
                      on p.MaHV equals q.MaHV into gv
                      from s in gv.DefaultIfEmpty()
                      where p.nghihoc != true
                      //where p.MaGV == q.MaGV
                      select new
                      {
                          p.MaHV,
                          p.HoTenHV,
                          solancomat = s.SoLanCoMat == null ? "" : s.SoLanCoMat,
                          solanvangmat = s.SoLanCoMat == null ? "" : s.SoLanVangMat,
                          
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã HV");
            dt.Columns.Add("Tên HV");
            dt.Columns.Add("số lần có mặt");
            dt.Columns.Add("số lần vắng mặt");

            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaHV, q.HoTenHV, q.solancomat, q.solanvangmat);
            }
            return dt;

        }
        public static bool suadiemdanh(string mahv,string slcm,string slvm)
     
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var pc = (from PC in qltt.TINHTRANGs
                      where PC.MaHV == mahv
                      //   where PC.MaLop = malop
                      select PC).SingleOrDefault();
            if (mahv != null)
            {

                // pc.MaLop = malop;
                pc.MaHV = mahv;
                pc.SoLanCoMat = slcm;
                pc.SoLanVangMat = slvm;
                qltt.SaveChanges();

            }
            return true;
        }
        public static bool kiemtra(string mahv)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.TINHTRANGs
                      where p.MaHV == mahv
                      select p;
            DataTable dt = new DataTable();
            foreach (var p in gvs)
            {
                dem++;
            }
            if (dem == 0)
                return true;
            return false;
        }
        public static bool themdiemdanh(string mahv, string slcm, string slvm)
        {
            try
            {
                QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
               TINHTRANG kh = new TINHTRANG();
                kh.MaHV = mahv;
           //     kh.BaoLuu = "1";//chưa sử dụng bản bảo lưu thêm vào mặt định
                kh.SoLanCoMat = slcm;
                kh.SoLanVangMat = slvm;
                qltt.TINHTRANGs.Add(kh);
                qltt.SaveChanges();
            }
            catch (Exception a)
            {
                return true;
            }
            return true;

        }
    }
}
