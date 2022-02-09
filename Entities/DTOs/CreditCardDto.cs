using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditCardDetailDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string FindeksScore { get; set; }
    }
}
