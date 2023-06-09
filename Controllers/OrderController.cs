﻿using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.ExternalModels;
using RestaurantWebAPI.Services.Managers;
using RestaurantWebAPI.Services.UnitsOfWork;

namespace RestaurantWebAPI.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(Guid id)
        {
            var orderEntity = _orderService.GetOrder(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            return Ok(orderEntity);
        }
        [HttpGet]
        [Route("", Name = "GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orderEntities = _orderService.GetAllOrders();
            if (orderEntities == null)
            {
                return NotFound();
            }
            return Ok(orderEntities);
        }
        [HttpGet]
        [Route("details/{id}", Name = "GetOrderDetails")]
        public IActionResult GetOrderDetails(Guid id)
        {
            var orderEntity = _orderService.GetOrderDetails(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            return Ok(orderEntity);
        }
        [HttpPost]
        [Route("add", Name = "AddOrder")]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {
            var orderEntity = _orderService.AddOrder(order);
            return CreatedAtRoute("GetOrder", new { id = orderEntity.ID }, orderEntity);
        }
        [HttpDelete]
        [Route("delete/{id}", Name = "DeleteOrder")]
        public IActionResult DeleteOrder(Guid id)
        {
            var deleteOrder = _orderService.DeleteOrder(id);
            if (deleteOrder == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut]
        [Route("{id}", Name = "UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] OrderDTO order)
        {
            var orderEntity = _orderService.UpdateOrder(order);
            return CreatedAtRoute("GetOrder", new { id = orderEntity.ID }, orderEntity);
        }
    }
}
