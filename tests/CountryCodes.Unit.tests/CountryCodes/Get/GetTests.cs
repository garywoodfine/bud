using System;
using System.Threading.Tasks;
using CountryCodes.Activities.Sample.Get;
using CountryCodes.Content.Exceptions;
using FizzWare.NBuilder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace CountryCodes.Unit.tests.CountryCodes.Get
{
    public class GetTests
    {
        private readonly Content.Activities.Country.Get _classUnderTest;
        private Mock<IMediator> _mediator;
        public GetTests()
        {
            _mediator = new Mock<IMediator>();
            _classUnderTest = new Content.Activities.Country.Get(_mediator.Object);
        }
        [Fact]
        public async Task Should_return_ok_object_result_with_country_response()
        {
            // Arrange
            var request = Builder<Query>.CreateNew().Build();
            var response = Builder<Response>.CreateNew().Build();
            _mediator.Setup(x => x.Send(It.IsAny<Query>(), default)).ReturnsAsync(response);
            // Act 
            var result = await _classUnderTest.HandleAsync(request, default);
            
            // Assert
            result.ShouldNotBeNull();
            result.Result.ShouldBeOfType<OkObjectResult>();
            result.ShouldSatisfyAllConditions();

            var okResult = result.Result as OkObjectResult;
            okResult.Value.ShouldBeOfType<Response>();
            okResult.ShouldSatisfyAllConditions();
        }
        [Fact]
        public async Task Should_return_404_response()
        {
            // Arrange
            var request = Builder<Query>.CreateNew().Build();
            _mediator.Setup(x => x.Send(It.IsAny<Query>(), default)).ReturnsAsync((Func<Response>) null);
            // Act 
            var result = await _classUnderTest.HandleAsync(request, default);
            
            // Assert
            result.ShouldNotBeNull();
            result.Result.ShouldBeOfType<NotFoundResult>();
            result.ShouldSatisfyAllConditions();
        }
        
        [Fact]
        public async Task Should_return_400_response_on_exception()
        {
            // Arrange
            var request = Builder<Query>.CreateNew().Build();
            _mediator.Setup(x => x.Send(It.IsAny<Query>(), default)).Throws(new CountryCodeException(""));
            // Act 
            var result = await _classUnderTest.HandleAsync(request, default);
            
            // Assert
            result.ShouldNotBeNull();
            result.Result.ShouldBeOfType<BadRequestObjectResult>();
            result.ShouldSatisfyAllConditions();
        }
    }
}