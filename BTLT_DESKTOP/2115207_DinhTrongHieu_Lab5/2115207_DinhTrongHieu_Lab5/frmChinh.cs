using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _2115207_DinhTrongHieu_Lab5
{
    public partial class frmChinh : Form
    {
        StudentInfo st=new StudentInfo();
        public StudentManager qlsv;
        void ThemSV(Student sv)
        {
            ListViewItem lv = new ListViewItem(sv.MSSV);
            lv.SubItems.Add(sv.hoTLot);
            lv.SubItems.Add(sv.Ten);
            lv.SubItems.Add(sv.ngaySinh.ToShortDateString());
            lv.SubItems.Add(sv.lop);
            lv.SubItems.Add(sv.CMND);
            lv.SubItems.Add(sv.SDT);
            lv.SubItems.Add(sv.diaChi);
            if (sv.GioiTinh)
            {
                lv.SubItems.Add("Nam");
            }
            else
            {
                lv.SubItems.Add("Nữ");
            }
            var mh = "";
            foreach (var item in sv.DSMH)
            {
                mh += item;
            }
            lv.SubItems.Add(mh);
           
            lvSinhVien.Items.Add(lv);
           
        }
        public void LoadListView(StudentManager qlsv)
        {
            this.lvSinhVien.Items.Clear();
            int count = qlsv.DSSV.Count;
            foreach (Student sv in qlsv.DSSV)
            {
                ThemSV(sv);
            }
            this.tsslbCount.Text = "Tổng Sinh Viên: " + count;
        }
        public frmChinh()
        {
            InitializeComponent();
        }
        //private void btnJSON_Click(object sender, EventArgs e)
        //{
        //    string Str = ""; // chuỗi lưu trữ
        //    string Path = "JsonExamplejson.json"; // Đường dẫn tập tin
        //    List<StudentInfo> List = st.LoadJSON(Path); // Gọi phương thức
        //    for (int i = 0; i < List.Count; i++) // Đọc danh sách
        //    {
        //        StudentInfo info = List[i];
        //        Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2},điểm TB: {3}\r\n", (i + 1), info.MSSV, info.Hoten, info.Diem);
        //    }
        //    MessageBox.Show(Str);
        //}
        //private void btnXML_Click(object sender, EventArgs e)
        //{
        //    string str = "";
        //    var xmlDoc = new XmlDocument();
        //    xmlDoc.Load("books.xml");
        //    // Get list of nodes whose name is Book
        //    var nodeList = xmlDoc.DocumentElement.SelectNodes("/catalog/book");
        //    foreach (XmlNode node in nodeList)
        //    {
        //        // Read attribute value
        //        var isbn = node.Attributes["ISBN"].Value;
        //        // Read child node value
        //        var title = node.SelectSingleNode("title").InnerText;
        //        var price = node.SelectSingleNode("price").InnerText;
        //        // Read the descendant node value
        //        var firstName = node.SelectSingleNode("author/first-name").InnerText;
        //        var lastName = node.SelectSingleNode("author/last-name").InnerText;
        //       str+= string.Format("{0,-15}{1,-50}{2,-15}{3,-15}{4,6}",
        //        isbn, title, firstName, lastName, price);
        //    }
        //    MessageBox.Show(str);
        //}
        void ThietKapThongTin(Student sv)
        {
            this.mtxtMSSV.Text = sv.MSSV ;
            this.txtHovaTLot.Text = sv.hoTLot;
            this.txtTen.Text = sv.Ten;
            this.dtNgaySinh.Value = sv.ngaySinh;
            this.cbLop.Text = sv.lop;
            this.mtxtCMND.Text = sv.CMND;
            this.mtxtSoDT.Text = sv.SDT;
            rdNu.Checked = true;
            if (sv.GioiTinh)
            {
                rdNam.Checked = true;
            }
            this.txtDiaCHi.Text = sv.diaChi;
        }
        Student GetSinhVienLV(ListViewItem lv)
        {
            Student sv=new Student();
            sv.MSSV = lv.SubItems[0].Text;
            sv.hoTLot = lv.SubItems[1].Text;
            sv.Ten = lv.SubItems[2].Text;
            sv.ngaySinh = DateTime.Parse(lv.SubItems[3].Text);
            sv.lop = lv.SubItems[4].Text;
            sv.CMND = lv.SubItems[5].Text;
            sv.SDT=lv.SubItems[6].Text;
            sv.diaChi=lv.SubItems[7].Text;
            if (lv.SubItems[8].Text == "Nam")
            {
                sv.GioiTinh = true;
            }
            else
            {
                sv.GioiTinh=false;
            }
            var mh=(lv.SubItems[9].ToString()).Split(',');
            foreach (var item in mh)
            {
                sv.DSMH.Add(item);
            }
            return sv;
        }
        Student GetSinhVien()
        {
            Student sv = new Student();
            sv.MSSV = this.mtxtMSSV.Text;
            sv.hoTLot = this.txtHovaTLot.Text;
            sv.Ten=this.txtTen.Text;
            sv.ngaySinh=this.dtNgaySinh.Value;
            sv.lop = this.cbLop.Text;
            sv.CMND = this.mtxtCMND.Text;
            sv.SDT = this.mtxtSoDT.Text;
            sv.diaChi=this.txtDiaCHi.Text;
            sv.GioiTinh = false;
            if(rdNam.Checked)
                sv.GioiTinh=true;
            List<string> mh = new List<string>();
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                if (clbMonHoc.GetItemChecked(i))
                {
                    mh.Add(clbMonHoc.Items[i].ToString());
                }
            }
            sv.DSMH = mh;
            return sv;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            var kq= MessageBox.Show("bạn có muốn lưu thông tin đã thay đổi","save file txt",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if(kq==DialogResult.OK)
                Application.Exit();
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            qlsv=new StudentManager();
            qlsv.DocTuFIle();
            LoadListView(qlsv);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Student sv = GetSinhVien();
            Student kq = qlsv.Tim(sv.MSSV);
            if(kq != null)
                MessageBox.Show("Sinh viên đã tồn tại","lỗi!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                qlsv.ThemSV(sv);
                LoadListView(qlsv);
            }
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            frmTuyChon frm=new frmTuyChon(qlsv);
            frm.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Student sv = GetSinhVien();
            bool kqsua = false;
            kqsua = qlsv.Sua(sv,sv.MSSV);
            if (kqsua)
            {
                this.LoadListView(this.qlsv);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count=lvSinhVien.SelectedItems.Count;
            if(count > 0)
            {
                ListViewItem lv=lvSinhVien.SelectedItems[0];
                Student sv=GetSinhVienLV(lv);
                ThietKapThongTin(sv);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lvSinhVien.Items.Count; i++)
            {
                if (lvSinhVien.Items[i].Checked)
                {
                    qlsv.Xoa(lvSinhVien.Items[i].Text);

                }
            }
            LoadListView(qlsv);
        }
    }
}
