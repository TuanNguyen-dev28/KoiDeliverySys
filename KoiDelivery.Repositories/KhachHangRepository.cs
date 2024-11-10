using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiDelivery.Repositories
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly TaiKhoanContext _dbContext;
        public KhachHangRepository(TaiKhoanContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddTaiKhoanKhachHang(TaiKhoanKhachHang account)
        {
            try
            {
                _dbContext.TaiKhoanKhachHangs.Add(account);
                //await _dbContext.TaiKhoanKhachHangs.AddAsync(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelTaiKhoanKhachHang(int Id)
        {
            try
            {
                var objDel = _dbContext.TaiKhoanKhachHangs.Where(p=>p.AccId == Id).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.TaiKhoanKhachHangs.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelTaiKhoanKhachHang(TaiKhoanKhachHang account)
        {
            try
            {
                _dbContext.TaiKhoanKhachHangs.Remove(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<TaiKhoanKhachHang>> GetAllTaiKhoanKhachHang()
        {
            return await _dbContext.TaiKhoanKhachHangs.ToListAsync();
        }

        public async Task<TaiKhoanKhachHang> GetTaiKhoanKhachHangById(int Id)
        {
            return await _dbContext.TaiKhoanKhachHangs.Where(p=>p.AccId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdTaiKhoanKhachHang(TaiKhoanKhachHang acocunt)
        {
            try
            {
                _dbContext.TaiKhoanKhachHangs.Update(acocunt);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
