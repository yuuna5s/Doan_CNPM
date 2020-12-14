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
    public class KhachHangBUS
    {
        public static DataTable Load_DSKH()
        {
            return KhachHangDAO.Load_DSKH();
        }
        public static void Insert_KH(KhachHangDTO kh)
        {
            KhachHangDAO.Insert_KH(kh);
        }
        public static void Update_KH(KhachHangDTO kh)
        {
            KhachHangDAO.Update_KH(kh);
        }
        public static void Delete_KH(KhachHangDTO kh)
        {
            KhachHangDAO.Delete_KH(kh);
        }

        public static DataTable Search_MaKH(KhachHangDTO kh)
        {
            return KhachHangDAO.Search_MaKH(kh);
        }

        public static DataTable Serch_TenKH(KhachHangDTO kh)
        {
            return KhachHangDAO.Search_TenKH(kh);
        }

        public static KhachHangDTO Search_KH(String makh)
        {
            return KhachHangDAO.Search_KH(makh);
        }
    }
}
