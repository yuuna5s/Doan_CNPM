using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCCDTO
    {
        public string ma_ncc { get; set; }
        public string ten_ncc { get; set; }
        public string sdt_ncc { get; set; }
        public string email { get; set; }

        public NhaCCDTO()
        {
            ma_ncc = ten_ncc = sdt_ncc = email = "";
        }
    }
}
