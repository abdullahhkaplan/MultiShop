using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public UpdateAdressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressId);
            values.Detail=updateAddressCommand.Detail;
            values.City=updateAddressCommand.City;
            values.District=updateAddressCommand.District;
            values.UserId=updateAddressCommand.UserId;
            await _addressRepository.UpdateAsync(values);
        }
    }
}
