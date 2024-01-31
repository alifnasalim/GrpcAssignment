using CoupenAPI.Models.Dto;
using CoupenAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupenAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponController : Controller
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;
        public CouponController(ICouponRepository couponRepository)
        {
            this._couponRepository = couponRepository;
            this._response = new ResponseDto();
        }

        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
             

                if(coupon==null )
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Coupon code is invalid" };
                }
                else
                {
                    _response.IsSuccess = true;
                }
                _response.Result = coupon;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
