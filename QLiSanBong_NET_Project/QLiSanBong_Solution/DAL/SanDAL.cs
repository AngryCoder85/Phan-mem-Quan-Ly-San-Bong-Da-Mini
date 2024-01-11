using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class SanDAL
    {
        DataHelper helper = new DataHelper();
        public San getSanfromDataRow(DataRow row)
        {
            San san = new San();
            san.ID_Loai = row["ID_Loai"].ToString();
            san.ViTriSan = row["ViTriSan"].ToString();
            return san;
        }
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;
            table = helper.ExecuteQuery("Select * from SAN");
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public DataTable getList_Combine()
        {
            DataTable table = null;
            int n = 0;
            table = helper.ExecuteQuery("select LOAISAN.ID_Loai, SAN.ViTriSan, LOAISAN.DonGia from LOAISAN inner join SAN on LOAISAN.ID_Loai = SAN.ID_Loai");
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public bool Add(San san)
        {
            string query = string.Format("INSERT INTO SAN values ('{0}', N'{1}')", san.ID_Loai, san.ViTriSan);
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
        public bool Remove(San san)
        {
            string query = string.Format("Delete from SAN where ID_Loai = '{0}' and ViTriSan = N'{1}'", san.ID_Loai, san.ViTriSan);
            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getListfromLoaiSan(string id)
        {
            DataTable table = new DataTable();
            int n = 0;
            string query = string.Format("Select * from SAN where ID_Loai = '{0}'", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
    }
}
