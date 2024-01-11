using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class KhachDAL
    {
        DataHelper helper = new DataHelper();
        public Khach getKHfromDataRow(DataRow row)
        {
            Khach kh = new Khach();
            kh.SDT = row["SDT"].ToString();
            kh.HoTen = row["HoTen"].ToString();
            return kh;
        }
        public bool Add(Khach kh)
        {
                string query = string.Format("Insert into KHACH(SDT,HoTen) values ('{0}',N'{1}')", kh.SDT, kh.HoTen);
                try
                {
                    helper.ExecuteNonQuery(query);
                    return true;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }
        public bool Remove(Khach kh)
        {
            string query = string.Format("DELETE FROM KHACH where KHACH.SDT = '{0}'", kh.SDT);
            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool isDupKey(string sdt)
        {
            string query = string.Format("Select count(*) from KHACH where SDT = '{0}'", sdt);
            try
            {
                int count = helper.ExcuteScalar(query);
                if (count >= 1)
                    return true;
                else
                    return false;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string getTenKhach(string sdt)
        {
            string hoten = "";
            Khach kh = new Khach();
            DataTable table = null;
            int n = 0;
            table = helper.ExecuteQuery("Select * from KHACH");
            n = table.Rows.Count;
            if (n == 0)
                return "Vãng lai";
            for (int i = 0; i < n; i++)
            {
                kh = getKHfromDataRow(table.Rows[i]);
                if (kh.SDT == sdt)
                {
                    return kh.HoTen;
                }
            }
            return "Vãng lai";
        }
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;
            table = helper.ExecuteQuery("Select * from KHACH");
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
    }
}
