using Dapper;
using SushiRestaurant.Models;
using System.Data;

namespace SushiRestaurant
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly IDbConnection _conn;

        public MenuItemRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _conn.Query<MenuItem>("SELECT * FROM menu_items");
        }
    }
}
