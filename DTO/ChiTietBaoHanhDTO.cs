using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietBaoHanhDTO
    {
        public int id { get; set; }
        public string ma_bh { get; set; }
        public string ma_sp { get; set; }
        public string chi_tiet { get; set; }

        public ChiTietBaoHanhDTO()
        {
            id = 0;
            ma_bh = ma_sp = chi_tiet = "";
        }
    }
}
