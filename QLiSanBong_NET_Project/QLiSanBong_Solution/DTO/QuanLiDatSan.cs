using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLiSanBong_Solution.DTO
{
    public class QuanLiDatSan
    {
        public int ID_NhanVien { get; set; }
        public string ID_LoaiSan { get; set; }
        public string ViTriSan { get; set; }
        public string SDT { get; set; }
        public DateTime NgayLienHe { get; set; }
        public DateTime ThoiGianBD { get; set; }
        public DateTime ThoiGianKT { get; set; }
        public int ThanhToan { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string GhiChu { get; set; }
    }
}
