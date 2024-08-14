using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiciosWebCaso.Models
{
    public class Credential
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
