using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPhamDTO
    {
        public string ma_loai { get; set; }
        public string ten_loai_sp { get; set; }
        public LoaiSanPhamDTO()
        { ma_loai = ten_loai_sp = ""; }
    }
}
