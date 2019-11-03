using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class doimatkhau
    {
        DBMain db = null;
        public doimatkhau()
        {
            db = new DBMain();
        }
        public DataSet kiemtramatkhau(string taikhoan, string matkhau)
        {
            return db.ExecuteQueryDataSet("Select * From NGUOIDUNG Where Username='" + taikhoan + "' and Password = '" + matkhau + "'", CommandType.Text);
        }
        public bool CapNhatMK(string MaGV, string TenGV, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatGV2", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaGV", MaGV),
              new SqlParameter("@HoTenGV", TenGV))
              ;
        }
    }
}
