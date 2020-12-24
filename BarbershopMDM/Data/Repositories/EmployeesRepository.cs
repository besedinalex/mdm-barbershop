using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    class EmployeesRepository : IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<Employee> GetEmployee(int employeeId) =>
            _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

        /// <inheritdoc />
        public Task<List<Employee>> GetEmployees() =>
            _context.Employees.ToListAsync();

        /// <inheritdoc />
        public async Task<int> CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        /// <inheritdoc />
        public Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task RemoveEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            return _context.SaveChangesAsync();
        }
    }
}
