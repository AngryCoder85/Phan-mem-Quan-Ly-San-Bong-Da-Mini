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

namespace QLiSanBong_Solution.GUI
{
    public partial class AddCustomer : Form
    {
        KhachBLL khBLL = new KhachBLL();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddKH_Click(object sender, EventArgs e)
        {
            Khach kh = new Khach();
            kh.SDT = txtSDTKH.Text;
            kh.HoTen = txtNameKH.Text;
            if (khBLL.isDupKey(kh.SDT))
            {
                MessageBox.Show("Tồn tại SĐT !!!");
                return;
            }
            else
            {
                khBLL.Add(kh);
                this.Close();
            }
        }
    }
}
