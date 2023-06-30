using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiNhom_QLNH
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtMK.Text == "admin" && txtTK.Text == "1")
            {
                frmKhachHang frm=new frmKhachHang();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu","lỗi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtTK.Focus();
            }
        }
        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtMK.Text == "1" && txtTK.Text == "admin")
            {
                frmKhachHang frm = new frmKhachHang();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTK.Focus();
            }
        }
    }
}
