using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CoupenAPI.Models.Dto
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
