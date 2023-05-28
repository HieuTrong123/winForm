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
    public partial class frmKhachHang : Form
    {
        ConnectSQL conn = new ConnectSQL();
        DataTable dt = new DataTable();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        void LoadCustomer()
        {
            dt.Clear();
            var c = conn.GetConnect();
            string sql = "select * from KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(sql, c);
            c.Open();
            da.Fill(dt);
            c.Close();
            c.Dispose();
            dgvKH.DataSource = dt;
            tsslbCount.Text="Tổng số khách hàng: "+dt.Rows.Count.ToString();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaKH.Text = dgvKH.Rows[index].Cells["MaKH"].Value.ToString();
                txtHoTen.Text = dgvKH.Rows[index].Cells["HoTen"].Value.ToString();
                txtDiaChi.Text = dgvKH.Rows[index].Cells["DiaChi"].Value.ToString();
                mtxtSoDT.Text = dgvKH.Rows[index].Cells["SoDT"].Value.ToString();
                mtxtCMND.Text = dgvKH.Rows[index].Cells["CMND"].Value.ToString();
            }
        }

        public void ResetText()
        {
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            mtxtSoDT.Text = "";
            mtxtCMND.Text = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                var c = conn.GetConnect();
                string sql = "insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (@hoten, @diachi, @sodt, @cmnd)";
                try
                {
                    var cmd = new SqlCommand(sql, c);
                    c.Open();
                    cmd.Parameters.Add("@makh", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    cmd.Parameters.Add("@sodt", SqlDbType.Char).Value = mtxtSoDT.Text;
                    cmd.Parameters.Add("@cmnd", SqlDbType.Char).Value = mtxtCMND.Text;
                    cmd.ExecuteNonQuery();
                    this.ResetText();
                    MessageBox.Show("Succesfully!", "Message");
                    c.Close();
                    LoadCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "Error");
                }
            } 
        }

        public bool CheckData()
        {
            if(string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ và tên!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(mtxtSoDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtSoDT.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
           
            if (string.IsNullOrEmpty(mtxtCMND.Text))
            {
                MessageBox.Show("Bạn chưa nhập CMND!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtxtCMND.Focus();
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var c = conn.GetConnect();
            string sql = "delete from TaiKhoan where MaKH = @makh " +"\n"+
                "delete from KhachHang where MaKH = @makh";
            try
            {
                var kq = MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (kq == DialogResult.OK)
                {
                    var cmd = new SqlCommand(sql, c);
                    c.Open();
                    cmd.Parameters.Add("@makh", SqlDbType.Int).Value = int.Parse(txtMaKH.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully!", "Message");
                    c.Close();
                    this.ResetText();
                    LoadCustomer();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Error");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                var c = conn.GetConnect();
                string sql = "update KhachHang set HoTen = @hoten, DiaChi = @diachi, SDT = @sodt, CMND = @cmnd where MaKH = @makh";
                try
                {
                    var cmd = new SqlCommand(sql, c);
                    c.Open();
                    cmd.Parameters.Add("@makh", SqlDbType.Int).Value = int.Parse(txtMaKH.Text);
                    cmd.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = txtHoTen.Text;
                    cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    cmd.Parameters.Add("@sodt", SqlDbType.Char).Value = mtxtSoDT.Text;
                    cmd.Parameters.Add("@cmnd", SqlDbType.Char).Value = mtxtCMND.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully!", "Message");
                    this.ResetText();
                    c.Close();
                    LoadCustomer();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "Error");
                }
            }
        }


        private void dgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDanhSach frmds = new frmDanhSach(int.Parse(txtMaKH.Text));
            frmds.ShowDialog();
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dt == null) return;
            string filterExpression = "CMND like '%" + txtTimKiem.Text + "%'";
            string sortExpression = "MaKH DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;
            DataView accountView = new DataView(dt, filterExpression, sortExpression, rowStateFilter);
            dgvKH.DataSource = accountView;
        }


        private void sắpXếpTăngTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt == null) return;
            DataView accountView = new DataView();
            this.dgvKH.Sort(this.dgvKH.Columns["HoTen"], ListSortDirection.Ascending);
        }

        private void sắpXếpGiảmTheoMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt == null) return;
            DataView accountView = new DataView();
            this.dgvKH.Sort(this.dgvKH.Columns["HoTen"], ListSortDirection.Descending);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.ResetText();
            txtHoTen.Focus();
        }
    }
}
