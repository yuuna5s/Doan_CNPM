using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class ThongKeBUS
    {
        public static DataTable Load_DSCTHD()
        {
            return ThongKeDAO.Load_DSCTHD();
        }
        public static DataTable Load_DSCTPN()
        {
            return ThongKeDAO.Load_DSCTPN();
        }
        public static DataTable Load_DSNgayPN(PhieuNhapDTO pn1,PhieuNhapDTO pn2)
        {
            return ThongKeDAO.Load_DSNgayPN(pn1,pn2);
        }
        public static DataTable Load_DSNgayLapHD(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            return ThongKeDAO.Load_DSNgayLapHD(hd1, hd2);
        }
        public static double SumPN()
        {
            return ThongKeDAO.SumCTPN();
        }
        public static double SumHD()
        {
            return ThongKeDAO.SumCTHD();
        }
        public static double SumPN_theongay(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            return ThongKeDAO.SumGTPN_theongay(pn1,pn2);
        }
        public static double SumHD_theongay(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            return ThongKeDAO.SumGTHD_theongay(hd1,hd2);
        }
        public static DataTable Load_DSTheoNgayLapPN(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            return ThongKeDAO.Load_TheoNgayLapPN(pn1, pn2);
        }
        public static DataTable Load_TheoNgayLapHD(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            return ThongKeDAO.Load_TheoNgayLapHD(hd1, hd2);
        }
        public static double SumGTPN()
        {
            return ThongKeDAO.SumGTPN();
        }
        public static double SumGTHD()
        {
            return ThongKeDAO.SumGTHD();
        }
        public static double SumGTPN_theongay(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            return ThongKeDAO.SumGTPN_theongay(pn1, pn2);
        }
        public static double SumGTHD_theongay(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            return ThongKeDAO.SumGTHD_theongay(hd1, hd2);
        }
        public static double SumSL_theongay(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            return ThongKeDAO.SumSL_theongay(pn1, pn2);
        }
        public static double SumCTPN_theoma(PhieuNhapDTO pn1)
        {
            return ThongKeDAO.SumCTPN_TheoMa(pn1);
        }
        public static double SumHD_theoma(HoaDonDTO hd)
        {
            return ThongKeDAO.Sum_MaHD(hd);
        }

        public static double SumPDH_theoma(PhieuDatHangDTO pdh)
        {
            return ThongKeDAO.SumPDH_TheoMa(pdh);
        }
    }
}
