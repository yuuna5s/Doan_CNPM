using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using DTO;
namespace DAO
{
    public class NhanVienDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load dữ liệu
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadDSNV()
        {
            DataTable dtb = new DataTable();
            string strmysql = "SELECT ma_nv,ten_nv,ngay_sinh,gioi_tinh,sdt_nv,dia_chi_nv,email,db_chucvu.ten_cv FROM db_nhanvien inner join db_chucvu on db_nhanvien.ma_cv = db_chucvu.ma_cv ";
            cnn = DataProvider.ConnectData();
            dtb = DataProvider.Load_database(strmysql, cnn);
            cnn.Close();
            return dtb;
        }
        /// <summary>
        /// Insert dữ liệu
        /// </summary>
        /// <param name="nv">1 đối tượng nhân viên trong bảng nhân viên</param>
        /// <returns>kết quả thành công hay không</returns>
        public static void Insert_NV(NhanVienDTO nv)
        {
            try
            {
                string insert = string.Format("insert into db_nhanvien(ma_nv,ten_nv,ngay_sinh,gioi_tinh,sdt_nv,dia_chi_nv,email,ma_cv) values ('{0}','{1}','{2}/{3}/{4}','{5}','{6}','{7}','{8}','{9}');",
                                                                        nv.ma_nv,nv.ten_nv,nv.year,nv.month,nv.day,nv.gioi_tinh,nv.sdt_nv,nv.dia_chi_nv,nv.email,nv.ma_cv);
                cnn = DataProvider.ConnectData();
                DataProvider.Execute(cnn,insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// update nhan viên
        /// </summary>
        /// <param name="nv"></param>
        public static void Update_NV(NhanVienDTO nv)
        {
            try
            {
                string update = string.Format("UPDATE db_nhanvien SET ten_nv='{0}',ngay_sinh='{1}/{2}/{3}',gioi_tinh='{4}',sdt_nv='{5}',dia_chi_nv='{6}',email='{7}',ma_cv='{8}' WHERE ma_nv='{9}'",
                                                nv.ten_nv, nv.year, nv.month, nv.day, nv.gioi_tinh, nv.sdt_nv, nv.dia_chi_nv, nv.email, nv.ma_cv, nv.ma_nv);
                cnn = DataProvider.ConnectData();
                DataProvider.Execute(cnn,update);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete nhan vien
        /// </summary>
        /// <param name="nv"></param>
        public static void Delete_NV(NhanVienDTO nv)
        {
            try
            {
                string delete = string.Format("DELETE FROM db_nhanvien where ma_nv ='{0}'",nv.ma_nv);
                cnn = DataProvider.ConnectData();
                DataProvider.Execute(cnn, delete);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo tên nhan vien
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public static DataTable Search_TenNV(NhanVienDTO nv)
        {
            try
            {
                DataTable dt = new DataTable();
                string search_ten = string.Format("SELECT ma_nv,ten_nv,ngay_sinh,gioi_tinh,sdt_nv,dia_chi_nv,email,db_chucvu.ten_cv FROM db_nhanvien,db_chucvu WHERE db_nhanvien.ma_cv = db_chucvu.ma_cv and db_nhanvien.ten_nv='{0}'", nv.ten_nv);
                cnn = DataProvider.ConnectData();
                MySqlDataAdapter dta = new MySqlDataAdapter(search_ten, cnn);
                dta.Fill(dt);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo mã nhân viên
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public static DataTable Search_MaNV(NhanVienDTO nv)
        {
            try
            {
                DataTable dt = new DataTable();
                string search_ten = string.Format("SELECT ma_nv,ten_nv,ngay_sinh,gioi_tinh,sdt_nv,dia_chi_nv,email,db_chucvu.ten_cv FROM db_nhanvien,db_chucvu WHERE db_nhanvien.ma_cv = db_chucvu.ma_cv and db_nhanvien.ma_nv='{0}'", nv.ma_nv);
                cnn = DataProvider.ConnectData();
                MySqlDataAdapter dta = new MySqlDataAdapter(search_ten, cnn);
                dta.Fill(dt);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo công viec nhan vien
        /// </summary>
        /// <param name="cv"></param>
        /// <returns></returns>
        public static DataTable Search_Congviec_NV(CongViecDTO cv)
        {
            try
            {
                DataTable dt = new DataTable();
                string search_ten = string.Format("SELECT ma_nv,ten_nv,ngay_sinh,gioi_tinh,sdt_nv,dia_chi_nv,email,db_chucvu.ten_cv FROM db_nhanvien,db_chucvu WHERE db_nhanvien.ma_cv = db_chucvu.ma_cv and db_chucvu.ten_cv='{0}'", cv.ten_cv);
                cnn = DataProvider.ConnectData();
                MySqlDataAdapter dta = new MySqlDataAdapter(search_ten, cnn);
                dta.Fill(dt);
                cnn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
