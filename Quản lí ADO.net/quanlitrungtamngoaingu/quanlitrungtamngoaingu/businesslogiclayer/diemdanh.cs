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
    class diemdanh
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public diemdanh()
        {
            db = new DBMain();
        }
        public DataSet LoadDD()
        {
            return db.ExecuteQueryDataSet("select HOCVIEN.MaHV, HoTenHV,SoLanCoMat,SoLanVangMat " +
                "from TINHTRANG right outer join HOCVIEN on TINHTRANG.MaHV = HOCVIEN.MaHV", CommandType.Text);
        }
        public DataSet kiemtra(string stringkiemtra)
        {
            return db.ExecuteQueryDataSet("Select * From tinhtrang Where MAHV='" + stringkiemtra + "'", CommandType.Text);
        }
        public bool CapNhatDD(string macc, string solancomat, string solanvangmat, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatDD1", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaHV", macc),
                new SqlParameter("@SoLanCoMat", solancomat),
                 new SqlParameter("@SoLanVangMat", solanvangmat))
                 ;
        }
        public bool ThemDD(string mahv, string solancomat, string solanvangmat, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemDD", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaHV", mahv),
                new SqlParameter("@SoLanCoMat", solancomat),
                 new SqlParameter("@SoLanVangMat", solanvangmat))
                 ;
        }
    }
}
