using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DTO;
using System.Data;

namespace QLiSanBong_Solution.DAL
{
    public class TKNhanVienDAL
    {
        DataHelper helper = new DataHelper();

        public TKNhanVien getTKNVfromDataRow(DataRow row)
        {
            TKNhanVien tknv = new TKNhanVien();
            tknv.ID_NV = int.Parse(row["ID_NhanVien"].ToString());
            tknv.Account_NV = row["Users"].ToString().Trim();
            tknv.Pass_NV = row["PassUsers"].ToString().Trim();
            tknv.isBlock = int.Parse(row["isBlock"].ToString());
            return tknv;
        }
        public bool Add(TKNhanVien TKNV)
        {
            string query = string.Format("INSERT INTO TKNHANVIEN(ID_NhanVien, Users, PassUsers) values ({0}, '{1}', '{2}')", TKNV.ID_NV, TKNV.Account_NV, TKNV.Pass_NV);

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
        public bool UpdateBlock(TKNhanVien TKNV)
        {
            string query = string.Format("UPDATE TKNHANVIEN SET isBlock = {0} where ID_NhanVien = {1}", TKNV.isBlock, TKNV.ID_NV);

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
        public List<TKNhanVien> blockList(int isBlock)
        {
            List<TKNhanVien> lstAd = new List<TKNhanVien>();
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from TKNhanVien where isBlock = " + isBlock);
            n = table.Rows.Count;

            if (n == 0)
                return null;
            for (int i = 0; i < n; i++)
            {
                lstAd.Add(getTKNVfromDataRow(table.Rows[i]));
            }
            return lstAd;
        }
        public List<TKNhanVien> getList()
        {
            List<TKNhanVien> lstAd = new List<TKNhanVien>();
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("Select * from TKNhanVien");
            n = table.Rows.Count;

            if (n == 0)
                return null;
            for (int i = 0; i < n; i++)
            {
                lstAd.Add(getTKNVfromDataRow(table.Rows[i]));
            }
            return lstAd;
        }
    }
}
