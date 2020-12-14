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
    public class KhachHangDAO
    {
        static MySqlConnection cnn = null;
        public static DataTable Load_DSKH()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT * FROM db_khach_hang";
                dt = DataProvider.Load_database(select,cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert_KH(KhachHangDTO kh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_khach_hang(ma_kh,ten_kh,diachi,sdt) value ('{0}','{1}', '{2}','{3}');", kh.ma_kh, kh.ten_kh, kh.diachi, kh.sdt);
                DataProvider.Execute(cnn,insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update_KH(KhachHangDTO kh)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("UPDATE db_khach_hang SET ten_kh='{1}',diachi='{2}',sdt='{3}'WHERE ma_kh='{0}';", kh.ma_kh, kh.ten_kh, kh.diachi, kh.sdt);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete_KH(KhachHangDTO kh)
        {
            try
            {
                
                HoaDonDTO hd = new HoaDonDTO();
                PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                List<string> ds = new List<string>();
                string delete_kh = string.Format("DELETE FROM db_khach_hang WHERE ma_kh='{0}'", kh.ma_kh);
                string delete_hd_in_kh = string.Format("SELECT ma_hd FROM db_hoa_don WHERE ma_kh = '{0}'",kh.ma_kh);
                string delete_pdh_in_kh = string.Format("SELECT ma_pdh FROM db_phieu_dat_hang WHERE ma_kh = '{0}'", kh.ma_kh);
                ds = Xoa_thong_tin(delete_hd_in_kh);
                for (int i = 0; i < ds.Count; i++)
                {
                    hd.ma_hd = ds[0];
                    ChiTietHoaDonDAO.delete_SPHD(hd);
                    HoaDonDAO.Delete_HD(hd);
                }
                ds = Xoa_thong_tin(delete_pdh_in_kh);
                for (int i = 0; i < ds.Count; i++)
                {
                    pdh.ma_pdh = ds[0];
                    ChiTietPhieuDatHangDAO.delete_SPPDH(pdh);
                    PhieuDatHangDAO.Delete_PDH(pdh);
                }
                cnn = DataProvider.ConnectData();
                DataProvider.Execute(cnn, delete_kh);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// xóa các liên kết của khách hàng trong csdl
        /// </summary>
        private static List<string> Xoa_thong_tin(string sqlquery)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                DataTable dt = new DataTable();
                List<string> ds = new List<string>();
                dt = DataProvider.Load_database(sqlquery,cnn);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ds.Add(dt.Rows[i].ItemArray.GetValue(0).ToString());
                }
                cnn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable Search_MaKH(KhachHangDTO kh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string Search_ma = string.Format("SELECT * FROM db_khach_hang WHERE ma_kh='{0}'", kh.ma_kh);
                dt = DataProvider.Load_database(Search_ma,cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Search_TenKH(KhachHangDTO kh)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string Search_ten = string.Format("SELECT * FROM db_khach_hang WHERE ten_kh='{0}'", kh.ten_kh);
                dt = DataProvider.Load_database(Search_ten, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static KhachHangDTO Search_KH(String MaKhachHang)
        {
            try
            {
                DataTable dt = new DataTable();
                KhachHangDTO KHang = new KhachHangDTO();
                cnn = DataProvider.ConnectData();
                string Search_DTOKH = string.Format("SELECT *From db_khach_hang WHERE ma_kh = '" + MaKhachHang +"'");
                dt = DataProvider.Load_database(Search_DTOKH, cnn);
                cnn.Close();
                KHang.ma_kh = dt.Rows[0][0].ToString();
                KHang.ten_kh = dt.Rows[0][1].ToString();
                KHang.diachi = dt.Rows[0][2].ToString();
                KHang.sdt = dt.Rows[0][3].ToString();
                return KHang;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
