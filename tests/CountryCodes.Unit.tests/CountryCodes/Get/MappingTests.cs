using AutoMapper;
using CountryCodes.Activities.Country.Get;
using CountryCodes.Activities.Sample.Get;
using FizzWare.NBuilder;
using Shouldly;
using WorldBank;
using Xunit;

namespace CountryCodes.Unit.tests.CountryCodes.Get
{
    public class MappingTests
    {
        private IMapper _mapper;
        
        public MappingTests()
        {
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<Mapping>());
            mapperConfiguration.AssertConfigurationIsValid();
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void Should_Entity_to_Data_Transmission_Object()
        {
            var response = _mapper.Map<Response>(TestCountry);

            response.ShouldNotBeNull();
            response.CountryName.ShouldBeEquivalentTo(TestCountry.Name);
            response.Region.ShouldBeEquivalentTo(TestCountry.Region.Value);
            response.Latitude.ShouldBeEquivalentTo(TestCountry.Latitude);
            response.Longitude.ShouldBeEquivalentTo(TestCountry.Longitude);
            response.ShouldSatisfyAllConditions();
           
        }

        private static Country TestCountry => Builder<Country>
            .CreateNew()
            .With(x => x.Region = Builder<Adminregion>
                .CreateNew()
                .Build()
            ).Build();
    }
}