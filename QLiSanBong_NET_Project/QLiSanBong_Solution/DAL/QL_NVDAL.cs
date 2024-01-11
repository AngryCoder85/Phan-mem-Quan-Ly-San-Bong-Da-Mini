using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DTO;
using System.Data;

namespace QLiSanBong_Solution.DAL
{
    public class QL_NVDAL
    {
        DataHelper helper = new DataHelper();
        public bool Add(TKNhanVien tknv)
        {

            string query = string.Format("INSERT INTO QL_NV(ID_ChuSoHuu, ID_NhanVien) VALUES ({0}, {1})", 1, tknv.ID_NV);
            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
