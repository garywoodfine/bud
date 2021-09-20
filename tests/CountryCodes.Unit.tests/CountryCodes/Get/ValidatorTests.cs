using CountryCodes.Activities.Country.Get;
using CountryCodes.Activities.Sample.Get;
using FluentValidation.TestHelper;
using Xunit;

namespace CountryCodes.Unit.tests.CountryCodes.Get
{
    public class ValidatorTests
    {
        private readonly Validator _validator;
        public ValidatorTests()
        {
            _validator = new Validator();
        }
        
        [Fact(DisplayName = "Should have a validation error for empty iso code")]
        public void Should_have_validation_error_for_empty_iso_code()
        {
            var query = new Query();
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Code);
        }
        
        [Fact(DisplayName = "Should have a validation error for iso code longer than 3 characters")]
        public void Should_have_validation_error_for_iso_longer_than_3_characters()
        {
            var query = new Query { Code = "somelongcode"};
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Code);
        }
        
        [Fact(DisplayName = "Should have a validation error for iso code longer than 3 characters")]
        public void Should_have_validation_error_for_iso_shorter_than_2_characters()
        {
            var query = new Query { Code = "a"};
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Code);
        }
        
        [Fact(DisplayName = "Should have a validation error for numeric characters")]
        public void Should_have_validation_error_for_numeric_characters()
        {
            var query = new Query { Code = "123"};
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.Code);
        }
    }
}