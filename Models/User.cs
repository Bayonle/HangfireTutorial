using System;
using System.Collections.Generic;

namespace HangfireTutorial.Models
{
    public class User
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }

        public List<User> GetUsersWithBirthdaysAsToday()
        {
            var users = new List<User>
            {
                new User
                {
                    Name = "Jon Snow",
                    EmailAddress = "jonsnow@westeros.org",
                    BirthDate = new DateTime(1991, 12, 22)
                },
                new User
                {
                    Name = "Cersei Lannister",
                    EmailAddress = "cerseilannister@queendom.org",
                    BirthDate = new DateTime(1991, 12, 22)
                }
            };

            return users;
        }
    }
}