using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySqlConnector;
using System.Data;
namespace DAO
{
    public class ChiTietPNDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load toàn danh sách phiếu nhập
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSCTPN()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT db_chi_tiet_pn.ma_phieu_nhap,db_sanpham.ma_sp,db_sanpham.ten_sp,so_luong,gianhap,tong FROM db_chi_tiet_pn inner join db_phieu_nhap on db_chi_tiet_pn.ma_phieu_nhap = db_phieu_nhap.ma_phieu_nhap inner join db_sanpham on db_chi_tiet_pn.ma_sp = db_sanpham.ma_sp";
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
        /// load danh sách theo mã phiếu nhập
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSMaPN(PhieuNhapDTO pn)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT db_chi_tiet_pn.ma_phieu_nhap,db_sanpham.ma_sp,db_sanpham.ten_sp,so_luong,gianhap,tong FROM db_chi_tiet_pn inner join db_phieu_nhap on db_chi_tiet_pn.ma_phieu_nhap = db_phieu_nhap.ma_phieu_nhap inner join db_sanpham on db_chi_tiet_pn.ma_sp = db_sanpham.ma_sp WHERE db_chi_tiet_pn.ma_phieu_nhap='{0}'",pn.ma_phieu_nhap);
                dt = DataProvider.Load_database(select, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update_CTPNSP(ChiTietPNDTO ctpn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format("UPDATE db_chi_tiet_pn SET ma_sp='{1}',so_luong='{2}',gianhap='{3}',tong='{4}' WHERE id='{0}'",
                                                    ctpn.id,ctpn.ma_sp,ctpn.soluong,ctpn.gianhap,ctpn.tong);
                DataProvider.Execute(cnn,update);
                cnn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void insert_CTPN(ChiTietPNDTO ctpn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_chi_tiet_pn(ma_sp,ma_phieu_nhap,so_luong,gianhap,tong) values('{0}','{1}','{2}','{3}','{4}');",
                                                                        ctpn.ma_sp,ctpn.ma_phieu_nhap,ctpn.soluong,ctpn.gianhap,ctpn.tong);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        public static void delete_SPPN(PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM db_chi_tiet_pn WHERE ma_phieu_nhap='{0}';", pn.ma_phieu_nhap);
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

        public static void delete_SPPN(SanPhamDTO sp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM db_chi_tiet_pn WHERE ma_sp='{0}';", sp.ma_sp);
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

        public static void delete_SPPN(SanPhamDTO sp ,PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string id = string.Format("Delete FROM db_chi_tiet_pn WHERE ma_phieu_nhap='{0}' AND ma_sp='{1}';", pn.ma_phieu_nhap, sp.ma_sp);
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
