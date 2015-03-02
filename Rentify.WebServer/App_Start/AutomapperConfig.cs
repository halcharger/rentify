using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NExtensions;
using Rentify.Core;
using Rentify.Core.Domain;
using Rentify.WebServer.Models;

namespace Rentify.WebServer
{
    public static class AutoMapperConfig
    {
        public static void Setup()
        {
            Mapper.Initialize(cfg =>
            {
                var azureStorageAccountName = RentifyConfig.RentifyAzureStorageConnectionStringAccountName;

                cfg.CreateMap<RentifySite, SiteViewModel>();
                cfg.CreateMap<Property, PropertyViewModel>();
                cfg.CreateMap<PropertyOverview, PropertyOverviewViewModel>();
                cfg.CreateMap<AzureBlobImage, ImageViewModel>();
                cfg.CreateMap<Gallery, GalleryViewModel>();
                cfg.CreateMap<Location, LocationViewModel>()
                    .ForMember(dest =>
                        dest.CustomMapImageUrl, opt =>
                            opt.ResolveUsing(res =>
                                Location.CustomMapImageUrlFormat.FormatWith(azureStorageAccountName,
                                    res.Context.Options.Items[Strings.SiteUniqueId])))
                    .ForMember(dest =>
                        dest.CustomDirectionsPdfUrl, opt =>
                            opt.ResolveUsing(res =>
                                Location.CustomDirectionsPdfUrlFormat.FormatWith(azureStorageAccountName,
                                    res.Context.Options.Items[Strings.SiteUniqueId])));

                cfg.RecognizePrefixes(Strings.Rooms);
                cfg.CreateMap<UpdatePropertyOverviewBindingModel, Rooms>();
                cfg.RecognizePrefixes(Strings.Facts);
                cfg.CreateMap<UpdatePropertyOverviewBindingModel, PropertyFacts>();
                cfg.RecognizePrefixes(Strings.Amenities);
                cfg.CreateMap<UpdatePropertyOverviewBindingModel, PropertyAmenities>();
                cfg.CreateMap<UpdatePropertyGalleryBindingModel, Gallery>()
                    .ForMember(d => d.Images, opt => opt.Ignore());
                cfg.CreateMap<UpdatePropertyOverviewBindingModel, PropertyOverview>()
                    .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src))
                    .ForMember(dest => dest.Facts, opt => opt.MapFrom(src => src))
                    .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src));

                cfg.CreateMap<UpdateLocationBindingModel, Location>();

                cfg.CreateMap<WebPage, PageViewModel>();
                cfg.CreateMap<PageBindingModel, WebPage>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> input)
        {
            return input.Select(Mapper.Map<T>);
        }

        public static IEnumerable<SiteViewModel> MapToSiteViewModel(this IEnumerable<RentifySite> input)
        {
            return input.Select(i => i.MapTo<SiteViewModel>(i.UniqueId));
        }

        public static T MapTo<T>(this object input)
        {
            return Mapper.Map<T>(input);
        }

        public static T MapTo<T>(this object input, string siteUniqueId)
        {
            return Mapper.Map<T>(input, opts => opts.Items[Strings.SiteUniqueId] = siteUniqueId);
        }

    }
}