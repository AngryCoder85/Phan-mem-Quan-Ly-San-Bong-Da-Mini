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
    public partial class AddEmployAccount : Form
    {
        ChuSoHuu admin = new ChuSoHuu();
        NhanVien NhanVien = new NhanVien();
        TKNhanVienBLL tkBLL = new TKNhanVienBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        public AddEmployAccount()
        {
            InitializeComponent();
        }
        public AddEmployAccount(NhanVien nv, ChuSoHuu admin)
        {
            InitializeComponent();
            NhanVien = nv;
            this.admin = admin;
        }
        public AddEmployAccount(ChuSoHuu admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void btnDKiTK_Click(object sender, EventArgs e)
        {
            TKNhanVien tknv = new TKNhanVien();
            tknv.ID_NV = this.NhanVien.ID;
            tknv.Account_NV = txtDKiTenDN.Text;
            if (tkBLL.CheckTKDK(txtDKmk.Text, txtDKnhapLaiMK.Text))
            {
                tknv.Pass_NV = txtDKmk.Text;
                try
                {
                    tkBLL.Add(tknv);
                    MessageBox.Show("Add USers Success !!!");
                    AdminWorking frmAdWork = new AdminWorking(this.admin);
                    this.Hide();
                    frmAdWork.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error Password !!!");
                txtDKnhapLaiMK.Clear();
            }
        }

        private void btnHuyDK_Click(object sender, EventArgs e)
        {
            NhanVien temp = this.NhanVien;
            nvBLL.Remove(temp);
            this.Close();
            AdminWorking frmAdminWork = new AdminWorking();
            frmAdminWork.Show();
        }

        private void AddEmployAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminWorking frmAdWork = new AdminWorking();
            frmAdWork.Show();
        }
    }
}
