using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLiSanBong_Solution.DTO;
using QLiSanBong_Solution.DAL;

namespace QLiSanBong_Solution.BLL
{
    public class DichVuBLL
    {
        DichVuDAL dvDAL = new DichVuDAL();
        
        public DataTable getList()
        {
            try
            {
                return dvDAL.getList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int getDonGia(int id)
        {
            int dg = new int();
            try
            {
                DataTable tb = dvDAL.getList();
                for(int i=0; i< tb.Rows.Count; i++)
                {
                    DichVu dv = dvDAL.GetDVfromDataRow(tb.Rows[i]);
                    if (dv.ID_DichVu == id)
                    {
                        dg = dv.DonGia;
                        break;
                    }
                }
                return dg;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Add(DichVu dv)
        {
            try
            {
                return dvDAL.Add(dv);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Remove(int id)
        {
            try
            {
                return dvDAL.Remove(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Update(DichVu dv)
        {
            try 
            { 
                return dvDAL.Update(dv); 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
