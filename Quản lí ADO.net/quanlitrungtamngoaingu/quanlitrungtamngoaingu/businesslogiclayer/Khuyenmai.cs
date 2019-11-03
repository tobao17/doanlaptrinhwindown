using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;
using System.Data.SqlClient;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Khuyenmai
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public Khuyenmai()
        {
            db = new DBMain();
        }
        public DataSet LoadKM2()
        {
            return db.ExecuteQueryDataSet("select MaKM, TenKM from KHUYENMAI ", CommandType.Text);
        }
        public DataSet LoadKM()
        {
            return db.ExecuteQueryDataSet("select MaKM, TenKM,NgayBatDauKM,NgayKetThucKM from KHUYENMAI where TenKM not like N'DA XOA'" , CommandType.Text);
        }
        public DataSet kiemtra(string stringkiemtra)
        {
            return db.ExecuteQueryDataSet("Select * From Khuyenmai Where makm='" + stringkiemtra + "'", CommandType.Text);
        }
        public bool ThemKM(string makm, string tenkm, DateTime ngaybd, DateTime ngayketthuc, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemKM", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaKM", makm),
                new SqlParameter("@TenKM", tenkm),
                 new SqlParameter("@NgayBatDau", ngaybd),
                  new SqlParameter("@NgayKetThuc", ngayketthuc))
                  ;
        }
        public bool CapNhatKM(string makm, string tenkm, DateTime ngaybd, DateTime ngayketthuc, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatKM1", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaKM", makm),
                new SqlParameter("@TenKM", tenkm),
                 new SqlParameter("@NgayBatDau", ngaybd),
                  new SqlParameter("@NgayKetThuc", ngayketthuc))
                  ;
        }
        public bool XoaKM(string makm, ref string err)
        {
            return db.MyExecuteNonQuery2("XoaKM1", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaKM", makm))
               ;
        }
    }
}
