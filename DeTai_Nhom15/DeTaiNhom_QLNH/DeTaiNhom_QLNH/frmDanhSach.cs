using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeTaiNhom_QLNH
{
    public partial class frmDanhSach : Form
    {
        ConnectSQL conn=new ConnectSQL();
        int IDKH;
        public frmDanhSach(int maKH)
        {
            InitializeComponent();
            this.IDKH = maKH;
        }
        public frmDanhSach()
        {
            InitializeComponent();
        }
        public void LoadCategory()
        {
            var c = conn.GetConnect();
            string sql = "select * from LoaiTaiKhoan";
            SqlDataAdapter da = new SqlDataAdapter(sql, c);
            DataTable dt = new DataTable();
            c.Open();
            da.Fill(dt);
            c.Close();
            c.Dispose();
            cboLoai.DataSource = dt;
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
        }

        private void frmDanhSach_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }
        int GetMonth(DateTime a,DateTime b)
        {
            int tinh = 0;
           
            var soThang = b.Month - a.Month;
            var soNam = b.Year - a.Year;
            if (soNam < 0)
            {
                MessageBox.Show("Lỗi năm");
            }
            else if (soNam == 0)
            {
                tinh = b.Month - a.Month;
            }
            else
            {
                tinh = (b.Month + soNam * 12) - a.Month;
            }
            if (tinh < 0)
            {
                tinh = 0;
            }
            return tinh;
        }
        public void LoadListAccount()
        {
            if (cboLoai.SelectedIndex == -1) return;
            var c = conn.GetConnect();
            var cmd = c.CreateCommand();
            string query = "SELECT HoTen FROM KhachHang WHERE MaKH = " + IDKH;
            cmd.CommandText = query;
            c.Open();
            string catName = cmd.ExecuteScalar().ToString();
            this.Text = "Danh sách Tài khoản của: " + catName;
            c.Close();
            cmd.CommandText = "select STK, KhachHang.MaKH, HoTen, DiaChi, SDT, CMND, MaLoai, SoDu, LaiSuat, NgayBD from TaiKhoan, KhachHang " +
                  " where KhachHang.MaKH = TaiKhoan.MaKH and MaLoai = @maloai " +
                  " and KhachHang.MaKH = " + IDKH;
            cmd.Parameters.Add("@maloai", SqlDbType.Int);
            if (cboLoai.SelectedValue is DataRowView)
            {
                DataRowView rowView = cboLoai.SelectedValue as DataRowView;
                cmd.Parameters["@maloai"].Value = rowView["MaLoai"];
            }
            else
            {
                cmd.Parameters["@maloai"].Value = cboLoai.SelectedValue;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            var AccountTable = new DataTable();
            AccountTable.Clear();
            c.Open();
            adapter.Fill(AccountTable);
            c.Close();
            c.Dispose();
            dgvTaiKhoan.DataSource = AccountTable;
            tsslbCount.Text = "Tổng số lượng tài khoản: "+AccountTable.Rows.Count.ToString();
            TinhLai();
        }
        void TinhLai()
        {
            lbltitle.Text = "";
            lblNumble.Text = "";
            double sum = 0;
            for (int i = 0; i < dgvTaiKhoan.Rows.Count; i++)
            {
                if (dgvTaiKhoan.Rows[i].Cells["MaLoai"].Value.ToString() == "1")
                {
                    dgvTaiKhoan.Rows[i].Cells["TienLai"].Value = "0";
                    dgvTaiKhoan.Rows[i].Cells["TienNo"].Value = "0";
                }
                else if (dgvTaiKhoan.Rows[i].Cells["MaLoai"].Value.ToString() == "2")
                {

                    var laiSuat = double.Parse(dgvTaiKhoan.Rows[i].Cells["LaiSuat"].Value.ToString());
                    var SoDu = int.Parse(dgvTaiKhoan.Rows[i].Cells["SoDu"].Value.ToString());
                    var a = DateTime.Parse(dgvTaiKhoan.Rows[i].Cells["NgayBD"].Value.ToString());
                    var b = dtpNgayHT.Value;
                    int tinh = GetMonth(a, b);
                    var kq = (laiSuat * SoDu) * tinh;
                    sum += kq;
                    dgvTaiKhoan.Rows[i].Cells["TienLai"].Value = kq;
                    dgvTaiKhoan.Rows[i].Cells["TienNo"].Value = "0";
                    lbltitle.Text = "Tổng tiền lãi: ";
                    lblNumble.Text = sum.ToString();
                }
                else if (dgvTaiKhoan.Rows[i].Cells["MaLoai"].Value.ToString() == "3")
                {

                    var laiSuat = double.Parse(dgvTaiKhoan.Rows[i].Cells["LaiSuat"].Value.ToString());
                    var SoDu = int.Parse(dgvTaiKhoan.Rows[i].Cells["SoDu"].Value.ToString());
                    var a = DateTime.Parse(dgvTaiKhoan.Rows[i].Cells["NgayBD"].Value.ToString());
                    var b = dtpNgayHT.Value;
                    int tinh = GetMonth(a, b);
                    var kq = (laiSuat * SoDu) * tinh;
                    sum += kq;
                    dgvTaiKhoan.Rows[i].Cells["TienLai"].Value = "0";
                    dgvTaiKhoan.Rows[i].Cells["TienNo"].Value = kq;
                    lbltitle.Text = "Tổng tiền Nợ: ";
                    lblNumble.Text = sum.ToString();
                }
            }
        }
        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frmTK = new frmTaiKhoan();
            frmTK.txtMaKH.Text = IDKH.ToString();
            frmTK.txtMaLoai.Text = (cboLoai.SelectedIndex+1).ToString();
            frmTK.btnSua.Enabled = false;
            frmTK.ShowDialog();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = conn.GetConnect();
            string sql = "delete from TaiKhoan where STK = @stk";
            try
            {
                var kq= MessageBox.Show("Bạn có chắc muốn xóa","Xác nhận",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                if (kq == DialogResult.OK)
                {
                    var cmd = new SqlCommand(sql, c);
                    c.Open();
                    cmd.Parameters.Add("@stk", SqlDbType.Int).Value = int.Parse((dgvTaiKhoan.CurrentRow.Cells[0].Value).ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully!", "Message");
                    c.Close();
                    LoadListAccount();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Error");
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frmTK = new frmTaiKhoan();
            frmTK.btnThem.Enabled=false;
            frmTK.txtSTK.Text = (dgvTaiKhoan.CurrentRow.Cells["STK"].Value).ToString();
            frmTK.txtMaKH.Text = (dgvTaiKhoan.CurrentRow.Cells["MaKH"].Value).ToString();
            frmTK.txtMaLoai.Text = (dgvTaiKhoan.CurrentRow.Cells["MaLoai"].Value).ToString();
            frmTK.txtSoDu.Text = (dgvTaiKhoan.CurrentRow.Cells["SoDu"].Value).ToString();
            frmTK.txtLaiSuat.Text = (dgvTaiKhoan.CurrentRow.Cells["LaiSuat"].Value).ToString();
            frmTK.dtpNgayBD.Value = DateTime.Parse((dgvTaiKhoan.CurrentRow.Cells["NgayBD"].Value).ToString());
            frmTK.ShowDialog();
        }

        private void dtpNgayHT_ValueChanged(object sender, EventArgs e)
        {
            LoadListAccount();
        }
    }
}
