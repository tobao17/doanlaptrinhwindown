using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using quanlitrungtamngoaingu.Dataaccesslayer;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class giaovienthoiviec
    {
        public static DataTable loadgiaovien()
        {

            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.GIAOVIENs
                      where p.Thoiviec == true
                      //where p.MaGV == q.MaGV
                      select new
                      {
                          p.MaGV,
                          p.HoTenGV,
                          p.SoDT,
                          p.DonViCongTac,
                          p.DiaChi,   
                  
                          p.Anh,    
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("MãGV");
            dt.Columns.Add("Họ Tên");
           
            dt.Columns.Add("Địa Chỉ");
         
            dt.Columns.Add("Số Điện Thoại");
            dt.Columns.Add("Đơn vị");
       
            dt.Columns.Add(new DataColumn("Ảnh", typeof(byte[])));
    
            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaGV, q.HoTenGV, q.DiaChi,  q.SoDT, q.DonViCongTac, q.Anh);
            }
            return dt;
        }
        public static bool xoagiaovien(string magv)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            GIAOVIEN gv = new GIAOVIEN();
            gv.MaGV = magv;
            qltt.GIAOVIENs.Attach(gv);
            qltt.GIAOVIENs.Remove(gv);
          //  gv.Thoiviec = true;
            qltt.SaveChanges();
            return true;

        }
    }
}
