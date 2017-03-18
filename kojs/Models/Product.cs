using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace kojs.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}