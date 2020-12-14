using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string ma_cv { get; set; }
        public bool trang_thai { get; set; }

        public TaiKhoanDTO()
        {
            ID = 0;
            username = password = ma_cv = "";
            trang_thai = false;
        }
    }
}
