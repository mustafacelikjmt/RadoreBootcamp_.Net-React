﻿using Radore.Services.CouponAPI.Models.Dto;

namespace Radore.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
