using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserModelling.Models
{
    public class EventOrganisers
    {
        [Key]
        public int EventOrganiserId { get; set; }

        [Required (ErrorMessage = "Please select an event")]
        [Display(Name = "Event")]
        [ForeignKey("Events")]
        [Column(Order = 1)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please select an organiser")]
        [Display(Name = "Organiser")]
        [ForeignKey("Organisers")]
        [Column(Order = 2)]
        public int OrganiserId { get; set; }

        [Display(Name = "Assigned On")]
        public DateTime AssigningDateTime { get; set; }
        public virtual Events Events { get; set; }
        public virtual Organisers Organisers { get; set; }
    }
}