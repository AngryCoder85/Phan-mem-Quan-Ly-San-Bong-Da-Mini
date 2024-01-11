using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DAL;

namespace QLiSanBong_Solution.BLL
{
    public class TaiSanBLL
    {
        TaiSanDAL tsDAL = new TaiSanDAL();
        public DataTable getList()
        {
            try
            {
                return tsDAL.getList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
