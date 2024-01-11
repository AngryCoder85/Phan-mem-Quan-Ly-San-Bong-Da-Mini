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
    public class SanBLL
    {
        SanDAL sanDAL = new SanDAL();
        public DataTable getList()
        {
            try
            {
                return sanDAL.getList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getList_Combine()
        {
            try
            {
                return sanDAL.getList_Combine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetDatafromLS(string id)
        {
            try
            {
                return sanDAL.getListfromLoaiSan(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add(San s)
        {
            try
            {
                return sanDAL.Add(s);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Remove(San s)
        {
            try
            {
                return sanDAL.Remove(s);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
