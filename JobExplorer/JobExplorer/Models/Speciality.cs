using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobExplorer.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Resume> Resumes { get; set; }

        public Speciality()
        {
            Resumes = new List<Resume>();
        }
    }
}