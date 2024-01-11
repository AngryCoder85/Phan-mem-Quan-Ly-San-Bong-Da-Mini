using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;


namespace QLiSanBong_Solution.DAL
{
    public class TaiSanDAL
    {
        DataHelper helper = new DataHelper();
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from TAISAN");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
    }
}
