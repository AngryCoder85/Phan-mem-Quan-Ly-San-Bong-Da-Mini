using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLiSanBong_Solution.BLL;
using QLiSanBong_Solution.DTO;

namespace QLiSanBong_Solution
{
    public partial class AdminWorking : Form
    {
        ThanhToanDichVuBLL ttdvBLL = new ThanhToanDichVuBLL();
        QuanLyDatSanBLL qldsBLL = new QuanLyDatSanBLL();
        QuanLiDatSan TTDStemp = new QuanLiDatSan();
        ChuSoHuu admin = new ChuSoHuu();
        TKNhanVienBLL tkBLL = new TKNhanVienBLL();
        TKNhanVien nvtemp = new TKNhanVien();
        public AdminWorking()
        {
            InitializeComponent();
        }
        public AdminWorking(ChuSoHuu admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEmployInfo frmAddInf = new AddEmployInfo(this.admin);
            frmAddInf.Show();
        }

        private void AdminWorking_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnKhoaTK_Click(object sender, EventArgs e)
        {
            TKNhanVien tkblock = nvtemp;
            if(tkblock.isBlock == 1)
            {
                MessageBox.Show("Tài khoản đang bị khóa");
                return;
            }
            else
            {
                tkblock.isBlock = 1;
                tkBLL.BlockAccount(tkblock);
                dataGrViewDsNhanVien.DataSource = tkBLL.getList(null);
                MessageBox.Show("Tài khoản " + tkblock.Account_NV + " đã được khóa");
                return;
            }    
           
        }

        private void AdminWorking_Load(object sender, EventArgs e)
        {
            dataGrViewDsNhanVien.DataSource = tkBLL.getList(null);
            dataGrViewDoanhThu.DataSource = qldsBLL.getList_TT();
            dataGrDThuDV.DataSource = ttdvBLL.getList();
        }

        private void dataGrViewDsNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrViewDsNhanVien.Rows[e.RowIndex];
            nvtemp.ID_NV = (int)row.Cells["ID_NV"].Value;
            nvtemp.Account_NV = row.Cells["Account_NV"].Value.ToString();
            nvtemp.Pass_NV = row.Cells["Pass_NV"].Value.ToString();
            nvtemp.isBlock = (int)row.Cells["isBlock"].Value;
        }

        private void btnMoKhoaTK_Click(object sender, EventArgs e)
        {
            TKNhanVien tkblock = nvtemp;
            if(tkblock.isBlock == 0)
            {
                MessageBox.Show("Tài khoản đang hoạt động");
                return;
            }
            else
            {
                tkblock.isBlock = 0;
                tkBLL.BlockAccount(tkblock);
                dataGrViewDsNhanVien.DataSource = tkBLL.getList(null);
                MessageBox.Show("Tài khoản " + tkblock.Account_NV + " đã được mở khóa");
                return;
            }    
        }

        private void btnShowDSTKkhoa_Click(object sender, EventArgs e)
        {
            if(tkBLL.getList(1) == null)
            {
                MessageBox.Show("Không tồn tại tài khoản đang bị khóa");
                return;
            }
            dataGrViewDsNhanVien.DataSource = tkBLL.getList(1);
        }

        private void btnShowDSTKHoatDong_Click(object sender, EventArgs e)
        {
            if (tkBLL.getList(0) == null)
            {
                MessageBox.Show("Không tồn tại tài khoản đang hoạt động");
                return;
            }
            dataGrViewDsNhanVien.DataSource = tkBLL.getList(0);
        }

        private void btnXemDTSAN_Click(object sender, EventArgs e)
        {
            string MM = dtpDTSan.Value.Month.ToString();
            string yy = dtpDTSan.Value.Year.ToString();
            if (qldsBLL.getDoanhThu(MM, yy) == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu tháng " + MM + "/" + yy);
            }
            else
            {
                dataGrViewDoanhThu.DataSource = qldsBLL.getDoanhThu(MM, yy);
                MessageBox.Show("Doanh thu tháng " + MM + "/" + yy + " là " + qldsBLL.getSumThanhToan(MM, yy).ToString());
            }
        }

        private void btnYearDT_Click(object sender, EventArgs e)
        {
            string yy = dtpDTSan.Value.Year.ToString();
            if (qldsBLL.getDoanhThuNam(yy) == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu năm " + yy);
            }
            else
            {
                dataGrViewDoanhThu.DataSource = qldsBLL.getDoanhThuNam(yy);
                MessageBox.Show("Doanh thu năm " + yy + " là " + qldsBLL.getSumThanhToanYear(yy).ToString());
            }
        }

        private void btnMACDINH_Click(object sender, EventArgs e)
        {
            dataGrViewDoanhThu.DataSource = qldsBLL.getList_TT();
        }

        private void dataGrViewDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrViewDoanhThu.Rows[e.RowIndex];
            TTDStemp.ID_LoaiSan = row.Cells["ID_LoaiSan"].Value.ToString();
            TTDStemp.ViTriSan = row.Cells["ViTriSan"].Value.ToString();
            TTDStemp.SDT = row.Cells["SDT"].Value.ToString();
            TTDStemp.ThoiGianBD = DateTime.Parse(row.Cells["ThoiGianBD"].Value.ToString());
            TTDStemp.ThoiGianKT = DateTime.Parse(row.Cells["ThoiGianKT"].Value.ToString());
            TTDStemp.ThanhToan = int.Parse(row.Cells["ThanhToan"].Value.ToString());
        }

        private void btnDeleteDTSAN_Click(object sender, EventArgs e)
        {
            QuanLiDatSan qlds = getQLDS();
            qldsBLL.RemoveDatSan(qlds);
            dataGrViewDoanhThu.DataSource = qldsBLL.getList_TT();
            MessageBox.Show("SUCCESS");
        }

        private QuanLiDatSan getQLDS()
        {
            return TTDStemp;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string MM = dtpDoanhThuDV.Value.Month.ToString();
            string yy = dtpDoanhThuDV.Value.Year.ToString();
            if (ttdvBLL.getList_MMyy(MM, yy) == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu tháng " + MM + "/" + yy);
            }
            else
            {
                dataGrDThuDV.DataSource = ttdvBLL.getList_MMyy(MM, yy);
                MessageBox.Show("Doanh thu tháng " + MM + "/" + yy + " là " + ttdvBLL.SumDTDV_MMyy(MM, yy).ToString());
            }
        }

        private void btnYearDV_Click(object sender, EventArgs e)
        {
            string yy = dtpDoanhThuDV.Value.Year.ToString();
            if (ttdvBLL.getList_yy(yy) == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu năm " + yy);
            }
            else
            {
                dataGrDThuDV.DataSource = ttdvBLL.getList_yy(yy);
                MessageBox.Show("Doanh thu năm " + yy + " là " + ttdvBLL.SumDTDV_yy(yy).ToString());
            }
        }

        private void btnMacDinhDV_Click(object sender, EventArgs e)
        {
            dataGrDThuDV.DataSource = ttdvBLL.getList();
        }

        private void btnFullTK_Click(object sender, EventArgs e)
        {
            dataGrViewDsNhanVien.DataSource = tkBLL.getList(null);
        }
    }
}
