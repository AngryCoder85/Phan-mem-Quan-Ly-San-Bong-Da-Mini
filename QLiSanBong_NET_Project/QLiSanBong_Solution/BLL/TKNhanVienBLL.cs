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
    public class TKNhanVienBLL
    {
        TKNhanVienDAL tkDal = new TKNhanVienDAL();
        QL_NVDAL qlDAL = new QL_NVDAL();
        public bool CheckAccount(string Acc, string Pass)
        {
            List<TKNhanVien> lstTknv = tkDal.blockList(0); 
            if(lstTknv != null)
            {
                for (int i = 0; i < lstTknv.Count; i++)
                {
                    if (Acc == lstTknv[i].Account_NV && Pass == lstTknv[i].Pass_NV)
                        return true;
                }
                return false;
            }
            return false;
            
        }
        public TKNhanVien getAccount(string Acc, string Pass)
        {
            TKNhanVien tk = null;
            List<TKNhanVien> lstTknv = tkDal.blockList(0);
            for (int i = 0; i < lstTknv.Count; i++)
            {
                if (Acc == lstTknv[i].Account_NV && Pass == lstTknv[i].Pass_NV)
                {
                    tk = lstTknv[i];
                    break;
                }
            }
            return tk;
            
        }
        public void UpdateHistory(TKNhanVien tknv)
        {
            try
            {
                qlDAL.Add(tknv);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add(TKNhanVien tknv)
        {
            try
            {
                return tkDal.Add(tknv);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool BlockAccount(TKNhanVien tknv)
        {
            try
            {
                return tkDal.UpdateBlock(tknv);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckTKDK(string pass, string cpass)
        {
            if (pass == cpass)
                return true;
            return false;
        }
        public List<TKNhanVien> getList(int? i)
        {
            if (i == 0)
                return tkDal.blockList(0);
            if (i == 1)
                return tkDal.blockList(1);
            return tkDal.getList();
        }
        public TKNhanVien getTKfromDataRow(DataRow data)
        {
            try
            {
                return tkDal.getTKNVfromDataRow(data);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
