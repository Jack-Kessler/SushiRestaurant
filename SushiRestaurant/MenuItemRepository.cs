using Dapper;
using SushiRestaurant.Models;
using System.Data;
using System.Collections.Generic;

namespace SushiRestaurant
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly IDbConnection _conn;

        public MenuItemRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<MenuItem> GetAllMenuItemsSQL()
        {
            return _conn.Query<MenuItem>("SELECT * FROM MENU_ITEMS;");
        }

        public MenuItem GetMenuItemSQL(int id)
        {
            return _conn.QuerySingle<MenuItem>("SELECT * FROM MENU_ITEMS WHERE MenuItemID = @menuItemID;", new { menuItemID = id });
        }

        public void UpdateMenuItemSQL(MenuItem menuItem)
        {
            _conn.Execute("UPDATE menu_items SET MenuItemName = @menuItemName, MenuItemPrice = @menuItemPrice WHERE MenuItemID = @id;",
            new { menuItemName = menuItem.MenuItemName, menuItemPrice = menuItem.MenuItemPrice, id = menuItem.MenuItemID });
        }

        public void InsertMenuItemSQL(MenuItem menuItemToInsert)
        {
            _conn.Execute("INSERT INTO menu_items (MenuItemName, MenuItemPrice, MenuItemCategory) VALUES (@name, @price, @categoryID);",
                new {name = menuItemToInsert.MenuItemName, price = menuItemToInsert.MenuItemPrice, menuItemID = menuItemToInsert.MenuItemID });
        }
        public IEnumerable<MenuItemCategory> GetMenuItemCategoriesSQL()
        {
            return _conn.Query<MenuItemCategory>("SELECT * FROM menu_categories;");
        }
        public MenuItem AssignMenuItemCategorySQL()
        {
            var menuItemCategoryList = GetMenuItemCategoriesSQL();
            var menuItem = new MenuItem();
            menuItem.Categories = menuItemCategoryList; //Models -> Categories property
            return menuItem;
        }
    }
}
