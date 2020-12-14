using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapDTO
    {
        public string ma_phieu_nhap { get; set; }
        public string ma_nv { get; set; }
        public string ma_ncc { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public double tongtien { get; set; }

        public PhieuNhapDTO()
        {
            ma_phieu_nhap = ma_nv = ma_ncc = "";
            tongtien = year = month = day = 0;
        }
    }
}
