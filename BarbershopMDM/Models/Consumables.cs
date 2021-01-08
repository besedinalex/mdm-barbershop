using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarbershopMDM.Models
{
    public class Consumables
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public int CurrentAmount { get; set; }

        public ICollection<OrderContent> OrdersContents { get; set; }
    }
}
