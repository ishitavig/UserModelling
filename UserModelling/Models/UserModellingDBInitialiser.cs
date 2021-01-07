using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserModelling.Data;

namespace UserModelling.Models
{
    public class UserModellingDBInitialiser : DropCreateDatabaseAlways<UserModellingContext>
    {
        protected override void Seed(UserModellingContext context)
        {
            context.Events.Add(new Events
            {
                EventId = Convert.ToInt32("1"),
                EventName = "UMAP2017",
                EventDescription = "User Modelling, Adaptation and Personalization 2017. Auspices over UMAP 2017 taken by Mayor of Bratislava.",
                EventDateTime = Convert.ToDateTime("04/07/2017 11:30:00"),
                EventVenue = "Bratislava, Slovakia"
            });
            context.Organisers.Add(new Organisers
            {
                OrganiserId = Convert.ToInt32("1"),
                FirstName = "Eelco",
                LastName = "Herder",
                Email = "eelco.herder@umap.com",
                ContactNumber = Convert.ToInt32("12345678"),
                HireDateTime = Convert.ToDateTime("01/03/2016")
            });
            context.EventOrganisers.Add(new EventOrganisers
            {
                EventId = Convert.ToInt32("1"),
                OrganiserId = Convert.ToInt32("1"),
                AssigningDateTime = Convert.ToDateTime("01/09/2016")
            });
            context.Attendees.Add(new Attendees
            {
                AttendeeId = Convert.ToInt32("1"),
                FirstName = "Ishita",
                LastName = "Vig",
                Email = "ishita.vig@live.vu.edu.au",
                ContactNumber = Convert.ToInt32("09876543"),
                SignUpDateTime = Convert.ToDateTime("02/02/2017")
            });
            context.Registerations.Add(new Registerations
            {
                   RegisterationId = Convert.ToInt32("1"),
                   EventId = Convert.ToInt32("1"),
                   AttendeeId = Convert.ToInt32("1"),
                   RegisterationDateTime = Convert.ToDateTime("15/04/2017")
            });
            context.Events.Add(new Events
            {
                EventId = Convert.ToInt32("2"),
                EventName = "UMAP2018",
                EventDescription = "User Modelling, Adaptation and Personalization 2018",
                EventDateTime = Convert.ToDateTime("08/07/2018 11:30:00"),
                EventVenue = "Nanyang Technological University, Singapore"
            });
            context.Organisers.Add(new Organisers
            {
                OrganiserId = Convert.ToInt32("2"),
                FirstName = "Jie",
                LastName = "Zhang",
                Email = "jie.zhang@umap.com",
                ContactNumber = Convert.ToInt32("54321678"),
                HireDateTime = Convert.ToDateTime("01/06/2017")
            });
            context.EventOrganisers.Add(new EventOrganisers
            {
                EventId = Convert.ToInt32("2"),
                OrganiserId = Convert.ToInt32("2"),
                AssigningDateTime = Convert.ToDateTime("01/08/2017")
            });
            context.Attendees.Add(new Attendees
            {
                AttendeeId = Convert.ToInt32("2"),
                FirstName = "Atul",
                LastName = "Mishra",
                Email = "printfmishra@gmail.com",
                ContactNumber = Convert.ToInt32("67890543"),
                SignUpDateTime = Convert.ToDateTime("02/01/2018")
            });
            context.Registerations.Add(new Registerations
            {
                RegisterationId = Convert.ToInt32("2"),
                EventId = Convert.ToInt32("2"),
                AttendeeId = Convert.ToInt32("2"),
                RegisterationDateTime = Convert.ToDateTime("10/03/2018")
            });
            context.Events.Add(new Events
            {
                EventId = Convert.ToInt32("3"),
                EventName = "UMAP2019",
                EventDescription = "The 27th ACM Conference On User Modeling, Adaptation And Personalization, Collocated With SMAP 2019.",
                EventDateTime = Convert.ToDateTime("08/06/2019 10:30:00"),
                EventVenue = "Larnaca, Cyprus"
            });
            context.Organisers.Add(new Organisers
            {
                OrganiserId = Convert.ToInt32("3"),
                FirstName = "Prof. George Angelos",
                LastName = " Papadopoulos",
                Email = "george@cs.ucy.ac.cy",
                ContactNumber = Convert.ToInt32("22892693"),
                HireDateTime = Convert.ToDateTime("01/12/2017")
            });
            context.EventOrganisers.Add(new EventOrganisers
            {
                EventId = Convert.ToInt32("3"),
                OrganiserId = Convert.ToInt32("3"),
                AssigningDateTime = Convert.ToDateTime("20/01/2018")
            });
            context.Attendees.Add(new Attendees
            {
                AttendeeId = Convert.ToInt32("3"),
                FirstName = "Prof. Ali",
                LastName = "Braytee",
                Email = "ali.braytee@vu.edu.au",
                ContactNumber = Convert.ToInt32("56473829"),
                SignUpDateTime = Convert.ToDateTime("01/11/2018")
            });
            context.Registerations.Add(new Registerations
            {
                RegisterationId = Convert.ToInt32("3"),
                EventId = Convert.ToInt32("3"),
                AttendeeId = Convert.ToInt32("3"),
                RegisterationDateTime = Convert.ToDateTime("12/02/2019")
            });

            base.Seed(context);
        }
    }
}