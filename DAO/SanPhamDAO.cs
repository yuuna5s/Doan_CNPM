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
    public class SanPhamDAO
    {
        static MySqlConnection cnn = null;
        /// <summary>
        /// load danh sách từ csdl lên form
        /// </summary>
        /// <returns></returns>
        public static DataTable Load_DSSP()
        {
            try
            {
                DataTable dt = new DataTable();
                string select = "SELECT ma_sp,db_nhom_sp.ten_loai_sp,ten_sp,don_vi_tinh,gia_sp,thoi_gian_bh,soluong,hang_san_xuat FROM db_sanpham inner join db_nhom_sp on db_sanpham.ma_loai=db_nhom_sp.ma_loai";
                cnn = DataProvider.ConnectData();
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
        /// them vao csdl
        /// </summary>
        /// <param name="sp"></param>
        public static void Insert_SP(SanPhamDTO sp)
        {
            try
            {
                string insert = string.Format("insert into db_sanpham(ma_sp,ma_loai,ten_sp,don_vi_tinh,gia_sp,thoi_gian_bh,soluong,hang_san_xuat) values ('{0}','{1}','{2}','{3}',{4},{5},{6},'{7}');",
                    sp.ma_sp,sp.ma_loai,sp.ten_sp,sp.don_vi_tinh,sp.gia,sp.thoi_gian_bh,sp.soluong,sp.hang_san_xuat);
                cnn = DataProvider.ConnectData();
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// update csdl
        /// </summary>
        /// <param name="sp"></param>
        public static void Update_SP(SanPhamDTO sp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("UPDATE `db_sanpham` SET `ma_loai`='{0}', " +
                    "`ten_sp`='{1}', " +
                    "`don_vi_tinh`='{2}', " +
                    "`gia_sp`='{3}', " +
                    "`thoi_gian_bh`='{4}', " +
                    "`soluong`='{5}', " +
                    "`hang_san_xuat`='{6}' WHERE `ma_sp`='{7}';",
                    sp.ma_loai, sp.ten_sp, sp.don_vi_tinh, sp.gia, sp.thoi_gian_bh, sp.soluong, sp.hang_san_xuat, sp.ma_sp);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete du lieu
        /// </summary>
        /// <param name="sp"></param>
        public static void Delete_SP(SanPhamDTO sp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("DELETE FROM `db_sanpham` WHERE ma_sp='{0}' ;",sp.ma_sp);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo mã sản phẩm
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static DataTable Search_MaSP(SanPhamDTO sp)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string masp= string.Format("SELECT ma_sp,db_nhom_sp.ten_loai_sp,ten_sp,don_vi_tinh,gia_sp,thoi_gian_bh,soluong,hang_san_xuat FROM db_sanpham inner join db_nhom_sp on db_sanpham.ma_loai=db_nhom_sp.ma_loai WHERE db_sanpham.ma_sp='{0}';",sp.ma_sp);
                dt = DataProvider.Load_database(masp, cnn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm theo tên sản phẩm
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static DataTable Search_TenSP(SanPhamDTO sp)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string masp = string.Format("SELECT ma_sp,db_nhom_sp.ten_loai_sp,ten_sp,don_vi_tinh,gia_sp,thoi_gian_bh,soluong,hang_san_xuat FROM db_sanpham inner join db_nhom_sp on db_sanpham.ma_loai=db_nhom_sp.ma_loai WHERE db_sanpham.ten_sp='{0}';", sp.ten_sp);
                dt = DataProvider.Load_database(masp, cnn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo hãng sản xuất
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static DataTable Search_HangSXSP(SanPhamDTO sp)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string masp = string.Format("SELECT ma_sp,db_nhom_sp.ten_loai_sp,ten_sp,don_vi_tinh,gia_sp,thoi_gian_bh,soluong,hang_san_xuat FROM db_sanpham inner join db_nhom_sp on db_sanpham.ma_loai=db_nhom_sp.ma_loai WHERE db_sanpham.hang_san_xuat='{0}';", sp.hang_san_xuat);
                dt = DataProvider.Load_database(masp, cnn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //tìm theo loại
        public static DataTable Search_LoaiSP(LoaiSanPhamDTO loaisp)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string masp = string.Format("SELECT ma_sp,db_nhom_sp.ten_loai_sp,ten_sp,don_vi_tinh,gia_sp,thoi_gian_bh,soluong,hang_san_xuat FROM db_sanpham inner join db_nhom_sp on db_sanpham.ma_loai=db_nhom_sp.ma_loai WHERE db_nhom_sp.ten_loai_sp='{0}';", loaisp.ten_loai_sp);
                dt = DataProvider.Load_database(masp, cnn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Tỉm Sản Phẩm
        public static SanPhamDTO Search_SP(string masp)
        {
            try
            {
                DataTable dt = new DataTable();
                SanPhamDTO sp = new SanPhamDTO();
                cnn = DataProvider.ConnectData();
                string searchsp = string.Format("SELECT * FROM `db_sanpham` WHERE db_sanpham.ma_sp='" + masp + "'");
                dt = DataProvider.Load_database(searchsp, cnn);
                cnn.Close();
                sp.ma_sp = dt.Rows[0][0].ToString();
                sp.ma_loai = dt.Rows[0][1].ToString();
                sp.ten_sp = dt.Rows[0][2].ToString();
                sp.don_vi_tinh = dt.Rows[0][3].ToString();
                sp.gia =  double.Parse(dt.Rows[0][4].ToString());
                sp.thoi_gian_bh = int.Parse(dt.Rows[0][5].ToString());
                sp.soluong = int.Parse(dt.Rows[0][6].ToString());
                sp.hang_san_xuat = dt.Rows[0][7].ToString();
                return sp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
