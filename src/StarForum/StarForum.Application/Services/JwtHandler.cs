using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StarForum.Application.Models;
using StarForum.Domain.AggregatesModel.UserAggregate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StarForum.Application.Services
{
    public class JwtHandler
    {
		private readonly IConfiguration _configuration;
		private readonly IConfigurationSection _jwtSettings;
		private readonly IConfigurationSection _googleSettings;
		public JwtHandler(IConfiguration configuration)
		{
			_configuration = configuration;
			_jwtSettings = _configuration.GetSection("JwtSettings");
			_googleSettings = _configuration.GetSection("GoogleAuthSettings");
		}

		private SigningCredentials GetSigningCredentials()
		{
			var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
			var secret = new SymmetricSecurityKey(key);

			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		private List<Claim> GetClaims(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Email)
			};

			return claims;
		}

		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				issuer: _jwtSettings.GetSection("validIssuer").Value,
				audience: _jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
				signingCredentials: signingCredentials);

			return tokenOptions;
		}

		public string GenerateToken(User user)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = GetClaims(user);
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return token;
		}

		public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthModel externalAuth)
		{
			try
			{
				var settings = new GoogleJsonWebSignature.ValidationSettings()
				{
					Audience = new List<string>() { _googleSettings.GetSection("clientId").Value }
				};

				var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
				return payload;
			}
			catch (Exception ex)
			{
				//log an exception
				return null;
			}
		}
	}
}
