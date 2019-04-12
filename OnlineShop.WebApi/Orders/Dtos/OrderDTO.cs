using System;
using System.Collections.Generic;
using OnlineShop.WebApi.Products.Dtos;

namespace OnlineShop.WebApi.Orders.Dtos
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<ProductForListDTO> Products { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public DateTime? DateOfShipment { get; set; }
    }
}