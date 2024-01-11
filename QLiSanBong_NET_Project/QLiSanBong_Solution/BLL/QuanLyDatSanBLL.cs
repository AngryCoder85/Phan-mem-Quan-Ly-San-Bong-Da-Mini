using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DAL;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.BLL
{
    public class QuanLyDatSanBLL
    {
        QuanLyDatSanDAL qldsDAL = new QuanLyDatSanDAL();
        public DataTable getList_NullTT()
        {
            try
            {
                return qldsDAL.getList_nullTT();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getList_TT()
        {
            try
            {
                return qldsDAL.getList_TT();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add_nullNTT(QuanLiDatSan qlds)
        {
            try
            {
                return qldsDAL.Add_nullNTT(qlds);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Update_TT(QuanLiDatSan qlds)
        {
            try
            {
                return qldsDAL.Update_TT(qlds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RemoveDatSan(QuanLiDatSan ttds)
        {
            try
            {
                return qldsDAL.Remove(ttds);
            }
            catch(Exception ex)

            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getDoanhThu(string MM, string yy)
        {
            try
            {
                return qldsDAL.getList_DoanhThu(MM, yy);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getDoanhThuNam(string yy)
        {
            try
            {
                return qldsDAL.getList_DoanhThuNam(yy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long getSumThanhToan(string MM, string yy)
        {
            try
            {
                return qldsDAL.TongDT(MM, yy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long getSumThanhToanYear(string yy)
        {
            try
            {
                return qldsDAL.TongDTNam(yy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
