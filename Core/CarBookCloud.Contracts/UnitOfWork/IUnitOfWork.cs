using CarBookCloud.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAboutRepository Abouts { get; }
        IBannerRepository Banners { get; }
        IBrandRepository Brands { get; }
        ICarDescriptionRepository CarDescriptions { get; }
        ICarFeatureRepository CarFeatures { get; }
        ICarPricingRepository CarPricings { get; }
        ICarRepository Cars { get; }
        ICategoryRepository Categories { get; }
        IContactRepository Contacts { get; }
        IFeatureRepository Features { get; }
        IFooterAddressRepository FooterAddresses { get; }
        ILocationRepository Locations { get; }
        IPricingRepository Pricings { get; }
        IServiceRepository Services { get; }
        ISocialMediaRepository SocialMedias { get; }
        ITestimonialRepository Testimonials { get; }

        Task<int> SaveChangesAsync();
        Task SaveEntitiesAsync(); 
    }

}
