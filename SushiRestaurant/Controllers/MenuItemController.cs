using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SushiRestaurant.Models;

namespace SushiRestaurant.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemRepository repo;

        public MenuItemController(IMenuItemRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var menuItems = repo.GetAllMenuItemsSQL();
            return View(menuItems);
        }

        public IActionResult ViewMenuItem(int menuItemID)
        {
            var menuItem = repo.GetMenuItemSQL(menuItemID);
            return View(menuItem);
        }

        public IActionResult UpdateMenuItem(int menuItemID)
        {
            MenuItem tempItem = repo.GetMenuItemSQL(menuItemID);
            if (tempItem == null)
            {
                return View("ProductNotFound");
            }
            return View(tempItem);
        }

        public IActionResult UpdateMenuItemToDatabase(MenuItem menuItem)
        {
            repo.UpdateMenuItemSQL(menuItem);
            return RedirectToAction("ViewMenuItem", new {menuItemID = menuItem.MenuItemID});
        }

        public IActionResult InsertMenuItem()
        {
            var menuItem = repo.AssignMenuItemCategorySQL();
            return View(menuItem);
        }

        public IActionResult InsertMenuItemToDatabase(MenuItem menuItemToInsert)
        {
            repo.InsertMenuItemSQL(menuItemToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMenuItem(MenuItem item)
        {
            repo.DeleteMenuItemSQL(item);
            return RedirectToAction("Index");
        }
    }
}
