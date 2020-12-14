using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using MySqlConnector;
namespace DAO
{
    public class ThongKeDAO
    {
        static MySqlConnection cnn = null;
        public static DataTable Load_DSCTHD()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT db_sanpham.ma_sp as 'Mã sản phẩm',db_sanpham.ten_sp as 'Tên sản phẩm',db_hoa_don.ngay_lap as 'Ngày bán',so_luong as 'Số lượng',db_sanpham.gia_sp as 'Giá',thanh_tien as 'Tổng' FROM chi_tiet_hd inner join db_sanpham on chi_tiet_hd.ma_sp = db_sanpham.ma_sp inner join db_hoa_don on chi_tiet_hd.ma_hd = db_hoa_don.ma_hd";
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Load_DSCTPN()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT db_sanpham.ma_sp as 'Mã sản phẩm',db_sanpham.ten_sp as 'Tên sản phẩm',so_luong as 'Số lượng',db_phieu_nhap.ngay_lap_pn as 'Ngày nhập',gianhap as 'Giá nhập',tong as 'Tổng tiền' FROM db_chi_tiet_pn inner join db_phieu_nhap on db_chi_tiet_pn.ma_phieu_nhap = db_phieu_nhap.ma_phieu_nhap inner join db_sanpham on db_chi_tiet_pn.ma_sp = db_sanpham.ma_sp";
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Xem DS nhập theo ngày
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSNgayPN(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT db_sanpham.ma_sp as 'Mã sản phẩm',db_sanpham.ten_sp as 'Tên sản phẩm',so_luong as 'Số lượng',db_phieu_nhap.ngay_lap_pn as 'Ngày nhập',gianhap as 'Giá nhập',tong as 'Tổng tiền' FROM db_chi_tiet_pn inner join db_phieu_nhap on db_chi_tiet_pn.ma_phieu_nhap = db_phieu_nhap.ma_phieu_nhap inner join db_sanpham on db_chi_tiet_pn.ma_sp = db_sanpham.ma_sp WHERE db_phieu_nhap.ngay_lap_pn between '{0}/{1}/{2}' and '{3}/{4}/{5}'",pn1.year,pn1.month,pn1.day,pn2.year,pn2.month,pn2.day);
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// load ds san phẩm bán ra theo ngày
        /// </summary>
        /// <param name="hd1"></param>
        /// <param name="hd2"></param>
        /// <returns></returns>
        public static DataTable Load_DSNgayLapHD(HoaDonDTO hd1,HoaDonDTO hd2)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT db_sanpham.ma_sp as 'Mã sản phẩm',db_sanpham.ten_sp as 'Tên sản phẩm',db_hoa_don.ngay_lap as 'Ngày bán',so_luong as 'Số lượng',db_sanpham.gia_sp as 'Giá',thanh_tien as 'Tổng' FROM chi_tiet_hd inner join db_sanpham on chi_tiet_hd.ma_sp = db_sanpham.ma_sp inner join db_hoa_don on chi_tiet_hd.ma_hd = db_hoa_don.ma_hd WHERE db_hoa_don.ngay_lap between '{0}/{1}/{2}' and '{3}/{4}/{5}'",hd1.year,hd1.month,hd1.day,hd2.year,hd2.month,hd2.day);
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static double Sum(string str)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                MySqlCommand cmd = new MySqlCommand(str, cnn);
                if (cmd.ExecuteScalar().ToString() == "")
                    return 0;
                return double.Parse(cmd.ExecuteScalar().ToString());
                    
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double SumCTPN()
        {
            try
            {
                string select = "SELECT SUM(tong) FROM db_chi_tiet_pn";
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double SumCTHD()
        {
            try
            {
                string select = "SELECT SUM(thanh_tien) FROM chi_tiet_hd";
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double Sum_MaHD(HoaDonDTO hd)
        {
            try
            {
                string select = string.Format("SELECT SUM(thanh_tien) FROM chi_tiet_hd WHERE ma_hd = '{0}';", hd.ma_hd);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double SumCTHD_theongay(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            try
            {
                string select = string.Format("SELECT SUM(thanh_tien) FROM chi_tiet_hd inner join db_hoa_don on chi_tiet_hd.ma_hd = db_hoa_don.ma_hd WHERE db_hoa_don.ngay_lap between '{0}/{1}/{2}' and '{3}/{4}/{5}'", hd1.year, hd1.month, hd1.day, hd2.year, hd2.month, hd2.day);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double SumCTPN_theongay(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            try
            {
                string select = string.Format("SELECT SUM(tong) FROM db_chi_tiet_pn inner join db_phieu_nhap on db_chi_tiet_pn.ma_phieu_nhap = db_phieu_nhap.ma_phieu_nhap WHERE db_phieu_nhap.ngay_lap_pn between '{0}/{1}/{2}' and '{3}/{4}/{5}'", pn1.year, pn1.month, pn1.day, pn2.year, pn2.month, pn2.day);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double SumCTPN_TheoMa(PhieuNhapDTO pn1)
        {
            try
            {
                string select = string.Format("SELECT SUM(tong) FROM db_chi_tiet_pn WHERE ma_phieu_nhap ='{0}';",pn1.ma_phieu_nhap);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double SumPDH_TheoMa(PhieuDatHangDTO pdh)
        {
            try
            {
                string select = string.Format("SELECT SUM(thanhtien) FROM chi_tiet_pdh WHERE ma_pdh ='{0}';", pdh.ma_pdh);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// load ds phieu nhap theo ngay
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_TheoNgayLapPN(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_phieu_nhap,db_nhanvien.ten_nv,db_nha_cung_cap.ten_ncc,ngay_lap_pn,tong_tien FROM db_phieu_nhap inner join db_nhanvien on db_phieu_nhap.ma_nv = db_nhanvien.ma_nv inner join db_nha_cung_cap on db_phieu_nhap.ma_ncc = db_nha_cung_cap.ma_ncc WHERE ngay_lap_pn between '{0}/{1}/{2}' and '{3}/{4}/{5}'", pn1.year, pn1.month, pn1.day, pn2.year, pn2.month, pn2.day);
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// load danh sach theo ngay lap hoa don
        /// </summary>
        /// <param name="hd1"></param>
        /// <param name="hd2"></param>
        /// <returns></returns>
        public static DataTable Load_TheoNgayLapHD(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_hd,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,da_thanh_toan,con_lai,tonggiatri,thanh_toan FROM  db_hoa_don inner join db_nhanvien on db_hoa_don.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_hoa_don.ma_kh = db_khach_hang.ma_kh WHERE ngay_lap between '{0}/{1}/{2}' and '{3}/{4}/{5}'",hd1.year,hd1.month,hd1.day,hd2.year,hd2.month,hd2.day);
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tong gia tri cac phieu nhap
        /// </summary>
        /// <param name="pn1"></param>
        /// <param name="pn2"></param>
        /// <returns></returns>
        public static double SumGTPN()
        {
            try
            {
                string select = "SELECT SUM(tong_tien) FROM db_phieu_nhap";
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tong gia tri cac hoa don
        /// </summary>
        /// <returns></returns>
        public static double SumGTHD()
        {
            try
            {
                string select = "SELECT SUM(tonggiatri) FROM db_hoa_don";
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tong gia tri hoa don va phieu nhap theo ngay
        /// </summary>
        /// <param name="hd1"></param>
        /// <param name="hd2"></param>
        /// <returns></returns>
        public static double SumGTHD_theongay(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            try
            {
                string select = string.Format("SELECT SUM(tonggiatri) FROM db_hoa_don WHERE ngay_lap between '{0}/{1}/{2}' and '{3}/{4}/{5}'", hd1.year, hd1.month, hd1.day, hd2.year, hd2.month, hd2.day);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static double SumGTPN_theongay(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            try
            {
                string select = string.Format("SELECT SUM(tong_tien) FROM db_phieu_nhap WHERE ngay_lap_pn between '{0}/{1}/{2}' and '{3}/{4}/{5}'", pn1.year, pn1.month, pn1.day, pn2.year, pn2.month, pn2.day);    
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static double SumSL_theongay(PhieuNhapDTO pn1, PhieuNhapDTO pn2)
        {
            try
            {
                string select = string.Format("SELECT SUM(so_luong) FROM db_chi_tiet_pn inner join db_phieu_nhap on db_chi_tiet_pn.ma_phieu_nhap = db_phieu_nhap.ma_phieu_nhap WHERE db_phieu_nhap.ngay_lap_pn between '{0}/{1}/{2}' and '{3}/{4}/{5}'", pn1.year, pn1.month, pn1.day, pn2.year, pn2.month, pn2.day);
                return Sum(select);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
