using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLiSanBong_Solution.BLL;
using QLiSanBong_Solution.DTO;
using QLiSanBong_Solution.GUI;

namespace QLiSanBong_Solution
{
    public partial class EmployeeWorking : Form
    {
        DichVu dvtemp = new DichVu();
        Khach khtemp = new Khach();
        QLTAISAN qltsTemp = new QLTAISAN();
        TKNhanVien tknv = new TKNhanVien();
        KhachBLL khBLL = new KhachBLL();
        LoaiSanBLL lsBLL = new LoaiSanBLL();
        SanBLL sBLL = new SanBLL();
        QuanLyDatSanBLL qldsBLL = new QuanLyDatSanBLL();
        QuanLiDatSan TTDStemp = new QuanLiDatSan();
        TaiSan tsTemp = new TaiSan();
        DichVuBLL dvBLL = new DichVuBLL();
        ThanhToanDichVuBLL ttdvBLL = new ThanhToanDichVuBLL();
        TaiSanBLL tsBLL = new TaiSanBLL();
        QuanLyTaiSanBLL qltsBLL = new QuanLyTaiSanBLL();
        San santemp = new San();

        public EmployeeWorking()
        {
            InitializeComponent();
        }
        public EmployeeWorking(TKNhanVien tk)
        {
            InitializeComponent();
            this.tknv = tk;
        }

        private void EmployeeWorking_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void EmployeeWorking_Load(object sender, EventArgs e)
        {
            getCboKH();
            btnAddKH.Enabled = true;
            btnTinhGio.Enabled = true;
            btnHuySan.Enabled = false;
            getCboLSan();
            dgvDatSan.DataSource = qldsBLL.getList_NullTT();
            dataGrShowDoanhThu.DataSource = qldsBLL.getList_TT();
            //cboDV_S.DisplayMember = "TenDichVu";
            //cboDV_S.ValueMember = "ID_DichVu";
            radTTDV.Checked = true;
            getCboDV();
            dgvTS.DataSource = tsBLL.getList();
            dgvQLTS.DataSource = qltsBLL.getList();
            getCCBOLOAISAN();
            dataGrBangGiaSan.DataSource = sBLL.getList_Combine();
        }
        private void getCboKH()
        {
            cboKH.DataSource = khBLL.GetData();
            cboKH.DisplayMember = "FullInfor";
            cboKH.ValueMember = "SDT";
        }

        private void getCCBOLOAISAN()
        {
            cboLoaiSan.DataSource = lsBLL.GetData();
            cboLoaiSan.DisplayMember = "TenLoai";
            cboLoaiSan.ValueMember = "ID_Loai";
        }

        private void getCboDV()
        {
            cboDV_S.DataSource = dvBLL.getList();
            cboDV_S.DisplayMember = "TenDichVu";
            cboDV_S.ValueMember = "ID_DichVu";

        }
        private void getCboLSan()
        {
            cboLSan.DataSource = lsBLL.GetData();
            cboLSan.DisplayMember = "TenLoai";
            cboLSan.ValueMember = "ID_Loai";
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            AddCustomer f = new AddCustomer();
            this.Hide();
            f.ShowDialog();
            getCboKH();
            this.Show();
        }

        private void btnResetKH_Click(object sender, EventArgs e)
        {
            khBLL.Remove(khtemp);
        }

        private void cboLSan_SelectedValueChanged(object sender, EventArgs e)
        {
            cboSan.DataSource = sBLL.GetDatafromLS(cboLSan.SelectedValue.ToString());
            cboSan.DisplayMember = "ViTriSan";
            cboSan.ValueMember = "ViTriSan";
        }
        private QuanLiDatSan getTTDS()
        {
            QuanLiDatSan getTTDS = TTDStemp;
            return getTTDS;
        }
        private void btnTinhGio_Click(object sender, EventArgs e)
        {
            QuanLiDatSan qlds = new QuanLiDatSan();
            qlds.ID_NhanVien = this.tknv.ID_NV;
            qlds.ID_LoaiSan = cboLSan.SelectedValue.ToString();
            qlds.ViTriSan = cboSan.SelectedValue.ToString();
            qlds.SDT = cboKH.SelectedValue.ToString();
            qlds.ThoiGianBD = datePickStartTime.Value;
            qlds.ThoiGianKT = datePickEndTime.Value;
            double time = getTimePlay(qlds.ThoiGianKT, qlds.ThoiGianBD);
            double money = lsBLL.getDonGia(cboLSan.SelectedValue.ToString()) * time;
            qlds.ThanhToan = (int)money;

            qldsBLL.Add_nullNTT(qlds);
            MessageBox.Show("Đặt sân thành công !!!");
            dgvDatSan.DataSource = qldsBLL.getList_NullTT();
            khtemp = null;
        }

        private double getTimePlay(DateTime thoiGianKT, DateTime thoiGianBD)
        {
            int HH = thoiGianKT.Hour - thoiGianBD.Hour;
            double mm = thoiGianKT.Minute - thoiGianBD.Minute;
            if (mm < 0)
                mm = -mm;
            if (thoiGianKT.Minute < thoiGianBD.Minute)
                HH -= 1;
            double mmH = mm / 60;
            double result = HH + mmH;
            return result;

        }

        private void dgvDatSan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvDatSan.Rows[e.RowIndex];
            TTDStemp.ID_NhanVien = this.tknv.ID_NV;
            TTDStemp.ID_LoaiSan = row.Cells["ID_LoaiSan"].Value.ToString();
            TTDStemp.ViTriSan = row.Cells["ViTriSan"].Value.ToString();
            TTDStemp.SDT = row.Cells["SDT"].Value.ToString();
            TTDStemp.ThoiGianBD = DateTime.Parse(row.Cells["ThoiGianBD"].Value.ToString());
            TTDStemp.ThoiGianKT = DateTime.Parse(row.Cells["ThoiGianKT"].Value.ToString());
            TTDStemp.ThanhToan = int.Parse(row.Cells["ThanhToan"].Value.ToString());
            //TTDStemp.NgayThanhToan = DateTime.Parse(row.Cells["NgayThanhToan"].Value.ToString());
            txtShowTienSan.Text = TTDStemp.ThanhToan.ToString();
        }

        private void btnHuySan_Click(object sender, EventArgs e)
        {
            DialogResult rt = MessageBox.Show("Xóa thông tin đặt sân đang chọn ?", "Hủy đặt sân ?", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if (rt == DialogResult.Yes)
            {
                qldsBLL.RemoveDatSan(getTTDS());
                MessageBox.Show("Hủy sân thành công !!!");
                dgvDatSan.DataSource = qldsBLL.getList_NullTT();
                khtemp = null;
                txtShowTienSan.Clear();
                btnHuySan.Enabled = false;
            }
        }

        private void btnTinhTienSan_Click(object sender, EventArgs e)
        {
            QuanLiDatSan TTDS = getTTDS();
            qldsBLL.Update_TT(TTDS);
            MessageBox.Show("Đã thanh toán !!!");
            dgvDatSan.DataSource = qldsBLL.getList_NullTT();
            dataGrShowDoanhThu.DataSource = qldsBLL.getList_TT();
        }

        private void btnAddDV_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            dv.TenDichVu = cboDV_S.Text;
            dv.DonGia = int.Parse(txtInputDGiaDV.Text);
            dv.SoLuongTonKho = int.Parse(numbrSL.Value.ToString());
            dvBLL.Add(dv);
            dataGrViewDV.DataSource = dvBLL.getList();
            getCboDV();
            MessageBox.Show("SUCCESS");
        }

        private void btnDeleteDV_Click(object sender, EventArgs e)
        {
       
               btnDeleteDV.Enabled = true;
               dvBLL.Remove(int.Parse(cboDV_S.SelectedValue.ToString()));
               dataGrViewDV.DataSource = dvBLL.getList();
               MessageBox.Show("SUCCESS");
               cboDV_S.DataSource = dvBLL.getList();
            
        }

        private void btnUpdateDV_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            dv.ID_DichVu = int.Parse(cboDV_S.SelectedValue.ToString());
            dv.DonGia = int.Parse(txtInputDGiaDV.Text);
            dv.SoLuongTonKho = int.Parse(numbrSL.Value.ToString());
            dvBLL.Update(dv);
            MessageBox.Show("SUCCESS");
            cboDV_S.DataSource = dvBLL.getList();
            dataGrViewDV.DataSource = dvBLL.getList();
        }

        private void btnTTDV_Click(object sender, EventArgs e)
        {
            DialogResult rt = MessageBox.Show("Chắc chắn thanh toán ?", "Xác nhận", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if (rt == DialogResult.Yes)
            {
                ThanhToanDichVu ttdv = getTTDV();
                ttdvBLL.Add(ttdv);
                dataGrViewDV.DataSource = ttdvBLL.getList();
            }
        }

        private ThanhToanDichVu getTTDV()
        {
            ThanhToanDichVu ttdv = new ThanhToanDichVu();
            ttdv.ID_NhanVien = this.tknv.ID_NV;
            ttdv.ID_DichVu = int.Parse(cboDV_S.SelectedValue.ToString());
            ttdv.SoLuong = int.Parse(numbrSL.Value.ToString());
            int TT = dvBLL.getDonGia(int.Parse(cboDV_S.SelectedValue.ToString())) * int.Parse(numbrSL.Value.ToString());
            ttdv.ThanhTien = TT;
            return ttdv;
        }

        private void radTTDV_CheckedChanged(object sender, EventArgs e)
        {
            if (radTTDV.Checked)
            {
                btnAddDV.Enabled = false;
                btnDeleteDV.Enabled = false;
                btnUpdateDV.Enabled = false;
                btnTTDV.Enabled = true;
                label27.Text = "Số lượng";
                cboDV_S.DataSource = dvBLL.getList();
                txtInputDGiaDV.Enabled = false;
                txtThanhTien.Visible = true;
                label16.Visible = true;
                numbrSL.Value = 1;
                dataGrViewDV.DataSource = ttdvBLL.getList();
            }
        }

        private void radDV_CheckedChanged(object sender, EventArgs e)
        {
            if (radDV.Checked)
            {
                btnAddDV.Enabled = true;
                btnDeleteDV.Enabled = true;
                btnUpdateDV.Enabled = true;
                btnTTDV.Enabled = false;
                label27.Text = "Tồn kho";
                cboDV_S.DataSource = dvBLL.getList();
                txtInputDGiaDV.Enabled = true;
                txtThanhTien.Visible = false;
                label16.Visible = false;
                numbrSL.Value = 0;
                dataGrViewDV.DataSource = dvBLL.getList();
            }
        }

        private void numbrSL_ValueChanged(object sender, EventArgs e)
        {
            if(radTTDV.Checked)
            {
                if (numbrSL.Value > 0)
                {
                    int TT = dvBLL.getDonGia(int.Parse(cboDV_S.SelectedValue.ToString())) * int.Parse(numbrSL.Value.ToString());
                    txtThanhTien.Text = TT.ToString();
                }
                else
                {
                    txtThanhTien.Text = "";
                }
            }    
        }

        private int getTienThua()
        {
            QuanLiDatSan ttds = getTTDS();
            int tienKH = int.Parse(txtTienKhDua.Text);
            return tienKH - ttds.ThanhToan;
        }

        private void txtTienKhDua_TextChanged(object sender, EventArgs e)
        {
            txtTienThoi.Text = getTienThua().ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string MM = dtpDoanhThu.Value.Month.ToString();
            string yy = dtpDoanhThu.Value.Year.ToString();
            if (qldsBLL.getDoanhThu(MM, yy) == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu tháng " + MM + "/" + yy);
            }
            else
            {
                dataGrShowDoanhThu.DataSource = qldsBLL.getDoanhThu(MM, yy);
                MessageBox.Show("Doanh thu tháng " + MM + "/" + yy + " là " + qldsBLL.getSumThanhToan(MM, yy).ToString());
            }
        }

        private void btnFullDoanhThu_Click(object sender, EventArgs e)
        {
            dataGrShowDoanhThu.DataSource = qldsBLL.getList_TT();
        }

        private void dgvTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvTS.Rows[e.RowIndex];
            tsTemp.ID_TaiSan = int.Parse(row.Cells["ID_TaiSan"].Value.ToString());
            tsTemp.TenTS = row.Cells["TenTS"].Value.ToString();
            txtTenTS.Text = tsTemp.TenTS;
        }

        private void btnUpdateTS_Click(object sender, EventArgs e)
        {
            TaiSan ts = getTS();
            QLTAISAN qlts = new QLTAISAN();
            qlts.ID_NhanVien = this.tknv.ID_NV;
            qlts.ID_TaiSan = ts.ID_TaiSan;
            qlts.GhiChu = txtGhiChuTS.Text;
            DialogResult rt = MessageBox.Show("Ghi chú tình trạng tài sản này", "Xác nhận", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if(rt == DialogResult.Yes)
            {
                qltsBLL.Add(qlts);
                MessageBox.Show("SUCCESS");
                dgvQLTS.DataSource = qltsBLL.getList();
            }
        }

        private TaiSan getTS()
        {
            return tsTemp;
        }

        private void dgvQLTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvQLTS.Rows[e.RowIndex];
            qltsTemp.ID_NhanVien = this.tknv.ID_NV;
            qltsTemp.ID_TaiSan = int.Parse(row.Cells["ID_TaiSan"].Value.ToString());
            //txtTenTS.Text = row.Cells["TenTS"].Value.ToString();
            qltsTemp.GhiChu = row.Cells["GhiChu"].Value.ToString();
            txtGhiChuTS.Text = qltsTemp.GhiChu;
        }

        private void btnDelNote_Click(object sender, EventArgs e)
        {
            QLTAISAN qlts = getQLTS();
            DialogResult rt = MessageBox.Show("Xóa ghi chú tình trạng tài sản này", "Xác nhận", MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if (rt == DialogResult.Yes)
            {
                qltsBLL.Remove(qlts);
                MessageBox.Show("SUCCESS");
                dgvQLTS.DataSource = qltsBLL.getList();
            }
        }

        private QLTAISAN getQLTS()
        {
            return qltsTemp;
        }

        private void btnDTYear_Click(object sender, EventArgs e)
        {
            string yy = dtpDoanhThu.Value.Year.ToString();
            if (qldsBLL.getDoanhThuNam(yy) == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu năm " + yy);
            }
            else
            {
                dataGrShowDoanhThu.DataSource = qldsBLL.getDoanhThuNam(yy);
                MessageBox.Show("Doanh thu năm " + yy + " là " + qldsBLL.getSumThanhToanYear(yy).ToString());
            }
        }

        private void btnAddBGSan_Click(object sender, EventArgs e)
        {
            San san = new San();
            san.ID_Loai = cboLoaiSan.SelectedValue.ToString();
            san.ViTriSan = txtVTSan.Text;
            sBLL.Add(san);
            dataGrBangGiaSan.DataSource = sBLL.getList_Combine();
            MessageBox.Show("Success");
        }

        private void btnDeleteBGSan_Click(object sender, EventArgs e)
        {
            San san = getSanfrDgv();
            sBLL.Remove(san);
            dataGrBangGiaSan.DataSource = sBLL.getList_Combine();
            MessageBox.Show("Success");
        }

        private San getSanfrDgv()
        {
            return santemp;
        }

        private void dataGrBangGiaSan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrBangGiaSan.Rows[e.RowIndex];
            santemp.ID_Loai = row.Cells["ID_Loai"].Value.ToString();
            santemp.ViTriSan = row.Cells["ViTriSan"].Value.ToString();
        }

        private void btnUpdateDG_Click(object sender, EventArgs e)
        {
            LoaiSan ls = new LoaiSan();
            ls.ID_Loai = cboLoaiSan.SelectedValue.ToString();
            ls.DonGia = int.Parse(txtDonGia.Text);
            lsBLL.Update(ls);
            dataGrBangGiaSan.DataSource = sBLL.getList_Combine();
            MessageBox.Show("Success");
        }

        private void txtShowTienSan_TextChanged(object sender, EventArgs e)
        {
            if (txtShowTienSan.Text.Length > 0)
                btnHuySan.Enabled = true;
        }

        private void dataGrViewDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrViewDV.Rows[e.RowIndex];
            dvtemp.ID_DichVu = int.Parse(row.Cells["ID_DichVu"].Value.ToString());
            dvtemp.TenDichVu = row.Cells["TenDichVu"].Value.ToString();
            dvtemp.DonGia = int.Parse(row.Cells["DonGia"].Value.ToString());
            dvtemp.SoLuongTonKho = int.Parse(row.Cells["SoLuongTonKho"].Value.ToString());
        }
    }
}
