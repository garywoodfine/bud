using AutoMapper;
using CountryCodes.Activities.Sample.Get;

namespace CountryCodes.Activities.Country.Get
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<WorldBank.Country, Response>()
              .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.CapitalCity, opt => opt.MapFrom(src => src.CapitalCity))
                .ForMember(x => x.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(x => x.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(x => x.Region, opt => opt.MapFrom(src => src.Region.Value));
            
        }
    }
}