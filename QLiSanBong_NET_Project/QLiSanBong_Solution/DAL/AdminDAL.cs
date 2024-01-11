using System;
using System.Data;
using QLiSanBong_Solution.DTO;
using System.Collections.Generic;


namespace QLiSanBong_Solution.DAL
{
    public class AdminDAL
    {
        DataHelper helper = new DataHelper();
        public ChuSoHuu getAdminfromDataRow(DataRow row)
        {
            ChuSoHuu admin = new ChuSoHuu();
            admin.ID = int.Parse(row["ID_ChuSoHuu"].ToString());
            admin.Name = row["TenChuSoHuu"].ToString().Trim();
            admin.AdAccount = row["TKAdmin"].ToString().Trim();
            admin.AdPassword = row["PassAdmin"].ToString().Trim();
            return admin;
        }

        public List<ChuSoHuu> getList()
        {
            List<ChuSoHuu> lstAd = new List<ChuSoHuu>();
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from CHUSOHUU");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            for(int i = 0; i<n; i++)
            {
                lstAd.Add(getAdminfromDataRow(table.Rows[i]));
            }
            return lstAd;
        }
        
    }
}
