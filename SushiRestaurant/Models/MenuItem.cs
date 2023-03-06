namespace SushiRestaurant.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
        }

        public int MenuItemID { get; set; }
        public string MenuItemName { get; set; }
        public double MenuItemPrice { get; set; }

        public string MenuItemCategory { get; set; }

        public string MenuItemIngredient { get; set; }

    }
}
