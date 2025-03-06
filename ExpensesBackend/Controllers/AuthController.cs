using ExpensesBackend.DatabaseContext;
using ExpensesBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpensesBackend.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            if(string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { error = "Enter username and Password" });

            }
            try
            {
                using(var context=new AppDbContext())
                {
                    var exists = context.Users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
                    if (exists)
                    {
                        return Ok(CreateToken(user));
                    }
                    else
                    {
                        return BadRequest(new { error = "\"Invalid username or password\"" });
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                using(var context=new AppDbContext())
                {
                    var exists= context.Users.FirstOrDefault(u => u.UserName == user.UserName);
                    if (exists != null)
                    {
                        return BadRequest(new { error = "\"User already exists\"" });
                    }
                    else
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        return Ok(CreateToken(user));
                    }
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        private JwtPackage CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, user.UserName)
            });
            const string secretKey = "my_super_secret_key_1234567890_1234567890";
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = (JwtSecurityToken)tokenHandler.CreateJwtSecurityToken(
                subject: claims,
                //expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
            );

            var tokenString = tokenHandler.WriteToken(token);
            return new JwtPackage()
            {
                Username= user.UserName,
                Token = tokenString
            };
        }
        
    }
}

public class JwtPackage
{
    public string Token { get; set; }
    public string Username { get; set; }
}
