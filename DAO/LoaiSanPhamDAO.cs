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
    public class LoaiSanPhamDAO
    {
        static MySqlConnection cnn = null;
        public static DataTable Load_DSLSP()
        {
            try
            {
                DataTable dt = new DataTable();
                string select = "SELECT * FROM db_nhom_sp";
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
        /// <param name="loaisp"></param>
        public static void Insert_LSP(LoaiSanPhamDTO loaisp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_nhom_sp values ('{0}','{1}');",loaisp.ma_loai,loaisp.ten_loai_sp);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update_LSP(LoaiSanPhamDTO loaisp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format("UPDATE db_nhom_sp SET ten_loai_sp='{1}' WHERE ma_loai='{0}';", loaisp.ma_loai, loaisp.ten_loai_sp);
                DataProvider.Execute(cnn, update);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete_LSP(LoaiSanPhamDTO loaisp)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string update = string.Format("DELETE FROM db_nhom_sp WHERE ma_loai='{0}';", loaisp.ma_loai, loaisp.ten_loai_sp);
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
