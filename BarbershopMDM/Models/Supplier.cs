using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarbershopMDM.Models
{
    class Supplier
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string ContactNumber { get; set; }

        public ulong OGRN { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
