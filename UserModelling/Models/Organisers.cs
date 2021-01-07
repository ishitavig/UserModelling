using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserModelling.Models
{
    [Table("Organisers")]
    public class Organisers : Person
    {
        [Key]
        public int OrganiserId { get; set; }

        [Required(ErrorMessage = "Please enter date and time of hiring the organiser in the format dd/mm/yyyy hh:mm")]
        [Display(Name = "Hired On")]
        public DateTime HireDateTime { get; set; }
        public virtual ICollection<EventOrganisers> EventOrganisers { get; set; }
    }
}