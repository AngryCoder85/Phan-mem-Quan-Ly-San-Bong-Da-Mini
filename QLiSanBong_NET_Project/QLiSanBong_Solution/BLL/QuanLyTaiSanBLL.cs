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
    public class QuanLyTaiSanBLL
    {
        QuanLyTaiSanDAL qltsDAL = new QuanLyTaiSanDAL();
        public DataTable getList()
        {
            try
            {
                return qltsDAL.getList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add(QLTAISAN qlts)
        {
            try
            {
                return qltsDAL.Add(qlts);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Remove(QLTAISAN qlts)
        {
            try
            {
                return qltsDAL.Remove(qlts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
