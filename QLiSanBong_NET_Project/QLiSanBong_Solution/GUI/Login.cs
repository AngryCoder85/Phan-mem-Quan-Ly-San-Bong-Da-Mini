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
    public partial class Login : Form
    {
        ChuSoHuuBLL adminBLL = new ChuSoHuuBLL();
        TKNhanVienBLL tknvBLL = new TKNhanVienBLL();
        public Login()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // check account admin
            if(chkQuanLy.Checked)
            {
                if(adminBLL.getAccount(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    ChuSoHuu chuSoHuu = adminBLL.getAd(txtTaiKhoan.Text, txtMatKhau.Text);
                    AdminWorking frmAdWork = new AdminWorking(chuSoHuu);
                    this.Hide();
                    frmAdWork.Show();
                }
                else
                {
                    MessageBox.Show("Admin Users Error !!!", "Login Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            else
            {
                if(tknvBLL.CheckAccount(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    TKNhanVien tKNhanVien = tknvBLL.getAccount(txtTaiKhoan.Text, txtMatKhau.Text);
                    tknvBLL.UpdateHistory(tKNhanVien);
                    EmployeeWorking frmEmpWork = new EmployeeWorking(tKNhanVien);
                    frmEmpWork.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Users Error !!!", "Login Failed", MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
        }
    }
}
