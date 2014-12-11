using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Rentify.Core.Domain;
using Rentify.WebServer.Models;

namespace Rentify.WebServer
{
    public static class AutomapperConfig
    {
        public static void Setup()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RentifySite, SiteViewModel>();
                cfg.CreateMap<SiteBindingModel, RentifySite>().ForMember(dest => dest.Pages, opt => opt.Ignore());

                cfg.CreateMap<WebPage, PageViewModel>();
                cfg.CreateMap<PageBindingModel, WebPage>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> input)
        {
            return input.Select(Mapper.Map<T>);
        }

        public static T MapTo<T>(this object input)
        {
            return Mapper.Map<T>(input);
        }

    }
}