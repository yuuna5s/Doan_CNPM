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
    public class SanPhamBUS
    {
        public static DataTable Load_DSSP()
        {
            return SanPhamDAO.Load_DSSP();
        }
        public static void Insert_SP(SanPhamDTO sp)
        {
            SanPhamDAO.Insert_SP(sp);
        }

        public static void Update_SP(SanPhamDTO sp)
        {
            SanPhamDAO.Update_SP(sp);
        }
        public static void Delete_SP(SanPhamDTO sp)
        {
            SanPhamDAO.Delete_SP(sp);
        }
        public static DataTable Search_MaSP(SanPhamDTO sp)
        {
            return SanPhamDAO.Search_MaSP(sp);
        }
        public static DataTable Search_HSXSP(SanPhamDTO sp)
        {
            return SanPhamDAO.Search_HangSXSP(sp);
        }
        public static DataTable Search_LoaiSP(LoaiSanPhamDTO loaisp)
        {
            return SanPhamDAO.Search_LoaiSP(loaisp);
        }
        public static DataTable Search_TenSP(SanPhamDTO sp)
        {
            return SanPhamDAO.Search_TenSP(sp);
        }

        public static SanPhamDTO Search_SP(string masp)
        {
            return SanPhamDAO.Search_SP(masp);
        }

    }
}
