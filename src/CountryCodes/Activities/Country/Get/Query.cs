using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CountryCodes.Activities.Sample.Get
{
    public class Query : IRequest<Response>
    {
        [FromRoute(Name = "iso")] public string Code { get; set; }
    }
}