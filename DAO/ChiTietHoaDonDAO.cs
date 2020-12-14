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
    public class ChiTietHoaDonDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load danh sách chi tiết hóa đơn
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSCTHD()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT ma_hd,db_sanpham.ma_sp,db_sanpham.ten_sp,so_luong,db_sanpham.gia_sp,thanh_tien FROM chi_tiet_hd inner join db_sanpham on chi_tiet_hd.ma_sp = db_sanpham.ma_sp";
                dt = DataProvider.Load_database(select,cnn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// load danh sách theo mã hóa đơn
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSTheoMaHD(HoaDonDTO hd)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_hd,db_sanpham.ma_sp,db_sanpham.ten_sp,so_luong,db_sanpham.gia_sp,thanh_tien FROM chi_tiet_hd inner join db_sanpham on chi_tiet_hd.ma_sp = db_sanpham.ma_sp WHERE chi_tiet_hd.ma_hd = '{0}'", hd.ma_hd);
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
        /// sữa thông tin chi tiết hóa đơn
        /// </summary>
        /// <param name="cthd"></param>
        public static void Update_CTHD(ChiTietHoaDonDTO cthd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format(" UPDATE chi_tiet_hd SET ma_sp = '{2}', so_luong='{3}' WHERE ma_hd = '{1}' and id = '{0}'; UPDATE chi_tiet_hd SET thanh_tien='{4}' WHERE id = '{0}'; ", cthd.id, cthd.ma_hd, cthd.ma_sp, cthd.soluong,cthd.thanhtien);
                DataProvider.Execute(cnn, update);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insert_CTHD(ChiTietHoaDonDTO cthd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into chi_tiet_hd(ma_hd,ma_sp,so_luong,thanh_tien) values ('{0}','{1}','{2}','{3}');",
                                                            cthd.ma_hd,cthd.ma_sp,cthd.soluong,cthd.thanhtien);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete_SPHD(HoaDonDTO hd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM chi_tiet_hd WHERE ma_hd='{0}';", hd.ma_hd);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(id,cnn);
                DataProvider.Execute(cnn, id);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete_SPHD(SanPhamDTO sp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM chi_tiet_hd WHERE ma_sp='{0}';", sp.ma_sp);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(id, cnn);
                DataProvider.Execute(cnn, id);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete_SPHD(SanPhamDTO sp, HoaDonDTO hd)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM chi_tiet_hd WHERE ma_hd='{0}' AND ma_sp='{1}';", hd.ma_hd, sp.ma_sp);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(id, cnn);
                DataProvider.Execute(cnn, id);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
