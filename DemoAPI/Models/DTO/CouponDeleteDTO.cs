namespace DemoAPI.Models.DTO
{
    public class CouponDeleteDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Percent { get; set; }
        public bool IsActive { get; set;}
    }
}
