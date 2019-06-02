using RollerShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollerShop.Models
{
    public class AllObjects
    {
        public Product Product { get; set; }
        public Maker Maker { get; set; }
        public Category Category { get; set; }
        public Cart Cart { get; set; }
    }
}