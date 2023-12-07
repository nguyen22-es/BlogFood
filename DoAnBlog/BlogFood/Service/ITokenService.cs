﻿using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;
using MyWebApiApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogFoodApi.Service
{
    public interface ITokenService
    {
        string GenerateRefreshToken();

        Task<RefreshModel> GenerateJwt(ManageUser user);


       Task<ApiResponse> CheckTokenAsync(RefreshModel refreshModel, ManageUser user);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);


    }
}
