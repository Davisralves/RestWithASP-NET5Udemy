﻿using Microsoft.IdentityModel.JsonWebTokens;
using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Data.VO.Converter;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LoginBusinessImplemetation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd-HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplemetation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidadeteCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            var acessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var acessToken = token.AcessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(acessToken);

            var username = principal.Identity.Name;

            var user = _repository.ValidadeteCredentials(username);
            if (user == null || user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;
            {
                acessToken = _tokenService.GenerateAcessToken(principal.Claims);
                refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;

                _repository.RefreshUserInfo(user);
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
                return new TokenVO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    acessToken,
                    refreshToken
                    );
            }
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
