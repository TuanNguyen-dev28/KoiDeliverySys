using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiDelivery.Repositories
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiFishContext _dbcontext;
        public KoiFishRepository(KoiFishContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool AddKoiFish(KoiFish koiFish)
        {
            try
            {
                _dbcontext.KoiFishes.Add(koiFish);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelKoiFish(int Id)
        {
            try
            {
                var koiFishToRemove = _dbcontext.KoiFishes.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                if (koiFishToRemove != null)
                {
                    _dbcontext.KoiFishes.Remove(koiFishToRemove);
                    _dbcontext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelKoiFish(KoiFish koiFish)
        {
            try
            {
                _dbcontext.KoiFishes.Remove(koiFish);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public async Task<List<KoiFish>> GetAllKoiFish()
        {
            return await _dbcontext.KoiFishes.ToListAsync();
        }

        public async Task<KoiFish> GetKoiFishById(int Id)
        {
            return await _dbcontext.KoiFishes.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            try
            {
                _dbcontext.KoiFishes.Update(koiFish);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}