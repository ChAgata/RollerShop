﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RollerShop.Models
{
    public class Product
    {
        [Key] public int IdProduct { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int IdMaker { get; set; }
        public int IdCategory { get; set; }
    }
}