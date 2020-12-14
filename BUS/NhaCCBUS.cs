using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class NhaCCBUS
    {
        public static DataTable Load_DSNCC()
        {
            return NhaCCDAO.Load_DSNCC();
        }
        public static void Insert_NCC(NhaCCDTO ncc)
        {
            NhaCCDAO.Insert_NCC(ncc);
        }

        public static void Update_NCC(NhaCCDTO ncc)
        {
            NhaCCDAO.Update_NCC(ncc);
        }

        public static void Delete_NCC(NhaCCDTO ncc)
        {
            NhaCCDAO.Delete_NCC(ncc);
        }

        public static DataTable Search_MaNCC(NhaCCDTO ncc)
        {
            return NhaCCDAO.Search_MaNCC(ncc);
        }
        public static DataTable Search_tenNCC(NhaCCDTO ncc)
        {
            return NhaCCDAO.Search_tenNCC(ncc);
        }
    }
}
