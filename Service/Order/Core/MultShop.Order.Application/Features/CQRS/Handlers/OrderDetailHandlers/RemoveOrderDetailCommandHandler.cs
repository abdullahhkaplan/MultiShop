using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _OrderDetailRepository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
        }
        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var value = await _OrderDetailRepository.GetByIdAsync(command.Id);
            await _OrderDetailRepository.DeleteAsync(value);
        }
    }
}
}
