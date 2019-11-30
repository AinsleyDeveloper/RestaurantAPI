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
    [RoutePrefix("api/table")]
    public class TableController : ApiController
    {
        private TableRepository _tableRepository = null;

        public TableController()
        {
            _tableRepository = new TableRepository();
        }

        [HttpGet]
        [Route("gettablebyid/{tableId}")]
        public ApiResponse GetTableByID(int tableId)
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                Table table = _tableRepository.GetTableByID(tableId);
                response.Response = table;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An error has occurred while trying to retrieve a table for TableId: {0}.", tableId), ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("getalltables")]
        public ApiResponse GetAllTables()
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                List<Table> tables = _tableRepository.GetAllTables();
                response.Response = tables;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An Error has occurred while trying to retrieve all tables."), ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("inserttable")]
        public ApiResponse InsertTable(Table table)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _tableRepository.InsertTable(table);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to create the table.", ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("updatetable")]
        public ApiResponse UpdateTable(Table table)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _tableRepository.UpdateTable(table);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to update table.", ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("deletetablebyid/{tableId}")]
        public ApiResponse DeleteTableByID(int tableId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _tableRepository.DeleteTableByID(tableId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a table.", ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("getwaitertables/{waiterId}")]
        public ApiResponse GetAllTablesAvailableToWaiter(int waiterId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                response.Response = _tableRepository.GetAllTablesAvailableToWaiter(waiterId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a table.", ex.Message);
            }

            return response;
        }

    }
}
