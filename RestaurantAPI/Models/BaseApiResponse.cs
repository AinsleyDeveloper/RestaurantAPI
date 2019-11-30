using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public abstract class BaseApiResponse
    {
        public BaseApiResponse()
        {

        }

        protected Error Error { get; set; }
    }
}