using BarbershopMDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarbershopMDM.Data.Repositories
{
    public interface IConsumablesRepository
    {
        /// <summary>Gets consumable item.</summary>
        /// <param name="consumableId">Id of the consumable item.</param>
        /// <returns>Returns consumable item.</returns>
        Task<Consumables> GetConsumable(int consumableId);

        /// <summary>Gets all consumables.</summary>
        /// <returns>Returns all consumables.</returns>
        Task<List<Consumables>> GetConsumables();

        /// <summary>Creates consumable item.</summary>
        /// <param name="consumable">Consumable item data.</param>
        /// <returns>Returns id of the new consumable item.</returns>
        Task<int> CreateConsumable(Consumables consumable);

        /// <summary>Updates consumable item.</summary>
        /// <param name="consumable">Consumable item data.</param>
        Task UpdateConsumable(Consumables consumable);

        /// <summary>Updates consumable items.</summary>
        /// <param name="consumables">Consumable items data.</param>
        Task UpdateConsumables(List<Consumables> consumables);

        /// <summary>Removes consumable item.</summary>
        /// <param name="consumable">Consumable item data.</param>
        Task RemoveConsumable(Consumables consumable);
    }
}
