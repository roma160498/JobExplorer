using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace JobExplorer.Models
{
    public class Resume
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }

        public string BirthDate { get; set; }
        public string sex { get; set; }
        public string City { get; set; }
        public string Relocation { get; set; }
        public string BusinessTrip { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
        public string Email { get; set; }

        public string EducationLevel { get; set; }
        public string Institution { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        // public DateTime EndStudy { get; set; }
        // public DateTime StartStudy { get; set; }
        // public DateTime StartLastJob { get; set; }
        // public DateTime EndLastJob { get; set; }

        //public int? SpecialityLastJobId { get; set; }

        public string AdditionalInformation { get; set; }
        
        public string CreatorLogin { get; set; }

        public int? SpecialityId { get; set; } 
        public Speciality Speciality { get; set; }
        //public Speciality SpecialityLastJob { get; set; }
        /*

        private string BirthdateDay;
        private string BirthdateMonth;
        private string BirthdateYear;
        public IEnumerable<SelectListItem> BirthdateDaySelectList
        {
            get
            {
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthdateDay == i.ToString()
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthdateMonthSelectList
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(2000, i, 1).ToString("MMMM"),
                        Selected = BirthdateMonth == i.ToString()
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthdateYearSelectList
        {
            get
            {
                for (int i = 1910; i < DateTime.Now.Year; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthdateYear == i.ToString()
                    };
                }
            }
        }*/
    }
}