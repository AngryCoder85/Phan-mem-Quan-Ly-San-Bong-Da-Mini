using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;
using QLiSanBong_Solution.DAL;

namespace QLiSanBong_Solution.BLL
{
    public class ThanhToanDichVuBLL
    {
        ThanhToanDichVuDAL ttdvDAL = new ThanhToanDichVuDAL();
        public DataTable getList()
        {
            try
            {
                return ttdvDAL.getList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add(ThanhToanDichVu dv)
        {
            try
            {
                return ttdvDAL.Add(dv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getList_MMyy(string MM, string yy)
        {
            try
            {
                return ttdvDAL.getList_DTDV_MMyy(MM, yy);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getList_yy(string yy)
        {
            try
            {
                return ttdvDAL.getList_DTDV_yy(yy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long SumDTDV_MMyy(string MM, string yy)
        {
            try
            {
                return ttdvDAL.TongDT_MMyy(MM, yy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long SumDTDV_yy(string yy)
        {
            try
            {
                return ttdvDAL.TongDT_yy(yy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
