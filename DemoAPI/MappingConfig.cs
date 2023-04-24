using AutoMapper;

namespace DemoAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Coupon, CouponCreateDTO> ()
;        }
    }
}
