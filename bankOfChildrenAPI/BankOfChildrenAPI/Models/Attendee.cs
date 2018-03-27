using Newtonsoft.Json;

namespace BAH.API.BAHEvents.Models
{
    public class Attendee : User
    {
        #region Public Properties

        [JsonIgnore]
        public string Presence { get; set; }

        public string ProfileURL { get; set; }
        public string Status { get; set; }
        public bool Virtual { get; set; }

        #endregion Public Properties
    }
}