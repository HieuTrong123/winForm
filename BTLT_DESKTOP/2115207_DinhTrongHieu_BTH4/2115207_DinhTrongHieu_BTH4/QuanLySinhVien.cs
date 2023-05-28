using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace _2115207_DinhTrongHieu_BTH4
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public ArrayList DSSV;
        public QuanLySinhVien()
        {
            DSSV = new ArrayList();
        }
        public void ThemSV(SinhVien sv)
        {
            DSSV.Add(sv);
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = DSSV.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj, DSSV[i]) == 0)
                {
                    this.DSSV.RemoveAt(i);
                }
            }
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DSSV)
            {
                if (ss(obj, sv) == 0)
                {
                    svresult = sv;
                    break;
                }
            }
            return svresult;
        }
        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DSSV.Count - 1;
            for (i = 0; i <= count; i++)
                if (ss(obj, DSSV[i]) == 0)
                {
                    DSSV[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        public void DocTuFile()
        {
            string filename = "DSNV.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.maSV = s[0];
                sv.hoTen = s[1];
                sv.Phai = false;
                if (s[2] == "1")
                {
                    sv.Phai = true;
                }
                sv.ngaySinh = DateTime.Parse(s[3]);
                sv.Lop = s[4];
                sv.soDT=s[5];
                sv.Email=s[6];
                sv.diaChi = s[7];
               sv.Hinh=s[8];
                this.ThemSV(sv);
            }
            sr.Close();
        }
    }
}
