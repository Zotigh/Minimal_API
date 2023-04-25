using FluentValidation;
//using DemoAPI.Models;
using DemoAPI.Models.DTO;

namespace DemoAPI.Validation
{
    // defines what this class is validating by using AbstractValidator and the class.
    public class CouponCreateValidation : AbstractValidator<CouponCreateDTO>
    {

    }
}
