using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.DAL
{
    public class LoaiSanDAL
    {
        DataHelper helper = new DataHelper();
        public LoaiSan getLSfromDataRow(DataRow row)
        {
            LoaiSan ls = new LoaiSan();
            ls.ID_Loai = row["ID_Loai"].ToString();
            ls.TenLoai = row["TenLoai"].ToString();
            ls.DonGia = int.Parse(row["DonGia"].ToString());
            return ls;
        }
        public DataTable getList()
        {
            DataTable table = null;
            int n = 0;
            table = helper.ExecuteQuery("Select * from LOAISAN");
            n = table.Rows.Count;
            if (n == 0)
                return null;
            return table;
        }
        public bool Update(LoaiSan ls)
        {
            string query = string.Format("Update LOAISAN set DonGia = {0} where ID_Loai = '{1}'", ls.DonGia, ls.ID_Loai);
            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int getDonGiafromLS(string id)
        {
            LoaiSan ls = new LoaiSan();
            DataTable table = null;
            int n = 0;
            table = helper.ExecuteQuery("Select * from LOAISAN");
            n = table.Rows.Count;
            if (n == 0)
                return 0;
            for(int i=0; i<n;i++)
            {
                ls = getLSfromDataRow(table.Rows[i]);
                if (ls.ID_Loai == id)
                    return ls.DonGia;
            }
            return 0;
            
        }
    }
}
