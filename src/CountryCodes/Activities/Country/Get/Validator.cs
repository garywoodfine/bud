using System.Data;
using CountryCodes.Activities.Sample.Get;
using FluentValidation;
namespace CountryCodes.Activities.Country.Get
{
    public class Validator : AbstractValidator<Query>
    {
        private const string IncorrectIsoCode = "Incorrect ISO country code value provided";
        public Validator()
        {
            RuleFor(x => x.Code).NotEmpty().Length(2,3).Matches(@"^[a-zA-Z ]+$").WithMessage(IncorrectIsoCode);
            
        }
    }
}