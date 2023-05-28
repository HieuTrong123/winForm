using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2115207_DinhTrongHieu_Lab5
{
    public class Student
    {
        public string MSSV { get; set; }
        public string hoTLot { get; set; }
        public string Ten { get; set; }
        public DateTime ngaySinh { get; set; }
        public string lop { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public bool GioiTinh { get; set; }
        public string diaChi { get; set; }
        public List<string> DSMH { get; set;}
       public Student()
        {
            DSMH = new List<string>();
        }
    }
}
