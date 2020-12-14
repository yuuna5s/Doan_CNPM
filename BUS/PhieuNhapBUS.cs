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
    public class PhieuNhapBUS
    {
        public static DataTable Load_DSPN()
        {
            return PhieuNhapDAO.Load_DSPN();
        }
        public static DataTable Load_DSCTPN()
        {
            return ChiTietPNDAO.Load_DSCTPN();
        }
        public static DataTable Load_DSMaPN(PhieuNhapDTO pn)
        {
            return ChiTietPNDAO.Load_DSMaPN(pn);
        }
        public static void Update_CTPN(ChiTietPNDTO ctpn)
        {
            ChiTietPNDAO.Update_CTPNSP(ctpn);
        }
        public static DataTable Search_MaPN(PhieuNhapDTO pn)
        {
            return PhieuNhapDAO.Search_MaPN(pn);
        }

        public static DataTable Search_TenNVLPN(NhanVienDTO nv)
        {
            return PhieuNhapDAO.Search_TenNVLPN(nv);
        }
        public static DataTable Search_NgayLPN(PhieuNhapDTO pn)
        {
            return PhieuNhapDAO.Search_NgayLPN(pn);
        }
        public static DataTable Search_NCC(NhaCCDTO ncc)
        {
            return PhieuNhapDAO.Search_NCC(ncc);
        }
        public static void Delete_PN(PhieuNhapDTO pn)
        {
            PhieuNhapDAO.Delete_PN(pn);
        }
        public static void Insert_PN(PhieuNhapDTO pn)
        {
            PhieuNhapDAO.insert_PN(pn);
        }
        public static void Insert_CTPN(ChiTietPNDTO ctpn)
        {
            ChiTietPNDAO.insert_CTPN(ctpn);
        }
        public static void Update_PN(PhieuNhapDTO pn)
        {
            PhieuNhapDAO.update_PN(pn);
        }
        public static void delete_sppn(PhieuNhapDTO pn)
        {
            ChiTietPNDAO.delete_SPPN(pn);
        }
        public static void delete_sppn(SanPhamDTO sp)
        {
            ChiTietPNDAO.delete_SPPN(sp);
        }
        public static void delete_sppn(SanPhamDTO sp, PhieuNhapDTO pn)
        {
            ChiTietPNDAO.delete_SPPN(sp,pn);
        }
    }
}
