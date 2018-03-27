
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace BAH.API.BAHEvents.Models
{
    public class Event

    {
        #region Public Constructors

        public Event()
        {
            TimeZone = new TimeZone();
            Coordinators = new List<Coordinator>();
            Attendees = new List<Attendee>();
        }

        #endregion Public Constructors

        #region Public Properties
        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "AttendeeInstructions")]
        public string AttendeeInstructions { get; set; }
        public List<Attendee> Attendees { get; set; }

        [Obsolete("This property is renamed from Attendees and is going to retired in Zone V2")]
        public string AttendeeString { get; set; }

        public string BAHLocationName { get; set; }   //to be discussed

        [Required]
        public int Capacity { get; set; }

        [Required]
        public List<Coordinator> Coordinators { get; set; }

        public string Cost { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Obsolete("will be removed if there are no Zone V1 or LinkUp dependencies")]
        public int EventId { get; set; }

        public string ImageURL { get; set; }
        public bool IsRegistrationEnded { get; set; }
        public string Keywords { get; set; }
        public string LocationInformation { get; set; }
        public DateTime? Modified { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Organization { get; set; }

        [Required]
        [PresenceInRange(ErrorMessage = "Presence must in one of the value: In-Person, Virtual, Hybrid")]
        public string Presence { get; set; }

        [Required]
        public bool Private { get; set; }

        public DateTime? RegistrationEndDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
       
        public TimeZone TimeZone { get; set; }

        [Required]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public UserContext UserContext { get; set; }
        public string VirtualURL { get; set; }

        #endregion Public Properties
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class PresenceInRangeAttribute : ValidationAttribute
    {
        #region Public Methods

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            else
            {
                switch (value.ToString().ToLower())
                {
                    case "in-person":
                    case "virtual":
                    case "hybrid":
                        return true;

                    default:
                        return false;
                }
            }
        }

        #endregion Public Methods
    }
}