using AutoMapper;
using CoupenAPI.Models.Dto;
using CoupenAPI.Repository;
using CouponServiceGrpc;
using Grpc.Core;

namespace CoupenAPI.Services
{
    public class CouponGrpcService:Coupons.CouponsBase
    {
        private readonly ICouponRepository _couponrepository;
        private readonly ILogger<CouponGrpcService> _logger;
        private readonly IMapper _mapper;
        public CouponGrpcService(ICouponRepository couponrepository, ILogger<CouponGrpcService> logger, IMapper mapper)
        {
            _couponrepository = couponrepository;
            _logger = logger;
            _mapper = mapper;
        }
        public override async Task<GetCouponResponse> GetCoupon(GetCouponRequest request, ServerCallContext context)
        {
            var mapRequestToCategory = _mapper.Map<CouponDto>(request);
            var coupon = await _couponrepository.GetCouponByCode(mapRequestToCategory.CouponCode);
            if (coupon is not null)
            {
                var mapCoupon = _mapper.Map<GetCouponResponse>(coupon);
                _logger.LogError("data added");
                return await Task.FromResult(mapCoupon);

            }
            _logger.LogError("An error occurred while processing the request.");
            throw new RpcException(new Status(StatusCode.NotFound, "Coupon not found"));
        }
    }
}
