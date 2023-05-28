using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2115207_DinhTrongHieu_BTH4
{
    public partial class frmChinh : Form
    {
        public QuanLySinhVien qlsv;
        public frmChinh()
        {
            InitializeComponent();
        }
        public void LoadListView(QuanLySinhVien qlsv)
        {
            this.lvSinhVien.Items.Clear();
            int count = qlsv.DSSV.Count;
            foreach (SinhVien sv in qlsv.DSSV)
            {
                ThemSV(sv);
            }
            this.tsslbCount.Text = "Tổng Sinh Viên: " + count;
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.maSV);
            lvitem.SubItems.Add(sv.hoTen);
            string gt = "Nữ";
            if (sv.Phai)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.ngaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.soDT);
            lvitem.SubItems.Add(sv.Email);
           
            lvitem.SubItems.Add(sv.diaChi);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }
        private void ChonHinh_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHinh.Text=openFileDialog1.FileName;
                pbHinh.ImageLocation = openFileDialog1.FileName;
            }
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.maSV = this.mtxtMaSo.Text;
            sv.hoTen = this.txtHoTen.Text;
            if (rdNu.Checked)
                gt = false;
            sv.Phai = gt;
            sv.ngaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cboLop.Text;
            sv.soDT = this.mtSoDT.Text;
            sv.Email = this.txtEmail.Text;
            sv.diaChi = this.txtDiaChi.Text;
            sv.Hinh=this.pbHinh.ImageLocation;
            return sv;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.maSV, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).maSV.CompareTo(obj1.ToString());
            });
            if (kq != null)
                MessageBox.Show("mã sinh viên đã tồn tại!", "lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.qlsv.ThemSV(sv);
                this.LoadListView(this.qlsv);
            }
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.maSV = lvitem.SubItems[0].Text;
            sv.hoTen = lvitem.SubItems[1].Text;
            sv.Phai = false;
            if (lvitem.SubItems[2].Text == "Nam")
                sv.Phai = true;
            sv.ngaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.soDT= lvitem.SubItems[5].Text;
            sv.Email= lvitem.SubItems[6].Text;
            sv.diaChi = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;
            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.maSV;
            this.txtHoTen.Text = sv.hoTen;
            if (sv.Phai)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            this.dtpNgaySinh.Value = sv.ngaySinh;
    
            this.cboLop.Text = sv.Lop;
            this.mtSoDT.Text = sv.soDT;
            this.txtEmail.Text = sv.Email;
            
            this.txtDiaChi.Text = sv.diaChi;
            this.txtHinh.Text=sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;
          
            
        }
        private void XuatThongTinFile()
        {
            string kq="";
            foreach (var sv in this.qlsv.DSSV)
            {
                string temp=((SinhVien)sv).maSV+"*"+ ((SinhVien)sv).hoTen + "*" + ((SinhVien)sv).Phai + "*"+((SinhVien)sv).ngaySinh + "*"+((SinhVien)sv).Lop + "*"+((SinhVien)sv).soDT + "*"+((SinhVien)sv).Email + "*"+((SinhVien)sv).diaChi + "*"+((SinhVien)sv).Hinh;
                kq += temp + "\n";
            }
            File.WriteAllText("DSNV.txt", kq);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("Bạn có muốn lưu thay đổi!", "lưu thay đổi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information); 
            if(result == DialogResult.OK)
            {
                XuatThongTinFile();
                Application.Exit();
            }
            
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.rdNam.Checked = true;
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.mtSoDT.Text = "";
            this.txtEmail.Text = "";
            this.txtDiaChi.Text = "";
            this.pbHinh.ImageLocation = "";
            this.txtHinh.Text = "";
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView(this.qlsv);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);

            }
        }
        private void lvSinhVien_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView(this.qlsv);
            this.btnMacDinh.PerformClick();
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.maSV.CompareTo(obj1);
        }
        private void tảiLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlsv.DSSV.Clear();
            qlsv.DocTuFile();
            this.LoadListView(this.qlsv);
        }
    }
}
