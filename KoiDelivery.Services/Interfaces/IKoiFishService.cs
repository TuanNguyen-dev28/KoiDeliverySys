using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiDelivery.Repositories.Entities;

namespace KoiDelivery.Services.Interfaces
{
    public interface IKoiFishService
    {
        Task<List<KoiFish>> KoiFish();
        Boolean DelKoiFish(int Id);
        Boolean DelKoiFish(KoiFish koiFish);
        Boolean AddKoiFish(KoiFish koiFish);
        Boolean UpdateKoiFish(KoiFish koiFish);
        Task<KoiFish> GetKoiFishById(int Id);
    }
}