using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.Interfaces
{
    interface IBillRepository
    {
        bool InsertBill (Bill Bill);
        bool UpdateBill (Bill Bill);
        bool DeleteBillByID (int BillId);
        Bill GetBillByID(int BillId);
        List<Bill> GetAllBills();
        bool SettleBill(int waiterId, int tableId);
    }
}
