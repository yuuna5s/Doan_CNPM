using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class LoaiSanPhamBUS
    {
        public static DataTable Load_DSLSP()
        {
            return LoaiSanPhamDAO.Load_DSLSP();
        }
        public static void Insert_LSP(LoaiSanPhamDTO loaisp)
        {
            LoaiSanPhamDAO.Insert_LSP(loaisp);
        }

        public static void Update_LSP(LoaiSanPhamDTO loaisp)
        {
            LoaiSanPhamDAO.Update_LSP(loaisp);
        }

        public static void Delete_LSP(LoaiSanPhamDTO loaisp)
        {
            LoaiSanPhamDAO.Delete_LSP(loaisp);
        }
    }
}
