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
    public class LoaiSanBLL
    {
        LoaiSanDAL lsDAL = new LoaiSanDAL();
        public DataTable GetData()
        {
            try
            {
                return lsDAL.getList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int getDonGia(string id)
        {
            try
            {
                return lsDAL.getDonGiafromLS(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Update(LoaiSan ls)
        {
            try
            {
                return lsDAL.Update(ls);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
