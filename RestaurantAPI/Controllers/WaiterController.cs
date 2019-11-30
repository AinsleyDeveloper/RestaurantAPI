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
    [RoutePrefix("api/waiter")]
    public class WaiterController : ApiController
    {
        private WaiterRepository _waiterRepository = null;

        public WaiterController()
        {
            _waiterRepository = new WaiterRepository();
        }

        [HttpGet]
        [Route("getwaiterbyid/{waiterId}")]
        public ApiResponse GetWaiterByID(int waiterId)
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                 Waiter waiter = _waiterRepository.GetWaiterByID(waiterId);
                response.Response = waiter;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An error has occurred while trying to retrieve a waiter for waiterId: {0}.", waiterId), ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("waiterlogin")]
        public ApiResponse GetWaiterByUsernameAndPassword(LoginRequest request)
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                Waiter waiter = _waiterRepository.GetWaiterByUsernameAndPassword(request.Username, request.Password);
                response.Response = waiter;
            }
            catch(Exception ex)
            {
                response.CreateError(String.Format("An error has occurred while trying to retrieve a waiter by username or password."), ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("getallwaiters")]
        public ApiResponse GetAllWaiters()
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                List<Waiter> waiters = _waiterRepository.GetAllWaiters();
                response.Response = waiters;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An Error jas occurred while trying to retrieve all waiters."), ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("insertwaiter")]
        public ApiResponse InsertWaiter(Waiter waiter)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _waiterRepository.InsertWaiter(waiter);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to create the waiter.", ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("updatewaiter")]
        public ApiResponse UpdateWaiter(Waiter waiter)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _waiterRepository.UpdateWaiter(waiter);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to update waiter.", ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("deletewaiterbyid/{waiterId}")]
        public ApiResponse DeleteWaiterByID(int waiterId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _waiterRepository.DeleteWaiterByID(waiterId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a waiter.", ex.Message);
            }

            return response;
        }
    }
}
