namespace DemoAPI.Models
{
    //Class for attributes
    public class Coupon
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Percent { get; set; }

        public bool IsActive { get; set; }

        //The "?" tells the compiler that this feild is nullable which should satisfy the compiler since it knows.
        public DateTime? Created { get; set; }

        //The "?" tells the compiler that this feild is nullable which should satisfy the compiler since it knows.
        public DateTime? LastUpdated { get; set; }
    }
}
