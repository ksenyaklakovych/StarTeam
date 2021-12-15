using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarForum.Application.Models;
using StarForum.Application.Services;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarForum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
		private readonly IUserLoginRepository _userLoginRepository;
		private readonly IUserRepository _userRepository;
		private readonly JwtHandler _jwtHandler;

		public AuthController(JwtHandler jwtHandler,
			IUserLoginRepository userLoginRepository,
			IUserRepository userRepository)
		{
			_jwtHandler = jwtHandler;
			_userLoginRepository = userLoginRepository;
			_userRepository = userRepository;
		}

		[HttpPost("ExternalLogin")]
		public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthModel externalAuth)
		{
			var payload = await _jwtHandler.VerifyGoogleToken(externalAuth);
			if (payload == null)
				return BadRequest("Invalid External Authentication.");

			var user = await _userLoginRepository.FindByLoginAsync("GOOGLE", payload.Subject);
			if (user == null)
			{
				user = new User
				{
					Email = payload.Email,
					Name = payload.Name,
					IsBlocked = false
				};
				var newUser = await _userRepository.AddAsync(user);

				//prepare and send an email for the email confirmation
				var userLogin = new UserLogin
				{
					UserId = newUser.Id,
					ProviderKey = payload.Subject,
					ProviderName = "GOOGLE",
					LoginProvider = "GOOGLE"
				};

                await _userLoginRepository.AddAsync(userLogin);
            }

			if (user == null)
				return BadRequest("Invalid External Authentication.");

			//check for the Locked out account

			var token = _jwtHandler.GenerateToken(user);
			return Ok(new AuthResponseModel { Token = token, IsAuthSuccessful = true });
		}
	}
}
