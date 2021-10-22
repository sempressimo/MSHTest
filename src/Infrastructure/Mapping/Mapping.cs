using AutoMapper;
using MSHTest.Common.DTO;
using MSHTest.TaxJar.Client.Model;
using System;

namespace Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxJarRate, LocationTaxRateResultsDTO>();
            CreateMap<TaxJarTax, TaxForOrderResultsDTO>();
            CreateMap<TaxJarJurisdictions, JurisdictionsDTO>();

            CreateMap<TaxForOrderRequestDTO, TaxJarTaxForOrderRequest>();
        }
    }

    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
