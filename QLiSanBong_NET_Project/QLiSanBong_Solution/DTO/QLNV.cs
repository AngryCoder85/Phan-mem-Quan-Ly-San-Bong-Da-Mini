using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLiSanBong_Solution.DTO
{
    public class QLNV
    {
        public int ID_Admin { get; set; }
        public int ID_NV { get; set; }
        public DateTime GioLam { get; set; }
        public virtual ChuSoHuu Admin { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
