using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data.SqlClient;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class chungchi
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public chungchi()
        {
            db = new DBMain();
        }
        public DataSet LoadChungChi2()
        {
            return db.ExecuteQueryDataSet("select MaChungChi, TenChungChi from CHUNGCHI", CommandType.Text);
        }
        public DataSet LoadCC()
        {
            return db.ExecuteQueryDataSet("select MaChungChi, TenChungChi,HocPhi,Mota from CHUNGCHI where Mota not like N'DA XOA'", CommandType.Text);
        }
        public DataSet kiemtra(string stringkiemtra)
        {
            return db.ExecuteQueryDataSet("Select * From chungchi Where machungchi='" + stringkiemtra + "'", CommandType.Text);
        }
        public bool ThemCC(string macc, string tencc, string hocphi, string mota, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemCC", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaChungChi", macc),
                new SqlParameter("@TenChungChi", tencc),
                 new SqlParameter("@HocPhi", hocphi),
                  new SqlParameter("@MoTa", mota))
                  ;
        }
        public bool CapNhatCC(string macc, string tencc, string hocphi, string mota, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatCC", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaChungChi", macc),
               new SqlParameter("@TenChungChi", tencc),
                new SqlParameter("@HocPhi", hocphi),
                 new SqlParameter("@MoTa", mota))
                 ;
        }
        public bool XoaCC(string macc, ref string err)
        {
            return db.MyExecuteNonQuery2("XoaCC2", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaChungChi", macc))
               ;
        }
    }
}
