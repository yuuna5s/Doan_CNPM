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
    public class CongViecDAO
    {
        static MySqlConnection cnn = null;
        public static DataTable Load_DSCV()
        {
            DataTable dt = new DataTable();
            string select = "SELECT * FROM db_chucvu";
            cnn = DataProvider.ConnectData();
            dt = DataProvider.Load_database(select, cnn);
            cnn.Close();
            return dt;
        }
    }
}
