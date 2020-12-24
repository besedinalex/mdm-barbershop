using System;
using System.Collections.Generic;

namespace BarbershopMDM.Models
{
    class Order
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public int Cost { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime TimeCompleted { get; set; }

        public ICollection<OrderContent> OrderContents { get; set; }
    }
}
