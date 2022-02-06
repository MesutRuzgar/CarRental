using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelName).MinimumLength(2).WithMessage(Messages.CarModelNameMinLengt);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarDailyPriceError);
        }
    }
}
