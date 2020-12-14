using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using MySqlConnector;
namespace DAO
{
    public class PhieuNhapDAO
    {
        static MySqlConnection cnn = null;
        public static DataTable Load_DSPN()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT ma_phieu_nhap,db_nhanvien.ten_nv,db_nha_cung_cap.ten_ncc,ngay_lap_pn,tong_tien FROM db_phieu_nhap inner join db_nhanvien on db_phieu_nhap.ma_nv = db_nhanvien.ma_nv inner join db_nha_cung_cap on db_phieu_nhap.ma_ncc = db_nha_cung_cap.ma_ncc";
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
        /// xoa thong tin 1 phieu nhap
        /// </summary>
        /// <param name="pn"></param>
        public static void Delete_PN(PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string select = string.Format("delete from db_chi_tiet_pn where ma_phieu_nhap='{0}';delete from db_phieu_nhap where ma_phieu_nhap='{0}';", pn.ma_phieu_nhap);
                DataProvider.Execute(cnn, select);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo mã phiếu nhập
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public static DataTable Search_MaPN(PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string Search_ma = string.Format("SELECT ma_phieu_nhap,db_nhanvien.ten_nv,db_nha_cung_cap.ten_ncc,ngay_lap_pn,tong_tien FROM db_phieu_nhap inner join db_nhanvien on db_phieu_nhap.ma_nv = db_nhanvien.ma_nv inner join db_nha_cung_cap on db_phieu_nhap.ma_ncc = db_nha_cung_cap.ma_ncc WHERE db_phieu_nhap.ma_phieu_nhap='{0}'", pn.ma_phieu_nhap);
                DataTable dt = new DataTable();
                dt = DataProvider.Load_database(Search_ma, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo nv lập phiếu
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public static DataTable Search_TenNVLPN(NhanVienDTO nv)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string Search_ma = string.Format("SELECT ma_phieu_nhap,db_nhanvien.ten_nv,db_nha_cung_cap.ten_ncc,ngay_lap_pn,tong_tien FROM db_phieu_nhap inner join db_nhanvien on db_phieu_nhap.ma_nv = db_nhanvien.ma_nv inner join db_nha_cung_cap on db_phieu_nhap.ma_ncc = db_nha_cung_cap.ma_ncc WHERE db_nhanvien.ten_nv='{0}'", nv.ten_nv);
                DataTable dt = new DataTable();
                dt = DataProvider.Load_database(Search_ma, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm ngày lập phiếu
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public static DataTable Search_NgayLPN(PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string Search_ma = string.Format("SELECT ma_phieu_nhap,db_nhanvien.ten_nv,db_nha_cung_cap.ten_ncc,ngay_lap_pn,tong_tien FROM db_phieu_nhap inner join db_nhanvien on db_phieu_nhap.ma_nv = db_nhanvien.ma_nv inner join db_nha_cung_cap on db_phieu_nhap.ma_ncc = db_nha_cung_cap.ma_ncc WHERE db_phieu_nhap.ngay_lap_pn='{0}/{1}/{2}'", pn.year, pn.month, pn.day);
                DataTable dt = new DataTable();
                dt = DataProvider.Load_database(Search_ma, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo nhà cung cấp
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public static DataTable Search_NCC(NhaCCDTO ncc)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string Search_ma = string.Format("SELECT ma_phieu_nhap,db_nhanvien.ten_nv,db_nha_cung_cap.ten_ncc,ngay_lap_pn,tong_tien FROM db_phieu_nhap inner join db_nhanvien on db_phieu_nhap.ma_nv = db_nhanvien.ma_nv inner join db_nha_cung_cap on db_phieu_nhap.ma_ncc = db_nha_cung_cap.ma_ncc WHERE db_nha_cung_cap.ten_ncc='{0}'", ncc.ten_ncc);
                DataTable dt = new DataTable();
                dt = DataProvider.Load_database(Search_ma, cnn);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// thêm danh 1 phiếu nhập
        /// </summary>
        /// <param name="pn"></param>
        public static void insert_PN(PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_phieu_nhap(ma_phieu_nhap,ma_nv,ma_ncc,ngay_lap_pn,tong_tien) values ('{0}','{1}','{2}','{3}/{4}/{5}','{6}');",
                                                                        pn.ma_phieu_nhap,pn.ma_nv,pn.ma_ncc,pn.year,pn.month,pn.day,pn.tongtien);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update_PN(PhieuNhapDTO pn)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format("UPDATE db_phieu_nhap SET tong_tien='{1}' WHERE ma_phieu_nhap='{0}';",pn.ma_phieu_nhap,pn.tongtien);
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
