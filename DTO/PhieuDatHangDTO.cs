using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDatHangDTO
    {
        public string ma_pdh { get; set; }
        public string ma_nv { get; set; }
        public string ma_kh { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public double tonggiatri { get; set; }
        public PhieuDatHangDTO()
        {
            tonggiatri = year = month = day = 0;
            ma_kh = ma_nv = ma_pdh = "";
        }

    }
}
