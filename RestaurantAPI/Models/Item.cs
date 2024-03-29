﻿using RestaurantAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class Item
    {
        public Item()
        {

        }

        public Item(int itemId, string name, string description, decimal price)
        {
            ItemId = itemId;
            Name = name;
            Description = description;
            Price = price;
        }

        public int ItemId {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}