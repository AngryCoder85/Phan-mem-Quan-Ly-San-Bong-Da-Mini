using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class DichVuDAL
    {
        DataHelper helper = new DataHelper();
        public DichVu GetDVfromDataRow(DataRow row)
        {
            DichVu dv = new DichVu();
            dv.ID_DichVu = int.Parse(row["ID_DichVu"].ToString());
            dv.TenDichVu = row["TenDichVu"].ToString();
            dv.DonGia = int.Parse(row["DonGia"].ToString());
            dv.SoLuongTonKho = int.Parse(row["SoLuongTonKho"].ToString());
            return dv;
        }
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;
            string query = "Select * from DICHVU";
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public bool Add(DichVu dv)
        {
            string query = string.Format("INSERT INTO DICHVU(TenDichVu, DonGia, SoLuongTonKho) values (N'{0}', {1}, {2})", dv.TenDichVu, dv.DonGia, dv.SoLuongTonKho);
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
        public bool Remove(int id)
        {
            string query = string.Format("DELETE FROM DICHVU WHERE ID_DichVu = {0}", id);
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
        public bool Update(DichVu dv)
        {
            string query = string.Format("UPDATE DICHVU SET DonGia = {0} , SoLuongTonKho = {1} where ID_DichVu = {2}", dv.DonGia, dv.SoLuongTonKho, dv.ID_DichVu);
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
       
    }
}
