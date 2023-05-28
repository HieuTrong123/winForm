using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2115207_DinhTrongHieu_Lab5
{
   
    public class StudentManager
    {
        public List<Student> DSSV;
        public StudentManager()
        {
            DSSV = new List<Student>();
        }
        private void XuatThongTinFile()
        {
            string kq = "";
            foreach (var sv in DSSV)
            {
                string str = "";
                string gt = "2";
                if (sv.GioiTinh)
                    gt = "1";
                for (int i = 0; i < sv.DSMH.Count-1; i++)
                {
                    str += sv.DSMH[i] + ",";
                }
                str += sv.DSMH[sv.DSMH.Count - 1];
                string temp = sv.MSSV + "*" + sv.hoTLot + "*" + sv.Ten + "*" + sv.ngaySinh + "*" + sv.lop + "*" + sv.CMND + "*" + sv.SDT + "*" + sv.diaChi +"*"+gt+ "*"+str;
                
                kq += temp + "\n";
            }
            File.WriteAllText("SinhVien.txt", kq);
        }
        public void ThemSV(Student st)
        {
            DSSV.Add(st);
            XuatThongTinFile();
        }
        public void Xoa(String mssv)
        {
            for(int i = 0; i < DSSV.Count; i++)
            {
                if (string.Compare(mssv, DSSV[i].MSSV) == 0)
                {
                    DSSV.Remove(DSSV[i]);
                }
            }
            XuatThongTinFile();

        }
        public bool Sua(Student svSua,String mssv)
        {
            int i, count;
            bool kq = false;
            count = this.DSSV.Count - 1;
            for (i = 0; i <= count; i++)
                if (string.Compare(DSSV[i].MSSV, mssv) == 0)
                {
                    DSSV[i] = svSua;
                    kq = true;
                    break;
                }
            if (kq)
            {
                XuatThongTinFile();
            }
            return kq;
        }
        public Student Tim(string MSSV)
        {
            Student svresult = null;
            foreach (Student sv in DSSV)
            {
                if (string.Compare(sv.MSSV,MSSV) == 0)
                {
                    svresult = sv;
                    break;
                }
            }
            return svresult;
        }
        public void DocTuFIle()
        {
            string str = "";
            string path = "SinhVien.txt";
            Student st;
            StreamReader rd = new StreamReader(new FileStream(path, FileMode.Open));
            while ((str = rd.ReadLine()) != null)
            {
                var s = str.Split('*');
                st = new Student();
                st.MSSV = s[0];
                st.hoTLot = s[1];
                st.Ten = s[2];
                st.ngaySinh=DateTime.Parse(s[3]);
                st.lop=s[4];
                st.CMND=s[5];
                st.SDT=s[6];
                st.GioiTinh = false;
                if (s[7] == "1")
                    st.GioiTinh = true;
                st.diaChi=s[8];
                var ds=s[9].Split(',');
                foreach (var item in ds)
                {
                    st.DSMH.Add(item);
                }
                DSSV.Add(st);
            }
            rd.Close();
        }
    }
}
