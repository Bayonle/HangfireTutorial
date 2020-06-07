using System;
using System.Threading;
using Hangfire;
using HangfireTutorial.Models;

namespace HangfireTutorial.RecurringJobs
{
    public static class BirthdayJob
    {
        [AutomaticRetry(Attempts = 2)]
        public static void SendBirthdayEmail()
        {
            Thread.Sleep(5000);
            // throw new Exception("Unable to connect to email smtp server.");
            var user = new User();

            var birthdays = user.GetUsersWithBirthdaysAsToday();
            foreach (var userBirthday in birthdays)
            {
                string message = $"Dear {userBirthday.Name}, We wish you a very happy birthday celebration.";
                SendBirthdayGreeting(userBirthday.EmailAddress, message);
            }
        }

        public static void SendBirthdayGreeting(string emailAddress, string message)
        {
            Thread.Sleep(5000);
            Console.WriteLine(message);
        }
    }
}