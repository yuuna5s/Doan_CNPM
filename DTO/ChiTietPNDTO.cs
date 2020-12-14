using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPNDTO
    {
        public int id { get; set; }
        public string ma_phieu_nhap { get; set; }
        public string ma_sp { get; set; }
        public int soluong { get; set; }
        public double gianhap { get; set; }
        public double tong { get; set; }
        public ChiTietPNDTO()
        {
            ma_phieu_nhap = ma_sp = "";
            gianhap = tong = id = soluong = 0;
        }
    }
}
