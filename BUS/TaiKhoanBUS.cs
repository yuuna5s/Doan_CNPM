using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class TaiKhoanBUS
    {
        public static void DangKy(TaiKhoanDTO tk)
        {
            TaiKhoanDAO.Insert_TK(tk);
        }
        public static string Dang_nhap(TaiKhoanDTO tk)
        {
            return TaiKhoanDAO.Dang_nhap(tk);
        }
        public static void Dang_xuat(TaiKhoanDTO tk)
        {
            TaiKhoanDAO.Dang_xuat(tk);
        }
    }
}
