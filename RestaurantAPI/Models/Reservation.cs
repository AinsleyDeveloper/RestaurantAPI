using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public Reservation(int reservationId, string customerFirstName, string customerLastName, string cellNumber, int tableId, DateTime dateTime )
        {
            ReservationId = reservationId;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CellNumber = cellNumber;
            DateTime = dateTime;
            TableId = tableId;
        }

        public int ReservationId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateTime { get; set; }
        public int TableId { get; set; }
    }
}