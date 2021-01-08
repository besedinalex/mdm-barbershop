using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    public interface IEmployeesRepository
    {
        /// <summary>Gets employee.</summary>
        /// <param name="employeeId">Id of the employee.</param>
        /// <returns>Returns employee.</returns>
        Task<Employee> GetEmployee(int employeeId);

        /// <summary>Gets employee.</summary>
        /// <param name="login">Login of the employee.</param>
        /// <returns>Returns employee.</returns>
        Task<Employee> GetEmployee(string login);

        /// <summary>Gets all employees.</summary>
        /// <returns>Returns all employees.</returns>
        Task<List<Employee>> GetEmployees();

        /// <summary>Creates employee.</summary>
        /// <param name="employee">Employee data.</param>
        /// <returns>Returns id of the new employee.</returns>
        Task<int> CreateEmployee(Employee employee);

        /// <summary>Updates employee.</summary>
        /// <param name="employee">Employee data.</param>
        Task UpdateEmployee(Employee employee);

        /// <summary>Removes employee.</summary>
        /// <param name="employee">Employee data.</param>
        Task RemoveEmployee(Employee employee);
    }
}
