using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLiSanBong_Solution.DTO
{
    public class ThanhToanDichVu
    {
        public int ID_NhanVien { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int ID_DichVu { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
    }
}
