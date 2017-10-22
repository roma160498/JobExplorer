namespace JobExplorer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JobExplorer.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<JobExplorer.Models.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "JobExplorer.Models.ApplicationContext";
        }

        protected override void Seed(JobExplorer.Models.ApplicationContext context)
        {
            
        }
    }
}
