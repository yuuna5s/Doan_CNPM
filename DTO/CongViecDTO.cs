using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongViecDTO
    {
        public string ma_cv { get; set; }
        public string ten_cv { get; set; }
        public CongViecDTO()
        {
            ma_cv = ten_cv = "";
        }
    }
}
