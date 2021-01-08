using System;
using System.Collections.Generic;

namespace BarbershopMDM.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public int Cost { get; set; }

        public int OrdererId { get; set; }

        public Employee Orderer { get; set; }

        public DateTime TimeOrdered { get; set; }

        public int? FinisherId { get; set; }

        public Employee Finisher { get; set; }

        public DateTime? TimeCompleted { get; set; }

        public ICollection<OrderContent> OrderContents { get; set; }
    }
}
