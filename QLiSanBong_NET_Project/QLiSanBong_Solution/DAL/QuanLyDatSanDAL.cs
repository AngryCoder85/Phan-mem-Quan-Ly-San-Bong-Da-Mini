using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class QuanLyDatSanDAL
    {
        DataHelper helper = new DataHelper();
        public DataTable getList_nullTT()
        {
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from QUANLYDATSAN where NgayThanhToan is NULL");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
        public DataTable getList_TT()
        {
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("SELECT * FROM QUANLYDATSAN where NgayThanhToan is not NULL");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
        public bool Add_nullNTT(QuanLiDatSan qlds)
        {
            string query = string.Format("INSERT INTO QUANLYDATSAN(ID_NhanVien, ID_LoaiSan, ViTriSan, SDT, ThoiGianBD, ThoiGianKT, ThanhToan) VALUES ({0}, '{1}', N'{2}', '{3}', '{4}', '{5}', {6})", qlds.ID_NhanVien, qlds.ID_LoaiSan, qlds.ViTriSan, qlds.SDT, qlds.ThoiGianBD.ToString("MM/dd/yyyy HH:mm:ss"), qlds.ThoiGianKT.ToString("MM/dd/yyyy HH:mm:ss"), qlds.ThanhToan);
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
        public bool Update_TT(QuanLiDatSan qlds)
        {
            string query = string.Format("UPDATE QUANLYDATSAN SET NgayThanhToan = '{0}' where ID_LoaiSan = '{1}' and ViTriSan = N'{2}' and ThoiGianBD = '{3}' ", DateTime.Now.ToString("MM/dd/yyyy"), qlds.ID_LoaiSan, qlds.ViTriSan, qlds.ThoiGianBD.ToString("MM/dd/yyyy HH:mm:ss"));
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
        public bool Remove(QuanLiDatSan qlds)
        {
            string query = string.Format("Delete from QUANLYDATSAN where ID_LoaiSan = '{0}' and ViTriSan = N'{1}' and ThoiGianBD = '{2}'", qlds.ID_LoaiSan, qlds.ViTriSan, qlds.ThoiGianBD.ToString("MM/dd/yyyy HH:mm:ss"));
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
        public DataTable getList_DoanhThu(string MM, string yy)
        {
            DataTable table = null;
            int n = 0;
            string query = string.Format("SELECT * FROM QUANLYDATSAN where NgayThanhToan is not NULL and Month(NgayThanhToan) = '{0}' and year(NgayThanhToan) = '{1}'", MM, yy);

            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
        public DataTable getList_DoanhThuNam(string yy)
        {
            DataTable table = null;
            int n = 0;
            string query = string.Format("SELECT * FROM QUANLYDATSAN where NgayThanhToan is not NULL and year(NgayThanhToan) = '{0}'", yy);

            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
        public long TongDT(string MM, string yy)
        {
           string query = string.Format("SELECT sum(ThanhToan) FROM QUANLYDATSAN where NgayThanhToan is not NULL and Month(NgayThanhToan) = '{0}' and year(NgayThanhToan) = '{1}'", MM, yy);

           try
            {
                long dt = helper.ExcuteScalar(query);
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long TongDTNam(string yy)
        {
            string query = string.Format("SELECT sum(ThanhToan) FROM QUANLYDATSAN where NgayThanhToan is not NULL and year(NgayThanhToan) = '{0}'", yy);

            try
            {
                long dt = helper.ExcuteScalar(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
