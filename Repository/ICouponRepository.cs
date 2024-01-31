using CoupenAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupenAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode (string couponCode);
    }
}
