﻿using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(Rental rental);
    }
}