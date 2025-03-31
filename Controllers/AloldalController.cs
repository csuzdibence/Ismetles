using Ismetles.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ismetles.Controllers
{
    public class AloldalController : Controller
    {
        private ValamilyenDbContext dbContext;

        public AloldalController(ValamilyenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("Aloldal/EmailSubmit")]
        public IActionResult EmailSubmit(string email, string username, DateTime date)
        {

            if (email is not null && username is not null)
            {
                return Ok(new UserFormModel() 
                {
                    Email = email,
                    Username = username
                });
            }
            return BadRequest();
        }

        [HttpPost("Aloldal/EmailSubmit2")]
        public IActionResult EmailSubmit2([FromBody] UserFormModel user)
        {

            if (user is not null)
            {
                return Created("EmailSubmit2", user);
            }
            return BadRequest();
        }

        [HttpGet("Aloldal/EmailSubmit3/{email}/{username}")]
        public IActionResult EmailSubmit3(string email, string username)
        {
            if (email is not null && username is not null)
            {
                return Ok(new UserFormModel()
                {
                    Email = email,
                    Username = username
                });
            }
            return BadRequest();
        }

        public IActionResult Demo()
        {
            // keresni - első elem
            dbContext.UserFormModels.FirstOrDefault();
            // első elem, valamilyen feltétellel
            dbContext.UserFormModels.FirstOrDefault(x => x.Username.Contains("asd"));
            // összes elem, amelyikre igaz a feltétel
            dbContext.UserFormModels.Where(x => x.Username == "asd");

            List<UserFormModel> userFormModels = new List<UserFormModel>()
            {
                new UserFormModel()
                {
                    Username = "a",
                    Email = "a@gmail.com"
                },

                new UserFormModel()
                {
                    Username = "b",
                    Email = "asd@gmail.com"
                },
                new UserFormModel()
                {
                    Username = "s",
                    Email = "dss@gmail.com"
                },
            };
            var descendingByEmail = userFormModels.OrderByDescending(x => x.Email);

            // FoD
            // Where
            // Select
            // OrderBy

            // elem létrehozás
            dbContext.UserFormModels.Where(x => x.Username == "asd").Select(x => new UserFormModel()
            {
                Username = x.Username,
                Email = x.Email
            });

            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
