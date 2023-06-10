using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Hms.Models
{
    public class Appointment
    {
        [Display(Name = "Id")]
        public int Pid { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Pname { get; set; }

        [Required(ErrorMessage = "Date required")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Dname { get; set; }

    }
}