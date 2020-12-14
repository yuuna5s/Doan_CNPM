using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public string ma_hd { get; set; }
        public string ma_nv { get; set; }
        public string ma_kh { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public double dathanhtoan { get; set; }
        public double conlai { get; set; }
        public bool thanhtoan { get; set; }
        public double tonggiatri { get; set; }

        public HoaDonDTO()
        {
            ma_hd = ma_kh = ma_nv = "";
            year = month = day = 0;
            thanhtoan = false;
            tonggiatri = dathanhtoan = conlai = 0;
        }
    }
}
