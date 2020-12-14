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
    public class HoaDonDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load danh sach hóa đơn
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSHD()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT ma_hd,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,tonggiatri,thanh_toan FROM  db_hoa_don inner join db_nhanvien on db_hoa_don.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_hoa_don.ma_kh = db_khach_hang.ma_kh";
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete_HD(HoaDonDTO hd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string delete = string.Format("DELETE FROM chi_tiet_hd WHERE ma_hd = '{0}'; DELETE FROM db_hoa_don WHERE ma_hd = '{0}'; ", hd.ma_hd);
                DataProvider.Execute(cnn,delete);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo mã hóa đơn
        /// </summary>
        /// <param name="hd"></param>
        public static DataTable Search_MaHD(HoaDonDTO hd)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string Search_MaHD = string.Format("SELECT ma_hd,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,da_thanh_toan,con_lai,tonggiatri,thanh_toan FROM  db_hoa_don inner join db_nhanvien on db_hoa_don.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_hoa_don.ma_kh = db_khach_hang.ma_kh WHERE ma_hd = '{0}'", hd.ma_hd);
                dt = DataProvider.Load_database(Search_MaHD, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// tìm theo ngày lập hóa đơn
        /// </summary>
        /// <param name="hd"></param>
        public static DataTable Search_NgayLapHD(HoaDonDTO hd)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string Search_NgayLapHD = string.Format("SELECT ma_hd,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,da_thanh_toan,con_lai,tonggiatri,thanh_toan FROM  db_hoa_don inner join db_nhanvien on db_hoa_don.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_hoa_don.ma_kh = db_khach_hang.ma_kh WHERE ngay_lap = '{0}/{1}/{2}'", hd.year,hd.month,hd.day);
                dt = DataProvider.Load_database(Search_NgayLapHD,cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// tìm theo tên khách hàng
        /// </summary>
        /// <param name="hd"></param>
        public static DataTable Search_TenKHinHD(KhachHangDTO kh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string Search_TenKHinHD = string.Format("SELECT ma_hd,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,da_thanh_toan,con_lai,tonggiatri,thanh_toan FROM  db_hoa_don inner join db_nhanvien on db_hoa_don.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_hoa_don.ma_kh = db_khach_hang.ma_kh WHERE db_khach_hang.ten_kh = '{0}'", kh.ten_kh);
                dt = DataProvider.Load_database(Search_TenKHinHD,cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// tìm theo tên nhân viên lập hóa đơn
        /// </summary>
        /// <param name="hd"></param>
        public static DataTable Search_TenNVLHD(NhanVienDTO nv)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string Search_TenKHinHD = string.Format("SELECT ma_hd,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,da_thanh_toan,con_lai,tonggiatri,thanh_toan FROM  db_hoa_don inner join db_nhanvien on db_hoa_don.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_hoa_don.ma_kh = db_khach_hang.ma_kh WHERE db_nhanvien.ten_nv = '{0}'", nv.ten_nv);
                dt = DataProvider.Load_database(Search_TenKHinHD, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insert_HD(HoaDonDTO hd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_hoa_don(ma_hd,ma_nv,ma_kh,ngay_lap,da_thanh_toan,con_lai,tonggiatri,thanh_toan) values ('{0}','{1}','{2}','{3}/{4}/{5}','{6}','{7}','{8}',{9});",
                                                                hd.ma_hd,hd.ma_nv,hd.ma_kh,hd.year,hd.month,hd.day,hd.dathanhtoan,hd.conlai,hd.tonggiatri,hd.thanhtoan);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update_hd(HoaDonDTO hd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format("UPDATE db_hoa_don SET tonggiatri = '{1}' WHERE ma_hd='{0}'",hd.ma_hd,hd.tonggiatri);
                DataProvider.Execute(cnn, update);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
