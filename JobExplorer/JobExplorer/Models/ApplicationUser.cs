using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobExplorer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string WorkPlace { get; set; }
        public string WebSite { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public ApplicationUser()
        {
        }
    }
}