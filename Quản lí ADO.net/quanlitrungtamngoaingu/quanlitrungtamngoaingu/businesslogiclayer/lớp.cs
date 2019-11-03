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
    class lớp
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public lớp()
        {
            db = new DBMain();
        }
        public DataSet LoadLop2()
        {
            return db.ExecuteQueryDataSet("select MaLop,TenLop from LOP", CommandType.Text);
        }
        public DataSet LoadLop()
        {
            return db.ExecuteQueryDataSet("select MaLop, TenLop,TenChungChi,TenPhong,ThoiGianHoc,SiSo,TenKM " +
                "from(((LOP inner join CHUNGCHI on LOP.MaChungChi = CHUNGCHI.MaChungChi) inner join KHUYENMAI on LOP.MaKM = KHUYENMAI.MaKM) inner join PHONGHOC on LOP.MaPhong = PHONGHOC.MaPhong) inner join THOIGIANHOC on LOP.MaThoiGian = THOIGIANHOC.MaThoiGian ", CommandType.Text);
        }
        public bool CapNhatLop(string malop, string tenlop, string siso, string Makhuyenmai, string maphong, string machungchi, string mathoigian, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatLop4", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLop", malop),
                new SqlParameter("@TenLop", tenlop),
                 new SqlParameter("@SiSo", siso),
                  new SqlParameter("@MaKM", Makhuyenmai),
                   new SqlParameter("@MaPhong", maphong),
                    new SqlParameter("@MaChungChi", machungchi),
                     new SqlParameter("@MaThoiGian", mathoigian))
           ;
        }

    }
}
