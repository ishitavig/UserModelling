using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserModelling.Models
{
    [Table("Attendees")]
    public class Attendees : Person
    {
        [Key]
        public int AttendeeId { get; set; }

        [Display(Name = "Signed Up On")]
        public DateTime SignUpDateTime { get; set; }
        public virtual ICollection<Registerations> Registerations { get; set; }
    }
}