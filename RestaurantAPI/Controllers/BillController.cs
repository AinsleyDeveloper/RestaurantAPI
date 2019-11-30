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
    [RoutePrefix("api/bill")]
    public class BillController : ApiController
    {
        private BillRepository _billRepository = null;

        public BillController()
        {
            _billRepository = new BillRepository();
        }

        [HttpGet]
        [Route("getbillbyid/{billId}")]
        public ApiResponse GetBillByID(int billId)
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                Bill bill = _billRepository.GetBillByID(billId);
                response.Response = bill;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An error has occurred while trying to retrieve a bill for BillId: {0}.", billId), ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("getallbills")]
        public ApiResponse GetAllBills()
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                List<Bill> bills = _billRepository.GetAllBills();
                response.Response = bills;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An Error jas occurred while trying to retrieve all bills."), ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("insertbill")]
        public ApiResponse InsertBill(Bill bill)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _billRepository.InsertBill(bill);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to create the bill.", ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("updatebill")]
        public ApiResponse UpdateBill(Bill bill)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _billRepository.UpdateBill(bill);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to update bill.", ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("deletebillbyid/{billId}")]
        public ApiResponse DeleteBillByID(int billId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _billRepository.DeleteBillByID(billId);
            }
            catch(Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a bill.", ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("settlebill/tableId/{tableId}/waiterId/{waiterId}")]
        public ApiResponse SettleBill (int tableId, int waiterId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _billRepository.SettleBill(waiterId, tableId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a bill.", ex.Message);
            }

            return response;
        }

    }
}
