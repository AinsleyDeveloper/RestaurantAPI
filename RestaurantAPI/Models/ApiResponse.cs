using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {

        }

        public ApiResponse(string message, string exceptionMessage, Object response)
        {
            Response = response;
        }
        public Error Error { get; private set; }
        public Object Response { get; set; }
        public bool Successful { get { return Error == null; } }

        public void CreateError(string errorMessage, string exceptionMessage)
        {
            Error = new Error(errorMessage, exceptionMessage);
        }
    }
}