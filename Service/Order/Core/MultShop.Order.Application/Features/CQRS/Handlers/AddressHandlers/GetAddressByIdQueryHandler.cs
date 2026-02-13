using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<GetAddressByIdQueryResult> GetAddressByIdQueryResultAsync(GetAddressByIdQuery query)
        {
            var values= await _addressRepository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = query.Id,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId

            };

        }
    }
}
