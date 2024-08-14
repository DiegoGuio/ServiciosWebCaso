using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogiServiciosWebCaso.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using ServiciosWebCaso.Context;
using ServiciosWebCaso.Models;

namespace ServiciosWebCaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiWebContext _context;

        private readonly UsersBL _usersBL;

        public UsersController(ApiWebContext context, UsersBL usersBL)
        {
            _context = context;
            _usersBL = usersBL;
        }
                
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            user.Password = _usersBL.PasswordEncryption(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(Credential credentials)
        {
            var passwordSaved = _context.Users.Where(u => u.UserName == credentials.UserName).Select(u => u.Password).FirstOrDefault();

            if (passwordSaved != null) 
            {
                var IsPassword = _usersBL.VerifyPassword(credentials.Password, passwordSaved);
                if (IsPassword)
                {
                    return "Autenticación satisfactoria";
                }
                else
                {
                    return "Error en la autenticación";
                }
            } else {

                return "Error en la autenticación";
            }
            
        }

        
    }
}
