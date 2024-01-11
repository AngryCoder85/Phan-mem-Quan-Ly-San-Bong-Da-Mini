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
    public class KhachBLL
    {
        KhachDAL khDAL = new KhachDAL();
        public bool Add(Khach kh)
        {
            try
            {
                return khDAL.Add(kh);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Remove(Khach kh)
        {
            try
            {
                return khDAL.Remove(kh);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool isDupKey(string sdt)
        {
            try
            {
                return khDAL.isDupKey(sdt);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string getName(string sdt)
        {
            try
            {
                return khDAL.getTenKhach(sdt);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetData()
        {
            try
            {
                return khDAL.getList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
