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
        public Task<List<OrderContent>> GetOrdersContent(int orderId) =>
            _context.OrderContents.Where(x => x.OrderId == orderId).ToListAsync();

        /// <inheritdoc />
        public Task<List<Order>> GetOrders() =>
            _context.Orders.ToListAsync();

        /// <inheritdoc />
        public async Task<List<Order>> GetEmployeeOrders(int employeeId)
        {
            var ordersCreated = await _context.Orders.Where(x => x.OrdererId == employeeId).ToListAsync();
            var ordersFinished = await _context.Orders.Where(x => x.FinisherId == employeeId).ToListAsync();

            var response = new List<Order>();
            response.AddRange(ordersCreated);
            response.AddRange(ordersFinished);
            return response;
        }

        /// <inheritdoc />
        public Task<List<Order>> GetSupplierOrders(int supplierId) =>
            _context.Orders.Where(x => x.SupplierId == supplierId).ToListAsync();

        /// <inheritdoc />
        public Task<List<OrderContent>> GetOrderContentsWithConsumables(int consumablesId) =>
            _context.OrderContents.Where(x => x.ConsumablesId == consumablesId).ToListAsync();

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
        public async Task RemoveOrder(Order order)
        {
            var orderContent = await _context.OrderContents.Where(x => x.OrderId == order.Id).ToListAsync();
            _context.OrderContents.RemoveRange(orderContent);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
