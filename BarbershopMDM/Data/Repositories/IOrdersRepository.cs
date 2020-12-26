﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    interface IOrdersRepository
    {
        /// <summary>Gets order.</summary>
        /// <param name="orderId">Id of the order.</param>
        /// <returns>Returns order.</returns>
        Task<Order> GetOrder(int orderId);

        /// <summary>Get order's content.</summary>
        /// <param name="orderId">Id of the order.</param>
        /// <returns>Returns order's content.</returns>
        Task<List<OrderContent>> GetOrdersContent(int orderId);

        /// <summary>Gets all orders.</summary>
        /// <returns>Returns all orders.</returns>
        Task<List<Order>> GetOrders();

        /// <summary>Get all employee orders.</summary>
        /// <param name="employeeId">Id of the employee orders.</param>
        /// <returns>Returns all employee's orders.</returns>
        Task<List<Order>> GetEmployeeOrders(int employeeId);

        /// <summary>Creates order.</summary>
        /// <param name="order">Order data.</param>
        /// <returns>Returns id of the new order.</returns>
        Task<int> CreateOrder(Order order);

        /// <summary>Creates order content.</summary>
        /// <param name="orderContent">Order content to create.</param>
        Task CreateOrderContent(List<OrderContent> orderContent);

        /// <summary>Updates order.</summary>
        /// <param name="order">Order data.</param>
        Task UpdateOrder(Order order);

        /// <summary>Updates order content.</summary>
        /// <param name="orderContent">Order content to update.</param>
        Task UpdateOrderContent(List<OrderContent> orderContent);

        /// <summary>Removes order and it's content.</summary>
        /// <param name="order">Order data.</param>
        Task RemoveOrder(Order order);

        /// <summary>Removes order and it's content.</summary>
        /// <param name="orderContent">Order content to remove.</param>
        Task RemoveOrderContent(List<OrderContent> orderContent);
    }
}
