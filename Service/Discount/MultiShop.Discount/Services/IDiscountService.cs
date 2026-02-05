using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetResultCouponDtosAsync();
        Task CreateCouponAsync (CreateCouponDto createCouponDto);
        Task UpdateCouponAsync (UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync (int couponId);
        Task <GetbyIdCouponDto> GetByIdCouponAsync (int couponId);
    }
}
