using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Phonghoc
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public Phonghoc()
        {
            db = new DBMain();
        }
        public DataSet Layphonghoc()
        {
            return db.ExecuteQueryDataSet("select MaPhong,TenPhong,SoLuongGhe from PHONGHOC", CommandType.Text);
        }
    }
}
