using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RollerShop.Models
{
    public class Maker
    {
        [Key]
        public int IdMaker { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }
}