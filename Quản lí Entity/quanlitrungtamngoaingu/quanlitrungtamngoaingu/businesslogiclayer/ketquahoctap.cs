using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class ketquahoctap
    {
        public static DataTable loadketqua()
        {
            
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      where p.nghihoc != true   
                      //where p.MaGV == q.MaGV              
                      select new
                      {
                          p.KETQUAHOCTAP.MaKQ,
                          p.HoTenHV,
                          p.KETQUAHOCTAP.diemnguphap,
                          p.KETQUAHOCTAP.diemgiaotiep,
                          p.KETQUAHOCTAP.diemchuyencan,
                          p.KETQUAHOCTAP.diemkynang,
                          p.KETQUAHOCTAP.diembaitap,
                          p.KETQUAHOCTAP.diemdinhky,
                        
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("MãKQ");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Điểm Ngữ Pháp");
            dt.Columns.Add("Điểm Giao Tiếp");
            dt.Columns.Add("Điểm Chuyên Cần");
            dt.Columns.Add("Điểm Kỹ Năng");
            dt.Columns.Add("Điểm bài tập");
            dt.Columns.Add("Điểm Định Kỳ");
            dt.Columns.Add("Điểm Trung Bình");


            foreach (var q in gvs)
            {
                double dtb = (Convert.ToDouble(q.diemnguphap) + Convert.ToDouble(q.diemgiaotiep)
                         + Convert.ToDouble(q.diemchuyencan) + Convert.ToDouble(q.diemkynang) +
                         Convert.ToDouble(q.diembaitap) + Convert.ToDouble(q.diemdinhky)) / 6;

                dt.Rows.Add(q.MaKQ, q.HoTenHV, q.diemnguphap, q.diemgiaotiep, q.diemchuyencan, q.diemkynang
                    , q.diembaitap, q.diemdinhky,Math.Round(dtb,2));
            }
            return dt;
        }
        
        public static bool themmakq(string makq, string diemnguphap, string diemgiaotiep, string diemchuyencan, string diemkynang,
            string diembaitap, string diemdinhky, string hocluc)
           
        {
            try
            {
                QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
               KETQUAHOCTAP hv = new KETQUAHOCTAP();
                hv.MaKQ = makq;
                hv.diemnguphap = diemnguphap;
                hv.diemgiaotiep = diemgiaotiep;
                hv.diemchuyencan =diemchuyencan;
                hv.diemkynang =diemkynang;
                hv.diembaitap = diembaitap;
                qltt.KETQUAHOCTAPs.Add(hv);
                qltt.SaveChanges();
            }
            catch (Exception )
            {

            }
            return true;

        }
        public static bool suaketquahoctap(string makq,string nguphap, string giaotiep, string chuyencan,string diemkynang ,string diembaitap,
            string diemdinhky)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var pc = (from PC in qltt.KETQUAHOCTAPs
                      where PC.MaKQ == makq
                      //   where PC.MaLop = malop
                      select PC).SingleOrDefault();
            if (makq != null)
            {

                // pc.MaLop = malop;
                pc.MaKQ = makq;
                pc.diemnguphap = nguphap;
                pc.diemgiaotiep = giaotiep;
                pc.diemchuyencan = chuyencan;
                pc.diemkynang = diemkynang;
                pc.diembaitap = diembaitap;
                pc.diemdinhky = diemdinhky;
              
                qltt.SaveChanges();

            }
            return true;
        }
    }
}
