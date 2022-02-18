using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DailyPrice { get; set; }
        public List<CarImage> CarImage { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
     

    }
}
