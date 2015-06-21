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
    public class UserController : ApiController
    {
        readonly UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        /// <summary>
        /// Gets All the Users 
        /// </summary>
        /// <returns></returns>
        public ICollection<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        /// <summary>
        /// Gets User Details by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserByUserId(int userId)
        {
            return userRepository.GetUserByUserId(userId);
        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="model"></param>
        public int CreateUser(User model)
        {
            userRepository.CreateUser(model);
            return 1;
        }

        /// <summary>
        /// Updates a User
        /// </summary>
        /// <param name="model"></param>
        public int UpdateUser(User model)
        {
            userRepository.UpdateUser(model);
            return 1;
        }

        /// <summary>
        /// Marks a User as deleted
        /// </summary>
        /// <param name="UserId"></param>
        public int DeleteUser(int UserId)
        {
            userRepository.DeleteUser(UserId);
            return 1;
        }
    }
}