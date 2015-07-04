using EChallenge.Models;
using EChallenge.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EChallenge.ControllerAPIs
{
    public class LoginController : ApiController
    {
        LoginRepository loginRepository;
        public LoginController()
        {
            loginRepository = new LoginRepository();
        }
        /// <summary>
        /// Checks for Login Credentials
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string userEmail, string password)
        {
            return loginRepository.Login(userEmail, password);
        }
    }
}
