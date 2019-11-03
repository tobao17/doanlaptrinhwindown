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
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public giaovienthoiviec()
        {
            db = new DBMain();
        }
        public DataSet LayGV()
        {
            return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,SoDT,DiaChi,DonViCongTac,Anh" +
                " from GIAOVIEN  where Thoiviec =1 ", CommandType.Text);
        }
    }
}
