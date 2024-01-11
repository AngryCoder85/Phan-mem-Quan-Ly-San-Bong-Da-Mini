using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DTO;
using System.Data;


namespace QLiSanBong_Solution.DAL
{
    public class NhanVienDAL
    {
        DataHelper helper = new DataHelper();
        public NhanVien getNVfromDataRow(DataRow row)
        {
            NhanVien NV = new NhanVien();
            NV.ID = int.Parse(row["ID_NhanVien"].ToString());
            NV.Name = row["TenNhanVien"].ToString().Trim();
            NV.ID_BoPhan = int.Parse(row["ID_BoPhan"].ToString());
            NV.SDT_NV = row["SDT_NV"].ToString().Trim();
            NV.CMND = row["CMND"].ToString().Trim();
            NV.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
            NV.NgayBDLam = DateTime.Parse(row["NgayBDLamViec"].ToString());
            return NV;
        }
        public List<NhanVien> getList()
        {
            List<NhanVien> lstAd = new List<NhanVien>();
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from NHANVIEN");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            for (int i = 0; i < n; i++)
            {
                lstAd.Add(getNVfromDataRow(table.Rows[i]));
            }
            return lstAd;
        }
        public bool Add(NhanVien NV)
        {
            string query = string.Format("INSERT INTO NHANVIEN(TenNhanVien, ID_BoPhan, SDT_NV, CMND, NgaySinh) values (N'{0}', {1}, '{2}', '{3}', '{4}')", NV.Name, NV.ID_BoPhan,  NV.SDT_NV, NV.CMND, NV.NgaySinh.ToString("MM/dd/yyyy"));

            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Remove(NhanVien NV)
        {
            string query = string.Format("Delete from NHANVIEN where NHANVIEN.ID_NhanVien = {0}", NV.ID);
            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NhanVien getNewNV()
        {
            string query = "Select top 1 * from NHANVIEN order by ID_NhanVien DESC";
            DataTable table = helper.ExecuteQuery(query);
            return getNVfromDataRow(table.Rows[0]);
        }
    }
}
