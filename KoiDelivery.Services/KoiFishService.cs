using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Repositories.Interfaces;
using KoiDelivery.Services.Interfaces;

namespace KoiDelivery.Services
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _repository;
        public KoiFishService(IKoiFishRepository repository)
        {
            _repository = repository;
        }

        public bool AddKoiFish(KoiFish koiFish)
        {
            return _repository.AddKoiFish(koiFish);
        }

        public bool DelKoiFish(int Id)
        {
            return _repository.DelKoiFish(Id);
        }

        public bool DelKoiFish(KoiFish koiFish)
        {
            return _repository.DelKoiFish(koiFish);
        }

        public Task<KoiFish> GetKoiFishById(int Id)
        {
            return _repository.GetKoiFishById(Id);
        }
        public Task<List<KoiFish>> KoiFish()
        {
            return _repository.GetAllKoiFish();
        }

        public bool UpdateKoiFish(KoiFish koiFish)
        {
            return _repository.UpdateKoiFish(koiFish);
        }
    }
}