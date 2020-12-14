using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class NhanVienBUS
    {
        public static DataTable GetDSNV()
        {
            return NhanVienDAO.LoadDSNV();
        }
        public static void Insert(NhanVienDTO nv)
        {
            NhanVienDAO.Insert_NV(nv);
        }
        public static void Update(NhanVienDTO nv)
        {
            NhanVienDAO.Update_NV(nv);
        }
        public static void Delete(NhanVienDTO nv)
        {
            NhanVienDAO.Delete_NV(nv);
        }
        public static DataTable Search_tenNV(NhanVienDTO nv)
        {
            return NhanVienDAO.Search_TenNV(nv);
        }
        public static DataTable Search_MaNV(NhanVienDTO nv)
        {
            return NhanVienDAO.Search_MaNV(nv);
        }
        public static DataTable Search_tenCV(CongViecDTO cv)
        {
            return NhanVienDAO.Search_Congviec_NV(cv);
        }
    }
}
