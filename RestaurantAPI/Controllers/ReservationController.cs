using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantAPI.Models;
using RestaurantAPI.Repositories;

namespace RestaurantAPI.Controllers
{
    [RoutePrefix("api/reservation")]
    public class ReservationController : ApiController
    {
        private ReservationRepository _reservationRepository = null;

        public ReservationController()
        {
            _reservationRepository = new ReservationRepository();
        }

        [HttpGet]
        [Route("getreservationbyid/{reservationId}")]
        public ApiResponse GetReservationByID(int reservationId)
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                Reservation reservation = _reservationRepository.GetReservationByID(reservationId);
                response.Response = reservation;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An error has occurred while trying to retrieve a reservation for reservationId: {0}.", reservationId), ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("getallreservations")]
        public ApiResponse GetAllReservations()
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                List<Reservation> reservations = _reservationRepository.GetAllReservations();
                response.Response = reservations;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An Error jas occurred while trying to retrieve all reservations."), ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("insertreservation")]
        public ApiResponse InsertReservation(Reservation reservation)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _reservationRepository.InsertReservation(reservation);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to create the reservation.", ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("updatereservation/{reservationId}")]
        public ApiResponse UpdateReservation(Reservation reservation)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _reservationRepository.UpdateReservation(reservation);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to update reservation.", ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("deletereservationbyid/{reservationId}")]
        public ApiResponse DeleteReservationByID(int reservationId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _reservationRepository.DeleteReservationByID(reservationId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a reservation.", ex.Message);
            }

            return response;
        }
    }
}
