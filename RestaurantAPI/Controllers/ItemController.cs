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
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        private ItemRepository _itemRepository = null;

        public ItemController()
        {
            _itemRepository = new ItemRepository();
        }

        [HttpGet]
        [Route("getitembyid/{itemId}")]
        public ApiResponse GetItemByID(int itemId)
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                 Item item = _itemRepository.GetItemByID(itemId);
                response.Response = item;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An error has occurred while trying to retrieve a item for itemId: {0}.", itemId), ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("getallitems")]
        public ApiResponse GetAllItems()
        {
            ApiResponse response = null;
            try
            {
                response = new ApiResponse();
                List<Item> items = _itemRepository.GetAllItems();
                response.Response = items;
            }
            catch (Exception ex)
            {
                response.CreateError(String.Format("An Error has occurred while trying to retrieve all items."), ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("insertitem")]
        public ApiResponse InsertItem(Item item)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _itemRepository.InsertItem(item);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to create the item.", ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("updateitem")]
        public ApiResponse UpdateItem(Item item)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _itemRepository.UpdateItem(item);
            }
            catch (Exception ex)
            {
                response.CreateError("An error has occurred while trying to update item.", ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("deleteitembyid/{itemId}")]
        public ApiResponse DeleteItemByID(int itemId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                bool isSuccessful = _itemRepository.DeleteItemByID(itemId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to delete a item.", ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("gettableitems/tableId/{tableId}/waiterId/{waiterId}")]
        public ApiResponse GetTableItems(int tableId, int waiterId)
        {
            ApiResponse response = null;

            try
            {
                response = new ApiResponse();
                response.Response= _itemRepository.GetTableItems(waiterId, tableId);
            }
            catch (Exception ex)
            {
                response.CreateError("An error occurred while trying to get all items for the table.", ex.Message);
            }

            return response;
        }

    }
}

