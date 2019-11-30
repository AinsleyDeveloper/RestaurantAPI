using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories.Interfaces
{
    interface IReservationRepository
    {
        bool InsertReservation(Reservation reservation);
        bool UpdateReservation(Reservation reservation);
        bool DeleteReservationByID(int reservationId);
        Reservation GetReservationByID(int reservationId);
        List<Reservation> GetAllReservations();
    }
}
