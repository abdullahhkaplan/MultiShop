using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _OrderDetailRepository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _OrderDetailRepository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            
            values.OrderingId = updateOrderDetailCommand.OrderingId;
            values.ProductId    = updateOrderDetailCommand.ProductId;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;

            await _OrderDetailRepository.UpdateAsync(values);
        }
    }
}
