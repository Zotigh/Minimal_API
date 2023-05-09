using FluentValidation;
//using DemoAPI.Models;
using DemoAPI.Models.DTO;

namespace DemoAPI.Validation
{
    // defines what this class is validating by using AbstractValidator and the class.
    public class CouponUpdateValidation : AbstractValidator<CouponUpdateDTO>
    {
        //Validation constructor
        public CouponUpdateValidation()
        {
            //Defines what the rules are for.

            //Defines that the Id cannot be zero and must be greater than 0.
            RuleFor(model => model.Id).NotEmpty().GreaterThan(0);

            //Defines rule will not be empty.
            RuleFor(model => model.Name).NotEmpty();

           //Defines that the percent must be between a certain threshold 1-100.
            RuleFor(model => model.Percent).InclusiveBetween(1, 100);
        }
    }
}
