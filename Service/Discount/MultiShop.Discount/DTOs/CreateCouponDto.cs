namespace MultiShop.Discount.DTOs
{
    public class CreateCouponDto
    {
        
        public string Code { get; set; }
        public string Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
