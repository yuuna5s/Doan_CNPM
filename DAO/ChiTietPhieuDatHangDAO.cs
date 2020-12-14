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
    public class ChiTietPhieuDatHangDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load danh sach phiếu đặt hàng
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSCTPDH()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT ma_pdh,chi_tiet_pdh.ma_sp,db_sanpham.ten_sp,chi_tiet_pdh.soluong,db_sanpham.gia_sp,thanhtien FROM chi_tiet_pdh inner join db_sanpham on chi_tiet_pdh.ma_sp = db_sanpham.ma_sp";
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
        /// load theo mã phiếu đặt hàng
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSTheoMaPDH(PhieuDatHangDTO pdh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT ma_pdh,chi_tiet_pdh.ma_sp,db_sanpham.ten_sp,chi_tiet_pdh.soluong,db_sanpham.gia_sp,thanhtien FROM chi_tiet_pdh inner join db_sanpham on chi_tiet_pdh.ma_sp = db_sanpham.ma_sp WHERE ma_pdh='{0}'", pdh.ma_pdh);
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
        /// sửa chi tiết phiếu đặt hàng
        /// </summary>
        /// <param name="ctpdh"></param>
        public static void Update_CTPDH(ChiTietPDHDTO ctpdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format("UPDATE chi_tiet_pdh SET ma_sp='{1}',soluong={2},thanhtien='{3}' WHERE id = '{0}'",ctpdh.id,ctpdh.ma_sp,ctpdh.soluong,ctpdh.thanhtien);
                DataProvider.Execute(cnn, update);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert_CTPDH(ChiTietPDHDTO ctpdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into chi_tiet_pdh(ma_sp,ma_pdh,soluong,thanhtien) values('{0}','{1}','{2}','{3}');",ctpdh.ma_sp,ctpdh.ma_pdh,ctpdh.soluong,ctpdh.thanhtien);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete_SPPDH(PhieuDatHangDTO pdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM chi_tiet_pdh WHERE ma_pdh='{0}';", pdh.ma_pdh);
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

        public static void delete_SPPDH(SanPhamDTO sp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM chi_tiet_pdh WHERE ma_sp='{0}';", sp.ma_sp);
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

        public static void delete_SPPDH(SanPhamDTO sp, PhieuDatHangDTO pdh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM chi_tiet_pdh WHERE ma_pdh='{0}' AND ma_sp='{1}';",pdh.ma_pdh, sp.ma_sp);
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
