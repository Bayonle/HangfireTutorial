using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using HangfireTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace HangfireTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] SignupDTO model)
        {
            //map dto to domain entity here and save to database
            //do any other thing that needs to be done.
            Console.WriteLine("before sending email");
            // BackgroundJob.Enqueue(() => SendWelcomeEmail(model.Email));
            BackgroundJob.Schedule(() => SendWelcomeEmail(model.Email), TimeSpan.FromMilliseconds(10));
            // SendWelcomeEmail(model.Email);
            Console.WriteLine("after sending email");
            return Ok();
        }

        [AutomaticRetry(Attempts = 2)]
        public void SendWelcomeEmail(string emailAddress)
        {
            Thread.Sleep(5000);
            // throw new Exception("Unable to connect to email smtp server.");
            Console.WriteLine($"Hi there, thanks for signing up for our service.");
        }




    }
}