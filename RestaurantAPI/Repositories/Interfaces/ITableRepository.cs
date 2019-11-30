using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.Interfaces
{
    interface ITableRepository
    {
        bool InsertTable(Table table);
        bool UpdateTable(Table table);
        bool DeleteTableByID(int tableId);
        Table GetTableByID(int tableId);
        List<Table> GetAllTables();
        List<Table> GetAllTablesAvailableToWaiter(int waiterId);
    }
}
