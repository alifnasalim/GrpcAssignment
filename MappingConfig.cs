using AutoMapper;
using CoupenAPI.Models;
using CoupenAPI.Models.Dto;
using CouponServiceGrpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoupenAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
                config.CreateMap<GetCouponRequest, CouponDto>().ReverseMap();
                config.CreateMap<CouponDto, GetCouponResponse>().ReverseMap();
                //config.CreateMap<CartDto, CartDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
