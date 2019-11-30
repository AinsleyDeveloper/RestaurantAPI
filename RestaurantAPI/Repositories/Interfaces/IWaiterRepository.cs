using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.Interfaces
{
    public interface IWaiterRepository
    {
        bool InsertWaiter (Waiter waiter);
        bool UpdateWaiter (Waiter waiter);
        bool DeleteWaiterByID (int waiterId);
        Waiter GetWaiterByID (int waiterId);
        Waiter GetWaiterByUsernameAndPassword(string login, string password);
        List<Waiter> GetAllWaiters ();
    }
}
