﻿using AutoMapper;
using RestaurantWebAPI.Entities;
using RestaurantWebAPI.ExternalModels;
using RestaurantWebAPI.Services.Repositories;
using RestaurantWebAPI.Services.UnitsOfWork;

namespace RestaurantWebAPI.Services.Managers
{
    public class OrderService
    {
        private readonly IOrderUnitOfWork _orderUnit;
        private readonly IMapper _mapper;

        public OrderService(IOrderUnitOfWork orderunit, IMapper mapper)
        {
            _orderUnit = orderunit ?? throw new ArgumentNullException(nameof(orderunit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public OrderDTO GetOrder(Guid id)
        {
            var orderEntity = _orderUnit.Orders.Get(id);
            return _mapper.Map<OrderDTO>(orderEntity);
        }

        public List<OrderDTO> GetAllOrders()
        {
            var orderEntities = _orderUnit.Orders.Find(o => o.Deleted == false || o.Deleted == null);
            return _mapper.Map<List<OrderDTO>>(orderEntities);
        }

        public OrderDTO GetOrderDetails(Guid id)
        {
            var orderEntity = _orderUnit.Orders.GetOrderDetails(id);
            return _mapper.Map<OrderDTO>(orderEntity);
        }

        public OrderDTO AddOrder(OrderDTO order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _orderUnit.Orders.Add(orderEntity);
            _orderUnit.Complete();
            return _mapper.Map<OrderDTO>(orderEntity);
        }

        public bool DeleteOrder(Guid id)
        {
            var orderEntity = _orderUnit.Orders.Get(id);
            if (orderEntity == null)
            {
                return false;
            }
            orderEntity.Deleted = true;
            _orderUnit.Orders.Remove(orderEntity);
            _orderUnit.Complete();
            return true;
        }

        public OrderDTO UpdateOrder(OrderDTO order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _orderUnit.Orders.Update(orderEntity);
            _orderUnit.Complete();
            return _mapper.Map<OrderDTO>(orderEntity);
        }

    }
}
