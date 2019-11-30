using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.Interfaces
{
    public interface IItemRepository
    {
        bool InsertItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItemByID(int itemId);
        Item GetItemByID(int itemId);
        List<Item> GetAllItems();
        List<Item> GetTableItems(int waiterId, int tableId);
    }
}
