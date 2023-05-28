using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2115207_DinhTrongHieu_BTH3
{
    public partial class frmTuyChon : Form
    {
        enum TuyChon
        {
            MaSv,
            HoTen,
            NgaySinh
        }
        string ChuoiTim;
        TuyChon Kieu;
        public QuanLySinhVien qlsv;
        public frmTuyChon()
        {
            InitializeComponent();
        }
        public frmTuyChon(QuanLySinhVien qlsv)
        {
           this.qlsv = qlsv;
           InitializeComponent();
        }
        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (rdhoTen.Checked)
                Kieu = TuyChon.HoTen;
            else if (rdmaSV.Checked)
                Kieu = TuyChon.MaSv;
            else if (rdNgaySinh.Checked)
                Kieu = TuyChon.NgaySinh;
            switch (Kieu)
            {
                case TuyChon.MaSv:
                    qlsv.DanhSach.Sort((a1, a2) =>
                    {
                        if (string.Compare(a1.MaSo, a2.MaSo) > 0)
                            return 1;
                        return -1;
                    });
                    break;
                case TuyChon.HoTen:
                    qlsv.DanhSach.Sort((a1, a2) =>
                    {
                        if (string.Compare(a1.HoTen, a2.HoTen) > 0)
                            return 1;
                        return -1;
                    });
                    break;
                case TuyChon.NgaySinh:
                    qlsv.DanhSach.Sort((a1, a2) =>
                    {
                        if(a1.NgaySinh.Day>a2.NgaySinh.Day)
                            return 1;
                        return -1;
                    });
                    break;
                default:
                    break;
            }
            frmSinhVien frm = (frmSinhVien)Application.OpenForms["frmSinhVien"];
            frm.LoadListView(qlsv);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmSinhVien frm = (frmSinhVien)Application.OpenForms["frmSinhVien"];
            frm.LoadListView(frm.qlsv);
            this.Close();
           
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            QuanLySinhVien nqlsv=new QuanLySinhVien();
            if (txtNhapThongTin.Text == "")
            {
                MessageBox.Show("Hãy nhạp thông tin tìm", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdhoTen.Checked)
                    Kieu = TuyChon.HoTen;
                else if (rdmaSV.Checked)
                    Kieu = TuyChon.MaSv;
                else if (rdNgaySinh.Checked)
                    Kieu = TuyChon.NgaySinh;
                switch (Kieu)
                {

                    case TuyChon.MaSv:
                        nqlsv.DanhSach = qlsv.DanhSach.FindAll(a => string.Compare(a.MaSo.ToLower(), txtNhapThongTin.Text.ToLower()) == 0);
                        break;
                    case TuyChon.HoTen:
                        nqlsv.DanhSach = qlsv.DanhSach.FindAll(a => string.Compare(a.HoTen.ToLower(), txtNhapThongTin.Text.ToLower()) == 0);
                        break;
                    case TuyChon.NgaySinh:
                        nqlsv.DanhSach = qlsv.DanhSach.FindAll(a => a.NgaySinh.Day == int.Parse(txtNhapThongTin.Text));
                        break;
                    default:
                        break;
                }

                frmSinhVien frm = (frmSinhVien)Application.OpenForms["frmSinhVien"];
                frm.LoadListView(nqlsv);
                if (nqlsv.DanhSach.Count != 0)
                {
                    MessageBox.Show($"Số sinh viên tìm thấy {nqlsv.DanhSach.Count}", "", MessageBoxButtons.OK);
                }    
            }
        }

        private void frmTuyChon_Load(object sender, EventArgs e)
        {

        }

        private void rdmaSV_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
