using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiNhom_QLNH
{
    
    public partial class frmTaiKhoan : Form
    {
        ConnectSQL conn = new ConnectSQL();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        public bool KiemTraDuLieu()
        {
            if(string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ và tên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã loại!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSoDu.Text))
            {
                MessageBox.Show("Bạn chưa nhập số dư!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDu.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLaiSuat.Text))
            {
                MessageBox.Show("Bạn chưa nhập lãi suất!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLaiSuat.Focus();
                return false;
            }
            return true;
        }

        void ResetTextBox()
        {
            txtMaLoai.Text = "";
            txtMaKH.Text = "";
            txtLaiSuat.Text = "";
            txtSoDu.Text = "";
            dtpNgayBD.Value = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(KiemTraDuLieu())
            {
                var c = conn.GetConnect();
                string sql = "insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (@makh, @maloai, @sodu, @laisuat, @ngaybd)";
                try
                {
                    var cmd = new SqlCommand(sql, c);
                    c.Open();
                    cmd.Parameters.Add("@makh", SqlDbType.Int).Value = txtMaKH.Text;
                    cmd.Parameters.Add("@maloai", SqlDbType.NVarChar).Value = txtMaLoai.Text;
                    cmd.Parameters.Add("@sodu", SqlDbType.NVarChar).Value = txtSoDu.Text;
                    cmd.Parameters.Add("@laisuat", SqlDbType.Char).Value = txtLaiSuat.Text;
                    cmd.Parameters.Add("@ngaybd", SqlDbType.DateTime).Value = dtpNgayBD.Value;
                    cmd.ExecuteNonQuery();
                   
                    MessageBox.Show("Succesfully!", "Message");
                    c.Close();
                    frmDanhSach frm = (frmDanhSach)Application.OpenForms["frmDanhSach"];
                    frm.LoadListAccount();
                    this.ResetText();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "Error");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                var c = conn.GetConnect();
                string sql = "update TaiKhoan set MaLoai = @maloai, SoDu = @sodu, LaiSuat = @laisuat, NgayBD = @ngaybd where STK = @stk";
                try
                {
                    var cmd = new SqlCommand(sql, c);
                    c.Open();
                    cmd.Parameters.Add("@stk", SqlDbType.Int).Value = txtSTK.Text;
                    cmd.Parameters.Add("@makh", SqlDbType.Int).Value = txtMaKH.Text;
                    cmd.Parameters.Add("@maloai", SqlDbType.NVarChar).Value = txtMaLoai.Text;
                    cmd.Parameters.Add("@sodu", SqlDbType.NVarChar).Value = txtSoDu.Text;
                    cmd.Parameters.Add("@laisuat", SqlDbType.Char).Value = txtLaiSuat.Text;
                    cmd.Parameters.Add("@ngaybd", SqlDbType.DateTime).Value = dtpNgayBD.Value;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Succesfully!", "Message");
                    c.Close();
                    frmDanhSach frm = (frmDanhSach)Application.OpenForms["frmDanhSach"];
                    frm.LoadListAccount();
                    this.ResetText();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "Error");
                }
            }
        }
    }
}
