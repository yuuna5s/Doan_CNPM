using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public string ma_nv { get; set; }
        public string ten_nv { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public string gioi_tinh { get; set; }
        public string sdt_nv { get; set; }
        public string dia_chi_nv { get; set; }
        public string email { get; set; }
        public string ma_cv { get; set; }
        /// <summary>
        /// tạo constructor
        /// mặt định rỗng
        /// </summary>
        public NhanVienDTO()
        {
            ma_nv = "";
            ten_nv = "";
            day = month = year = 0;
            gioi_tinh = "";
            sdt_nv = "";
            dia_chi_nv = "";
            email = "";
            ma_cv = "";
        }

    }
}
