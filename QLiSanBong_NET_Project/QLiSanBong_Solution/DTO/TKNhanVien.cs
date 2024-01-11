using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLiSanBong_Solution.DTO
{
    public class TKNhanVien
    {
        public int ID_NV { get; set;}
        public string Account_NV { get; set; }
        public string Pass_NV { get; set; }
        public int isBlock { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
