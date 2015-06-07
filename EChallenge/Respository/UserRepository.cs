using EChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Respository
{
    public class UserRepository
    {
        /// <summary>
        /// Gets All the Users 
        /// </summary>
        /// <returns></returns>
        public ICollection<User> GetAllUsers()
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.Users.Where(c => !c.IsDeleted).ToList();
            }
        }

        /// <summary>
        /// Gets User Details by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserByUserId(int userId)
        {
            using (var entities = new EChallengeEntities())
            {
                return entities.Users.Where(c => !c.IsDeleted && c.UserId == userId).FirstOrDefault();
            }
        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="model"></param>
        public void CreateUser(User model)
        {
            using (var entities = new EChallengeEntities())
            {
                entities.Users.Add(model);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a User
        /// </summary>
        /// <param name="model"></param>
        public void UpdateUser(User model)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUser = entities.Users.Where(c => !c.IsDeleted && c.UserId == model.UserId).FirstOrDefault();

                if (existingUser == null)
                    throw new NullReferenceException("User not found");

                existingUser.FirstName = model.FirstName;
                existingUser.MiddleName = model.MiddleName;
                existingUser.LastName = model.LastName;
                existingUser.Address = model.Address;
                existingUser.City = model.City;
                existingUser.ContactNumber = model.ContactNumber;
                existingUser.Country = model.Country;
                existingUser.DisplayName = model.DisplayName;
                existingUser.EmailId = model.EmailId;
                existingUser.Pincode = model.Pincode;
                existingUser.ProfilePicUrl = model.ProfilePicUrl;
                existingUser.Provider = model.Provider;
                existingUser.UpdatesDate = DateTime.UtcNow;

                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Marks a User as deleted
        /// </summary>
        /// <param name="UserId"></param>
        public void DeleteUser(int UserId)
        {
            using (var entities = new EChallengeEntities())
            {
                var existingUser = entities.Users.Where(c => !c.IsDeleted && c.UserId == UserId).FirstOrDefault();

                if (existingUser == null)
                    throw new NullReferenceException("User not found");

                existingUser.IsDeleted = true;
                entities.SaveChanges();
            }
        }
    }
}