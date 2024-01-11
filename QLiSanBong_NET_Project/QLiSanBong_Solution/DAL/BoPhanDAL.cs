using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DTO;
using System.Data;

namespace QLiSanBong_Solution.DAL
{
    public class BoPhanDAL
    {
        DataHelper helper = new DataHelper();
        public BoPhan getBOPHANfromDataRow(DataRow row)
        {
            BoPhan bp = new BoPhan();
            bp.ID_BoPhan = int.Parse(row["ID_BoPhan"].ToString());
            bp.Name = row["TenBoPhan"].ToString().Trim();
            return bp;
        }
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from BOPHAN");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            return table;
        }
    }
}
