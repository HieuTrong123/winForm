using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2115207_DinhTrongHieu_Lab5
{
    public partial class frmTuyChon : Form
    {
        public frmTuyChon()
        {
            InitializeComponent();
        }
        enum TuyChon
        {
            MaSv,
            HoTen,
            NgaySinh
        }
        TuyChon Kieu;
        public StudentManager qlsv;
        public frmTuyChon(StudentManager qlsv)
        {
            this.qlsv = qlsv;
            InitializeComponent();
        }
       

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmChinh frm = (frmChinh)Application.OpenForms["frmChinh"];
            frm.LoadListView(frm.qlsv);
            this.Close();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            StudentManager nqlsv = new StudentManager();
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
                        nqlsv.DSSV = qlsv.DSSV.FindAll(a => string.Compare(a.MSSV.ToLower(), txtNhapThongTin.Text.ToLower()) == 0);
                        break;
                    case TuyChon.HoTen:
                        nqlsv.DSSV = qlsv.DSSV.FindAll(a => string.Compare(a.Ten.ToLower(), txtNhapThongTin.Text.ToLower()) == 0);
                        break;
                    case TuyChon.NgaySinh:
                        nqlsv.DSSV = qlsv.DSSV.FindAll(a => a.ngaySinh.Day == int.Parse(txtNhapThongTin.Text));
                        break;
                    default:
                        break;
                }

                frmChinh frm = (frmChinh)Application.OpenForms["frmChinh"];
                frm.LoadListView(nqlsv);
                if (nqlsv.DSSV.Count != 0)
                {
                    MessageBox.Show($"Số sinh viên tìm thấy {nqlsv.DSSV.Count}", "", MessageBoxButtons.OK);
                }
            }
        }
    }
}
