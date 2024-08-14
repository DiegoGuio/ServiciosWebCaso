using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogiServiciosWebCaso.BL
{
    public class UsersBL
    {
        public UsersBL() { }

        public string PasswordEncryption(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string passwordEntered, string passwordSaved)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(passwordEntered, passwordSaved);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
