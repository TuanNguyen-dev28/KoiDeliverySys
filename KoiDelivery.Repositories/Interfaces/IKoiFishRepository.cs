using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;

namespace KoiDelivery.Repositories.Interfaces
{
    public interface IKoiFishRepository
    {
        Task<List<KoiFish>> GetAllKoiFish();
        Boolean DelKoiFish(int Id);
        Boolean DelKoiFish(KoiFish koiFish);
        Boolean AddKoiFish(KoiFish koiFish);
        Boolean UpdateKoiFish(KoiFish koiFish);
        Task<KoiFish> GetKoiFishById(int Id);

    }
}