using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DNP_Handin1.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = "ADMIN"
                },
                new User
                {
                    UserName = "IonutGrosu",
                    Password = "pass123",
                    Role = "CLERK"
                }
            }.ToList();
        }
        
        public User ValidateUser(string UserName, string Password)
        {
            User temp = users.FirstOrDefault(user => user.UserName.Equals(UserName));
            if (temp == null)
            {
                throw new Exception("User not found");
            }

            if (!temp.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }

            return temp;
        }
    }
}