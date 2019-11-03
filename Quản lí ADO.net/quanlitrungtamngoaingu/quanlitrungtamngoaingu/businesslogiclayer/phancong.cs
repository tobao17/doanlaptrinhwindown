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
    class phancong
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public phancong()
        {
            db = new DBMain();
        }
        public DataSet Layphancong()
        {
            return db.ExecuteQueryDataSet("select MaGV,MaLop,Phong,NgayDay from PHANCONG", CommandType.Text);
        }
        public DataSet loadphancongtheolop(string stringkiemtra)
        {
            return db.ExecuteQueryDataSet("Select * From hocvien Where MAHV='" + stringkiemtra + "'", CommandType.Text);
        }
        public bool themphancong(string magv, string malop, string phong, DateTime ngayday, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemPC1", CommandType.StoredProcedure, ref err,
             new SqlParameter("@MaGV", magv),
             new SqlParameter("@MaLop", malop),
              new SqlParameter("@Phong", phong),
               new SqlParameter("@Ngaygiangday", ngayday))
               ;
        }
        public bool suaphancong(string magv, string malop, string phong, DateTime ngayday, ref string err)
        {
            return db.MyExecuteNonQuery2("SuaPC1", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaGV", magv),
              new SqlParameter("@MaLop", malop),
               new SqlParameter("@Phong", phong),
                new SqlParameter("@Ngaygiangday", ngayday))
                ;
        }
    }
}
