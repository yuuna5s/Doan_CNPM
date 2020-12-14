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
    public class PhieuDatHangBUS
    {
        public static DataTable Load_DSPDH()
        {
            return PhieuDatHangDAO.Load_DSPDH();
        }
        public static DataTable Load_DSCTPDH()
        {
            return ChiTietPhieuDatHangDAO.Load_DSCTPDH();
        }
        public static void Insert_PDH(PhieuDatHangDTO pdh)
        {
            PhieuDatHangDAO.Insert_PDH(pdh);
        }
        public static void Update_gia(PhieuDatHangDTO pdh)
        {
            PhieuDatHangDAO.update_Gia(pdh);
        }
        public static void Delete_PDH(PhieuDatHangDTO pdh)
        {
            PhieuDatHangDAO.Delete_PDH(pdh);
        }
        public static DataTable Load_DSTheoMaPDH(PhieuDatHangDTO pdh)
        {
            return ChiTietPhieuDatHangDAO.Load_DSTheoMaPDH(pdh);
        }
        public static void Update_CTPDH(ChiTietPDHDTO ctpdh)
        {
            ChiTietPhieuDatHangDAO.Update_CTPDH(ctpdh);
        }

        public static DataTable Search_Ma(PhieuDatHangDTO pdh)
        {
            return PhieuDatHangDAO.Search_Ma(pdh);
        }
        public static DataTable Search_NgayLPDH(PhieuDatHangDTO pdh)
        {
            return PhieuDatHangDAO.Search_NgayLPDH(pdh);
        }
        public static DataTable Search_TenKH(KhachHangDTO kh)
        {
            return PhieuDatHangDAO.Search_TenKH(kh);
        }
        public static DataTable Search_TenNVLPDH(NhanVienDTO nv)
        {
            return PhieuDatHangDAO.Search_TenNVLPDH(nv);
        }
        public static void insert_CTPDH(ChiTietPDHDTO ctpdh)
        {
            ChiTietPhieuDatHangDAO.Insert_CTPDH(ctpdh);
        }
        public static void delete_sppdh(PhieuDatHangDTO pdh)
        {
            ChiTietPhieuDatHangDAO.delete_SPPDH(pdh);
        }
        public static void delete_sppdh(SanPhamDTO sp)
        {
            ChiTietPhieuDatHangDAO.delete_SPPDH(sp);
        }

        public static void delete_sppdh(SanPhamDTO sp, PhieuDatHangDTO pdh)
        {
            ChiTietPhieuDatHangDAO.delete_SPPDH(sp,pdh);
        }
    }
}
