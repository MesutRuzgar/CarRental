using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class BrandDetailDto:IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
