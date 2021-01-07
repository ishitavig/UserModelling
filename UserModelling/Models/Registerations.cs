using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModelling.Models
{
    public class Registerations
    {
        [Key]
        public int RegisterationId { get; set; }

        [Display(Name = "Event")]
        [ForeignKey("Events")]
        [Column(Order = 1)]
        public int EventId { get; set; }

        [Display(Name = "Attendee")]
        [ForeignKey("Attendees")]
        [Column(Order = 2)]
        public int AttendeeId { get; set; }

        [Display(Name = "Registered On")]
        public DateTime RegisterationDateTime { get; set; }
        public virtual Events Events { get; set; }
        public virtual Attendees Attendees { get; set; }
    }
}