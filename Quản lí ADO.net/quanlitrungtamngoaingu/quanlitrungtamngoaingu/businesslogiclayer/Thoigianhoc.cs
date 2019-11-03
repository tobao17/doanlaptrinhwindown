using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Thoigianhoc
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public Thoigianhoc()
        {
            db = new DBMain();
        }
        public DataSet LoadTGH2()
        {
            return db.ExecuteQueryDataSet("select * from THOIGIANHOC", CommandType.Text);
        }
        public DataSet LoadTGH()
        {
            return db.ExecuteQueryDataSet("select TenLop,TenPhong,THOIGIANHOC.MaThoiGian,ThoiGianHoc " +
                "from(LOP inner join PHONGHOC on LOP.MaPhong = PHONGHOC.MaPhong) inner join THOIGIANHOC on LOP.MaThoiGian = THOIGIANHOC.MaThoiGian", CommandType.Text);
        }
    }
}
