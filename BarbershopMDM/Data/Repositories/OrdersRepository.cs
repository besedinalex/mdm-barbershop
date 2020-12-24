using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    class OrdersRepository : IOrdersRepository
    {
        private readonly DataContext _context;

        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<Order> GetOrder(int orderId) =>
            _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

        /// <inheritdoc />
        public Task<List<Order>> GetOrders() =>
            _context.Orders.ToListAsync();

        /// <inheritdoc />
        public Task<List<OrderContent>> GetOrdersContent(int orderId) =>
            _context.OrderContents.Where(x => x.OrderId == orderId).ToListAsync();

        /// <inheritdoc />
        public async Task<int> CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        /// <inheritdoc />
        public async Task CreateOrderContent(List<OrderContent> orderContent)
        {
            await _context.OrderContents.AddRangeAsync(orderContent);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            return _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task UpdateOrderContent(List<OrderContent> orderContent)
        {
            _context.OrderContents.UpdateRange(orderContent);
            return _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveOrder(Order order)
        {
            var orderContent = await _context.OrderContents.Where(x => x.OrderId == order.Id).ToListAsync();
            _context.OrderContents.RemoveRange(orderContent);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task RemoveOrderContent(List<OrderContent> orderContent)
        {
            _context.OrderContents.RemoveRange(orderContent);
            return _context.SaveChangesAsync();
        }
    }
}
