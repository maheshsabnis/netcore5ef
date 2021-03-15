using System;
using System.Collections.Generic;
using System.Linq;
using EfCore_Net5.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EfCore_Net5
{
    class Program
    {
        static void Main(string[] args)
        {
            EFCore5DbContext context = new EFCore5DbContext();
            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer() {  CustomerName="Mahesh",Addreess="Pune"});
            //customers.Add(new Customer() {  CustomerName = "Tejas", Addreess = "Pune" });
            //List<Order> orders = new List<Order>();
            //orders.Add(new Order() { OrderrName="Laptop",Quantity=100});
            //orders.Add(new Order() {  OrderrName = "Desktop", Quantity = 110 });

            //Customer customer = new Customer();
            //customer.CustomerName = "Leena";
            //customer.Addreess = "Pune";
            //customer.Orders = orders;
            //context.Customers.Add(customer);
            //context.Customers.AddRange(customers);
            //context.Orders.AddRange(orders);
            //context.SaveChanges();

            //var data = context.Customers
            //            .Include(o => o.Orders).ToList();

            //foreach (var item in data)
            //{
            //    Console.WriteLine($"{item.CustomerId} {item.CustomerName} {item.Addreess}");
            //    foreach (var ord in item.Orders)
            //    {
            //        Console.WriteLine($"{ord.OrderId} {ord.OrderrName} {ord.Quantity}");
            //    }
            //}


            Movie movie = new Movie();
            movie.Name = "No Time to Die";
            movie.Release = new DateTime();
            movie.DurationInMinutes = 180;
            movie.WorldwideBoxOfficeGross = 56000;

            context.Productions.Add(movie);
            context.SaveChanges();

            Console.WriteLine("Data Saved Successfully.....");
            Console.ReadLine();
        }
    }
}
