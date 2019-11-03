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
    class ketquahoctap
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public ketquahoctap()
        {
            db = new DBMain();
        }
        public DataSet LayKQHT()
        {
            return db.ExecuteQueryDataSet("select HoTenHV,KETQUAHOCTAP.MaKQ,diemnguphap,diemgiaotiep,diemchuyencan,diemkynang,diembaitap,diemdinhky " +
                "from KETQUAHOCTAP inner join HOCVIEN on KETQUAHOCTAP.MaKQ=HOCVIEN.MaKQ Where nghihoc=0  ", CommandType.Text);
            //inner join HOCVIEN on KETQUAHOCTAP.MaKQ=HOCVIEN.MaKQ Where nghihoc=0
        }
        public bool themKQHT(string makq, string diemnguphap, string diemgiaotiep, string diemchuyencan, string diemkynang, string diembaitap, string diemdinhky, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemKQHT1", CommandType.StoredProcedure, ref err,
             new SqlParameter("@MaKQ", makq),
             new SqlParameter("@diemnguphap", diemnguphap),
             new SqlParameter("@diemgiaotiep", diemgiaotiep),
             new SqlParameter("@diemchuyencan", diemchuyencan),
             new SqlParameter("@diemkynang", diemkynang),
             new SqlParameter("@diembaitap", diembaitap),
             new SqlParameter("@diemdinhky", diemdinhky))
             ;
        }
        public bool themKQHT2(string makq, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemKQHT2", CommandType.StoredProcedure, ref err,
             new SqlParameter("@MaKQ", makq))
             ;
        }
        public bool XoaHV(ref string err, string MaHV)
        {
            return db.MyExecuteNonQuery2("XoaHV", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHV", MaHV),
                   new SqlParameter("@nghihoc", '1'))
                ;
        }
        public bool CapNhatKQHT(string makq, string diemnguphap, string diemgiaotiep, string diemchuyencan, string diemkynang, string diembaitap, string diemdinhky, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatKQHT3", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaKQ", makq),
              new SqlParameter("@diemnguphap", diemnguphap),
              new SqlParameter("@diemgiaotiep", diemgiaotiep),
              new SqlParameter("@diemchuyencan", diemchuyencan),
              new SqlParameter("@diemkynang", diemkynang),
              new SqlParameter("@diembaitap", diembaitap),
              new SqlParameter("@diemdinhky", diemdinhky))
              ;
        }

        //public bool CapNhatKQHT2(string makq, string mahv, ref string err)
        //{
        //    return db.MyExecuteNonQuery2("CapNhatKQHT5", CommandType.StoredProcedure, ref err,
        //      new SqlParameter("@MaKQ", makq),
        //      new SqlParameter("@MaHV", mahv))
        //      ;
        //}
        public DataSet Find(string TenHV)
        {
            return db.ExecuteQueryDataSet("select HoTenHV,KETQUAHOCTAP.MaKQ,diemnguphap,diemgiaotiep,diemchuyencan,diemkynang,diembaitap,diemdinhky " +
                "from KETQUAHOCTAP inner join HOCVIEN on KETQUAHOCTAP.MaKQ=HOCVIEN.MaKQ Where HoTenHV like '" + TenHV + "'", CommandType.Text);
        }
    }
}
