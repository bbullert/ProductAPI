﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int Number { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
