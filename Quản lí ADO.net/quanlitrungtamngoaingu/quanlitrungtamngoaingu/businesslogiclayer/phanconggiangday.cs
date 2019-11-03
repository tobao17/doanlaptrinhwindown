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
    class phanconggiangday
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public phanconggiangday()
        {
            db = new DBMain();
        }
        public DataSet LoadPhanCong()
        {
            return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,SoDT,TenLop,Phong,ngayday " +
                "from (GIAOVIEN right outer join PHANCONG on GIAOVIEN.MaGV = PHANCONG.MaGV) inner join LOP on PHANCONG.MaLop= LOP.MaLop Where ThoiViec = 0", CommandType.Text);
        }

        public DataSet LoadPhanCongTheoLop(string TenLop)
        {
            return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,SoDT,TenLop,Phong,ngayday " +
                "from (GIAOVIEN inner join PHANCONG on GIAOVIEN.MaGV = PHANCONG.MaGV) inner join LOP on PHANCONG.MaLop= LOP.MaLop Where LOP.TenLop =N'" + TenLop + "'", CommandType.Text);
        }
        public DataSet Find(string TenGV)
        {
            return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,SoDT,TenLop,Phong,ngayday " +
                "from (GIAOVIEN inner join PHANCONG on GIAOVIEN.MaGV = PHANCONG.MaGV) inner join LOP on PHANCONG.MaLop= LOP.MaLop Where HoTenGv like '" + TenGV + "'", CommandType.Text);
        }
    }
}
