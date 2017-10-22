using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobExplorer.Models
{
    public class RegisterEmployerModel
    {
        [Required]
        public string WorkPlace { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}