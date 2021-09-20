using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CountryCodes.Content.Providers;
using MediatR;

namespace CountryCodes.Activities.Sample.Get
{
    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IProvider<WorldBank.Country> _provider;
        private readonly IMapper _mapper;

        public Handler(IProvider<WorldBank.Country> provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }
        public async Task<Response> Handle(Query query, CancellationToken cancellationToken)
        {
            try
            {
                var country = await _provider.Get(query.Code);
                return country != null ? _mapper.Map<Response>(country) : null;
            }
            catch (Exception e)
            {
                return null;
            }
        
        }
    }
}