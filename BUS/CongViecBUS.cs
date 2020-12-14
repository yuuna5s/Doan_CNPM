using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;
namespace BUS
{
    public class CongViecBUS
    {
        public static DataTable Load_DSCV()
        {
            return CongViecDAO.Load_DSCV();
        }
    }
}
