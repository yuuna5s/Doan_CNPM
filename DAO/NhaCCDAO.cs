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
    public class NhaCCDAO
    {
        static MySqlConnection cnn = null;
        public static DataTable Load_DSNCC()
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = "SELECT * FROM db_nha_cung_cap";
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
        /// them ncc
        /// </summary>
        /// <param name="ncc"></param>
        public static void Insert_NCC(NhaCCDTO ncc)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("insert into db_nha_cung_cap(ma_ncc,ten_ncc,sdt_ncc,email) values ('{0}','{1}','{2}','{3}')", ncc.ma_ncc, ncc.ten_ncc, ncc.sdt_ncc, ncc.email);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// update nha cung cap
        /// </summary>
        /// <param name="ncc"></param>
        public static void Update_NCC(NhaCCDTO ncc)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("UPDATE db_nha_cung_cap SET ten_ncc='{1}',sdt_ncc='{2}',email='{3}' WHERE ma_ncc='{0}'", ncc.ma_ncc, ncc.ten_ncc, ncc.sdt_ncc, ncc.email);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete NCC
        /// </summary>
        /// <param name="ncc"></param>
        public static void Delete_NCC(NhaCCDTO ncc)
        {
            try
            {
                cnn = DataProvider.ConnectData();
                string insert = string.Format("DELETE FROM db_nha_cung_cap WHERE ma_ncc='{0}'", ncc.ma_ncc);
                DataProvider.Execute(cnn, insert);
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// tìm theo ten ncc
        /// </summary>
        /// <returns></returns>
        public static DataTable Search_tenNCC(NhaCCDTO ncc)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT * FROM db_nha_cung_cap WHERE ten_ncc = '{0}'",ncc.ten_ncc);
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
        /// tìm theo ma ncc
        /// </summary>
        /// <returns></returns>
        public static DataTable Search_MaNCC(NhaCCDTO ncc)
        {
            try
            {
                DataTable dt = new DataTable();
                cnn = DataProvider.ConnectData();
                string select = string.Format("SELECT * FROM db_nha_cung_cap WHERE ma_ncc = '{0}'", ncc.ma_ncc);
                dt = DataProvider.Load_database(select, cnn);
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
