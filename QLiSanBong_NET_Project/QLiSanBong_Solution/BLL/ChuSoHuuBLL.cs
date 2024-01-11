using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLiSanBong_Solution.DAL;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution.BLL
{
    public class ChuSoHuuBLL
    {
        AdminDAL adDal = new AdminDAL();

        public bool getAccount(string Acc, string Pass)
        {
            List<ChuSoHuu> lstAd = adDal.getList();
            for (int i = 0; i < lstAd.Count; i++)
            {
                if (Acc == lstAd[i].AdAccount && Pass == lstAd[i].AdPassword)
                    return true;
            }
            return false;
        }
        public ChuSoHuu getAd(string Acc, string Pass)
        {
            ChuSoHuu admin = null;
            List<ChuSoHuu> lstAd = adDal.getList();
            for (int i = 0; i < lstAd.Count; i++)
            {
                if (Acc == lstAd[i].AdAccount && Pass == lstAd[i].AdPassword)
                    admin = lstAd[i];
            }
            return admin;
        }
    }
}
