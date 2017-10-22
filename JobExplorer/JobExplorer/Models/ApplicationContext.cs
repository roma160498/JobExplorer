using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobExplorer.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        public ApplicationContext() : base("IdentityDb")
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}