using System.Collections;
using System.Collections.Generic;
using SushiRestaurant.Models;

namespace SushiRestaurant
{
    public interface IMenuItemRepository
    {
        public IEnumerable<MenuItem> GetAllMenuItemsSQL();
        public MenuItem GetMenuItemSQL(int menuItemID);
        public void UpdateMenuItemSQL(MenuItem menuItem);
        public void InsertMenuItemSQL(MenuItem menuItemToInsert);
        public IEnumerable<MenuItemCategory> GetMenuItemCategoriesSQL();
        public MenuItem AssignMenuItemCategorySQL();
        public void DeleteMenuItemSQL(MenuItem item);
    }
}
