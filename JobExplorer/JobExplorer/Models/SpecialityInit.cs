using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JobExplorer.Models
{ 
    public class SpecialityInit: DropCreateDatabaseAlways<ApplicationContext>
    {
        public SpecialityInit(ApplicationContext db)
        {
            Seed(db);
        }
        protected override void Seed(ApplicationContext db)
        {
            db.Specialities.Add(new Speciality { Name = "Война и мир"});
            db.Specialities.Add(new Speciality { Name = "Отцы и дети" });
            db.Specialities.Add(new Speciality { Name = "Чайка" });
        }
    }
}