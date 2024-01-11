using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class ThanhToanDichVuDAL
    {
        DataHelper helper = new DataHelper();
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;
            string query = "Select * from THANHTOANDICHVU";
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public bool Add(ThanhToanDichVu ttdv)
        {
            string query = string.Format("INSERT INTO THANHTOANDICHVU(ID_NhanVien, ID_DichVu, SoLuong, ThanhTien) values ({0}, {1}, {2}, {3})", ttdv.ID_NhanVien, ttdv.ID_DichVu,ttdv.SoLuong, ttdv.ThanhTien);
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
        public DataTable getList_DTDV_MMyy(string MM, string yy)
        {
            DataTable table = null;
            int n = 0;
            string query = string.Format("Select * from THANHTOANDICHVU where Month(NgayThanhToan) = '{0}' and year(NgayThanhToan) = '{1}'", MM, yy);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public DataTable getList_DTDV_yy(string yy)
        {
            DataTable table = null;
            int n = 0;
            string query = string.Format("Select * from THANHTOANDICHVU where year(NgayThanhToan) = '{0}'", yy);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public long TongDT_MMyy(string MM, string yy)
        {
            string query = string.Format("SELECT sum(ThanhTien) FROM THANHTOANDICHVU where Month(NgayThanhToan) = '{0}' and year(NgayThanhToan) = '{1}'", MM, yy);

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
        public long TongDT_yy(string yy)
        {
            string query = string.Format("SELECT sum(ThanhTien) FROM THANHTOANDICHVU WHERE year(NgayThanhToan) = '{0}'", yy);

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
