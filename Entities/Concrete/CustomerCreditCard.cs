using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerCreditCard:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
    }
}
