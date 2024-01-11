using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class QuanLyTaiSanDAL
    {
        DataHelper helper = new DataHelper();
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from QL_TAISAN");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
        public bool Add(QLTAISAN qlts)
        {
            string query = string.Format("INSERT INTO QL_TAISAN(ID_NhanVien, ID_TaiSan, GhiChu) values ({0}, {1}, N'{2}')", qlts.ID_NhanVien, qlts.ID_TaiSan, qlts.GhiChu);
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
        public bool Remove(QLTAISAN qlts)
        {
            string query = string.Format("Delete from QL_TAISAN where ID_TaiSan = {0} and GhiChu = N'{1}'",qlts.ID_TaiSan, qlts.GhiChu);
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
    }
}
