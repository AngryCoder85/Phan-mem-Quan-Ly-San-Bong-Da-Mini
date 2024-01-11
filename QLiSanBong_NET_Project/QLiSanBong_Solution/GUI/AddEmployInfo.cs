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
    public partial class AddEmployInfo : Form
    {
        ChuSoHuu admin = new ChuSoHuu();
        NhanVienBLL nvBLL = new NhanVienBLL();
        BoPhanBLL bpBLL = new BoPhanBLL();

        public AddEmployInfo()
        {
            InitializeComponent();
        }
        public AddEmployInfo(ChuSoHuu admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void btnGoToDkiTaiKhoan_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Name = txtDKtenNV.Text;
            nv.ID_BoPhan = int.Parse(cboDKBoPhan.SelectedValue.ToString());
            nv.SDT_NV = txtDKisdtNV.Text;
            nv.CMND = txtDkiCMNDnv.Text;
            string NS = mtxtNgaySinh.Text;
            nv.NgaySinh = DateTime.Parse(NS);
            try
            {
                nvBLL.Add(nv);
                this.Hide();
                AddEmployAccount frmEmpAcc = new AddEmployAccount(nvBLL.getNew(), this.admin);
                frmEmpAcc.Show();
            }
            catch(Exception ex)
            {
                AdminWorking frmAdWork = new AdminWorking();
                frmAdWork.Show();
                this.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEmployInfo_Load(object sender, EventArgs e)
        {
            cboDKBoPhan.DataSource = bpBLL.LoadDataBP();
            cboDKBoPhan.DisplayMember = "TenBoPhan";
            cboDKBoPhan.ValueMember = "ID_BoPhan";
        }
    }
}
