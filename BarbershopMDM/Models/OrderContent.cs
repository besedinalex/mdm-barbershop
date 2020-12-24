namespace BarbershopMDM.Models
{
    class OrderContent
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ConsumablesId { get; set; }

        public Consumables Consumables { get; set; }

        public int ConsumablesAmount { get; set; }
    }
}
