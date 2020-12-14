using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public string ma_sp { get; set; }
        public string ma_loai { get; set; }
        public string ten_sp { get; set; }
        public string don_vi_tinh { get; set; }
        public double gia { get; set; }
        public int thoi_gian_bh { get; set; }
        public int soluong { get; set; }
        public string hang_san_xuat { get; set; }

        public SanPhamDTO()
        {
            ma_sp = ma_loai = ten_sp = don_vi_tinh = hang_san_xuat = "";
            gia = thoi_gian_bh = soluong = 0;
        }
    }
}
