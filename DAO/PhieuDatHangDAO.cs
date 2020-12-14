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
    public class PhieuDatHangDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load danh sach phiếu đặt hàng
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSPDH()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT ma_pdh,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,tonggiatri FROM db_phieu_dat_hang inner join db_nhanvien on db_phieu_dat_hang.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_phieu_dat_hang.ma_kh = db_khach_hang.ma_kh ";
                dt = DataProvider.Load_database(select,cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// xóa 1 phiếu đặt hàng
        /// </summary>
        /// <param name="pdh"></param>
        public static void Delete_PDH(PhieuDatHangDTO pdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string delete = string.Format("DELETE FROM chi_tiet_pdh WHERE ma_pdh = '{0}';DELETE FROM db_phieu_dat_hang WHERE ma_pdh = '{0}';", pdh.ma_pdh);
                DataProvider.Execute(cnn,delete);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm theo mã phiếu
        /// </summary>
        /// <returns></returns>
        public static DataTable Search_Ma(PhieuDatHangDTO pdh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_pdh,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,tonggiatri FROM db_phieu_dat_hang inner join db_nhanvien on db_phieu_dat_hang.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_phieu_dat_hang.ma_kh = db_khach_hang.ma_kh WHERE ma_pdh = '{0}'",pdh.ma_pdh);
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
        /// Tìm nhân viên lập phiếu
        /// </summary>
        /// <returns></returns>
        public static DataTable Search_TenNVLPDH(NhanVienDTO nv)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_pdh,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,tonggiatri FROM db_phieu_dat_hang inner join db_nhanvien on db_phieu_dat_hang.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_phieu_dat_hang.ma_kh = db_khach_hang.ma_kh WHERE db_nhanvien.ten_nv = '{0}'", nv.ten_nv);
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
        /// Tìm tên khách hàng
        /// </summary>
        /// <returns></returns>
        public static DataTable Search_TenKH(KhachHangDTO kh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_pdh,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,tonggiatri FROM db_phieu_dat_hang inner join db_nhanvien on db_phieu_dat_hang.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_phieu_dat_hang.ma_kh = db_khach_hang.ma_kh WHERE db_khach_hang.ten_kh = '{0}'", kh.ten_kh);
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
        /// Tìm ngày lập
        /// </summary>
        /// <returns></returns>
        public static DataTable Search_NgayLPDH(PhieuDatHangDTO pdh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_pdh,db_nhanvien.ten_nv,db_khach_hang.ten_kh,ngay_lap,tonggiatri FROM db_phieu_dat_hang inner join db_nhanvien on db_phieu_dat_hang.ma_nv = db_nhanvien.ma_nv inner join db_khach_hang on db_phieu_dat_hang.ma_kh = db_khach_hang.ma_kh WHERE db_phieu_dat_hang.ngay_lap = '{0}/{1}/{2}'", pdh.year,pdh.month,pdh.day);
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert_PDH(PhieuDatHangDTO pdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_phieu_dat_hang(ma_pdh,ma_nv,ma_kh,ngay_lap) values ('{0}','{1}','{2}','{3}/{4}/{5}');",pdh.ma_pdh,pdh.ma_nv,pdh.ma_kh,pdh.year,pdh.month,pdh.day);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update_Gia(PhieuDatHangDTO pdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update_gia = string.Format("UPDATE db_phieu_dat_hang SET tonggiatri='{0}' WHERE ma_pdh='{1}'",pdh.tonggiatri,pdh.ma_pdh);
                DataProvider.Execute(cnn, update_gia);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
