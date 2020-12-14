using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public string ma_kh { get; set; }
        public string ten_kh { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public KhachHangDTO()
        {
            ma_kh = ten_kh = diachi = sdt = "";
        }
    }
}
