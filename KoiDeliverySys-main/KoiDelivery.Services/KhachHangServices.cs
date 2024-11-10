using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Repositories.Interfaces;
using KoiDelivery.Services.Interfaces;

namespace KoiDelivery.Services
{
    public class KhachHangServices : IKhachHangService
    {
        private readonly IKhachHangRepository _repository;
        public KhachHangServices(IKhachHangRepository repository)
        {
            _repository = repository;
        }

        public bool AddTaiKhoanKhachHang(TaiKhoanKhachHang account)
        {
            return _repository.AddTaiKhoanKhachHang(account);
        }

        public bool DelTaiKhoanKhachHang(int Id)
        {
            return _repository.DelTaiKhoanKhachHang(Id);
        }

        public bool DelTaiKhoanKhachHang(TaiKhoanKhachHang account)
        {
            return _repository.DelTaiKhoanKhachHang(account);
        }

        public Task<TaiKhoanKhachHang> GetTaiKhoanKhachHangById(int Id)
        {
            return _repository.GetTaiKhoanKhachHangById(Id);
        }

        public Task<List<TaiKhoanKhachHang>> TaiKhoanKhachHangs()
        {
            return _repository.GetAllTaiKhoanKhachHang();
        }

        public bool UpdTaiKhoanKhachHang(TaiKhoanKhachHang acocunt)
        {
            return _repository.UpdTaiKhoanKhachHang(acocunt);
        }
    }
}
