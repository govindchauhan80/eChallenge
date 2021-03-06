﻿using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class LoginRepository
    {
        /// <summary>
        /// Checks for Login Credentials
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string userEmail, string password)
        {
            var entities = new EChallengeEntities();
            return entities.Users.Where(u => !u.IsDeleted && u.EmailId == userEmail && u.Password == password).FirstOrDefault();
        }
    }
}