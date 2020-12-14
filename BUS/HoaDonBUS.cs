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
    public class HoaDonBUS
    {
        public static DataTable Load_DSHD()
        {
            return HoaDonDAO.Load_DSHD();
        }
        public static DataTable Load_DSCTHD()
        {
            return ChiTietHoaDonDAO.Load_DSCTHD();
        }
        public static DataTable Load_DSTheoMaHD(HoaDonDTO hd)
        {
            return ChiTietHoaDonDAO.Load_DSTheoMaHD(hd);
        }
        public static void Delete_HD(HoaDonDTO hd)
        {
            HoaDonDAO.Delete_HD(hd);
        }
        public static void Update_CTHD(ChiTietHoaDonDTO cthd)
        {
            ChiTietHoaDonDAO.Update_CTHD(cthd);
        }
        public static DataTable Search_MaHD(HoaDonDTO hd)
        {
            return HoaDonDAO.Search_MaHD(hd);
        }
        public static DataTable Search_NgayLapHD(HoaDonDTO hd)
        {
            return HoaDonDAO.Search_NgayLapHD(hd);
        }
        public static DataTable Search_TenKHinHD(KhachHangDTO kh)
        {
            return HoaDonDAO.Search_TenKHinHD(kh);
        }
        public static DataTable Search_TenNVLHD(NhanVienDTO nv)
        {
            return HoaDonDAO.Search_TenNVLHD(nv);
        }

        public static void insert_HD(HoaDonDTO hd)
        {
            HoaDonDAO.insert_HD(hd);
        }

        public static void insert_CTHD(ChiTietHoaDonDTO cthd)
        {
            ChiTietHoaDonDAO.insert_CTHD(cthd);
        }
        public static void update_gia(HoaDonDTO hd)
        {
            HoaDonDAO.update_hd(hd);
        }

        public static void delete_sphd(HoaDonDTO hd)
        {
            ChiTietHoaDonDAO.delete_SPHD(hd);
        }

        public static void delete_sphd(SanPhamDTO sp)
        {
            ChiTietHoaDonDAO.delete_SPHD(sp);
        }
        public static void delete_sphd(SanPhamDTO sp, HoaDonDTO hd)
        {
            ChiTietHoaDonDAO.delete_SPHD(sp,hd);
        }
    }
}
