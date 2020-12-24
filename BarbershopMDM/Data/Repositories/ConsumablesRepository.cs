using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    class ConsumablesRepository : IConsumablesRepository
    {
        private readonly DataContext _context;

        public ConsumablesRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<Consumables> GetConsumable(int consumableId) =>
            _context.Consumables.FirstOrDefaultAsync(x => x.Id == consumableId);

        /// <inheritdoc />
        public Task<List<Consumables>> GetConsumables() =>
            _context.Consumables.ToListAsync();

        /// <inheritdoc />
        public async Task<int> CreateConsumable(Consumables consumable)
        {
            await _context.Consumables.AddAsync(consumable);
            await _context.SaveChangesAsync();
            return consumable.Id;
        }

        /// <inheritdoc />
        public Task UpdateConsumable(Consumables consumable)
        {
            _context.Consumables.Update(consumable);
            return _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task UpdateConsumables(List<Consumables> consumables)
        {
            _context.Consumables.UpdateRange(consumables);
            return _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task RemoveConsumable(Consumables consumable)
        {
            _context.Consumables.Remove(consumable);
            return _context.SaveChangesAsync();
        }
    }
}
