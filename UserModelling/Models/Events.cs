using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserModelling.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }

        [Required (ErrorMessage = "Please enter name of the event.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [StringLength(255, ErrorMessage = "Description is too long. Maximum characters allowed are 250.")]
        [Display(Name = "Description")]
        public string EventDescription { get; set; }

        [Required (ErrorMessage = "Please enter date and time of the event.")]
        [Display(Name = "Date and Time")]
        public DateTime EventDateTime { get; set; }

        [Required (ErrorMessage = "Please enter venue for the event.")]
        [Display(Name = "Venue")]
        public string EventVenue { get; set; }
        public virtual ICollection<EventOrganisers> EventOrganisers { get; set; }
        public virtual ICollection<Registerations> Registerations { get; set; }
    }
}