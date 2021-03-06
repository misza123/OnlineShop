using System;
using System.Collections.Generic;
using OnlineShop.WebApi.Users;

namespace OnlineShop.WebApi.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public DateTime DateOfShipment { get; set; }
    }
}