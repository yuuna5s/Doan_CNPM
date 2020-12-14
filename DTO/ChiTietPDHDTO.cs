using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPDHDTO
    {
        public int id { get; set; }
        public string ma_pdh { get; set; }
        public string ma_sp { get; set; }
        public int soluong { get; set; }
        public double thanhtien { get; set; }
        public ChiTietPDHDTO()
        {
            thanhtien = id = soluong = 0;
            ma_pdh = ma_sp = "";
        }
    }
}
