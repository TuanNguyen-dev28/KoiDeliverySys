using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;


namespace KoiDelivery.Repositories.Interfaces
{
    public interface IKhachHangRepository
    {
        Task<List<TaiKhoanKhachHang>> GetAllTaiKhoanKhachHang();
        Boolean DelTaiKhoanKhachHang(int Id);
        Boolean DelTaiKhoanKhachHang(TaiKhoanKhachHang account);
        Boolean AddTaiKhoanKhachHang(TaiKhoanKhachHang account);
        Boolean UpdTaiKhoanKhachHang(TaiKhoanKhachHang acocunt);
        Task<TaiKhoanKhachHang> GetTaiKhoanKhachHangById(int Id);
    }
}
