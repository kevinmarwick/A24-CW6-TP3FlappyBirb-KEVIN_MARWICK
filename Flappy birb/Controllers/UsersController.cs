using Flappy_Birb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flappy_Birb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserManager<User> UserManager;
        public UsersController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            // Validate if passwords match
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe spécifiés sont différents." });
            }

            // Prepare the user object
            User user = new User()
            {
                UserName = register.Username,
                Email = register.Email
            };

            // Attempt to create the user
            IdentityResult identityResult = await this.UserManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                // Log detailed error messages and return them in the response
                var errors = identityResult.Errors.Select(e => e.Description).ToList();
                return StatusCode(StatusCodes.Status400BadRequest,
                    new
                    {
                        Message = "La création de l'utilisateur a échoué.",
                        Errors = errors
                    });
            }

            return Ok(new { Message = "Utilisateur créé avec succès." });
        }

    }
}
