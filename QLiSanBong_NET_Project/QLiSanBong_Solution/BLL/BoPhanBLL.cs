using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DTO;
using QLiSanBong_Solution.DAL;
using System.Data;

namespace QLiSanBong_Solution.BLL
{
    public class BoPhanBLL
    {
        BoPhanDAL bpDAL = new BoPhanDAL();
        public DataTable LoadDataBP()
        {
            return bpDAL.getList();
        }
    }
}
