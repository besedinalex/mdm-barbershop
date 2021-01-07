using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarbershopMDM.Models
{
    class Employee
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Login { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Role { get; set; }

        public ICollection<Order> OrdersCreated { get; set; }

        public ICollection<Order> OrdersCompleted { get; set; }
    }
}
