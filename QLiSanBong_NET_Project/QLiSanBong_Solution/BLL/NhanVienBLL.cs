using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DAL;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nvDAL = new NhanVienDAL();
        public bool Add(NhanVien nv)
        {
            try
            {
                return nvDAL.Add(nv);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Remove(NhanVien nv)
        {
            try
            {
                return nvDAL.Remove(nv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NhanVien getNew()
        {
            return nvDAL.getNewNV();
        }
    }
}
