using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EfCore_Net5.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Addreess { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string OrderrName { get; set; }
        public int Quantity { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
