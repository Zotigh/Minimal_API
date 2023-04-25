using FluentValidation;
//using DemoAPI.Models;
using DemoAPI.Models.DTO;

namespace DemoAPI.Validation
{
    // defines what this class is validating by using AbstractValidator and the class.
    public class CouponCreateValidation : AbstractValidator<CouponCreateDTO>
    {
        //Validation constructor
        public CouponCreateValidation()
        {
            //Defines what the rules are for.
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Percent).InclusiveBetween(1, 100);
        }
    }
}
