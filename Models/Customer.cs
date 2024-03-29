﻿using System.ComponentModel.DataAnnotations;

namespace Ass2_PRN221.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Password { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
