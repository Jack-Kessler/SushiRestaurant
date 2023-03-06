using SushiRestaurant.Models;

namespace SushiRestaurant
{
    public interface IMenuItemRepository
    {
        public IEnumerable<MenuItem> GetAllMenuItems();
    }
}
