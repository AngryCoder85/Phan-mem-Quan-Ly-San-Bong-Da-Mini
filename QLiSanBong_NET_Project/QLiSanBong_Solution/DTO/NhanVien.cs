using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLiSanBong_Solution.DTO
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_BoPhan { get; set; }
        public string SDT_NV { get; set; }
        public string CMND { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayBDLam { get; set; }
    }
}
