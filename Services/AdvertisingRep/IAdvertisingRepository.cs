using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.AdvertisingRep
{
    public interface IAdvertisingRepository
    {
        IEnumerable<Advertising> GetAdvertisings();

        IEnumerable<Partner> GetPartners();

        IEnumerable<Product> GetProducts();

        void Update(Advertising advertising);
    }
}

