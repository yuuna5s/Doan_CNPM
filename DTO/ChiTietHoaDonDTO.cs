using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        public int id { get; set; }
        public string ma_hd { get; set; }
        public string ma_sp { get; set; }
        public int soluong { get; set; }
        public double thanhtien { get; set; }
        public ChiTietHoaDonDTO()
        {
            ma_hd = ma_sp = "";
            thanhtien = soluong = 0;
        }
    }
}
