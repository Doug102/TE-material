using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using PetInfoServer.Security;
using System;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDAO userDao;

        public LoginController(ITokenGenerator _tokenGenerator, IPasswordHasher _passwordHasher, IUserDAO _userDao)
        {
            tokenGenerator = _tokenGenerator;
            passwordHasher = _passwordHasher;
            userDao = _userDao;
        }

        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = BadRequest(new { message = "Username or password is incorrect" });

            // Get the user by username
            User user = userDao.GetUser(userParam.Username);

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                user.Role = "user";

                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.Id, user.Username, user.Role);

                // Create a ReturnUser object to return to the client
                ReturnUser retUser = new ReturnUser() { Id = user.Id, Username = user.Username, Role = user.Role, Token = token };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }

        [HttpPost("register")]
        public IActionResult Register(LoginUser userParam)
        {
            // Get the user by username
            User user = userDao.GetUser(userParam.Username);

            //if we cound the user, reject bacause user alreayd exists 

            if (user != null)
            {
                return BadRequest(new { message = "User already exists" });
            }

            // If we found a user and the password hash matches
            User newUser = userDao.AddUser(userParam.Username, userParam.Password);

            if (newUser != null)
            {
                return Ok();

            }
            else
            {
                return BadRequest(new { message = "Unable to add user" });
            }



        }
    }
}
