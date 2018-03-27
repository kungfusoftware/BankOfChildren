namespace BAH.API.BAHEvents.Models
{
    public class EventOptions
    {
        #region Public Properties

        public string AzClientId { get; set; }

        public string AzClientSecret { get; set; }

        public string AzTenant { get; set; }

        //   public int EventId { get; set; }
        public string SpAdminUrl { get; set; }

        public string SpEncPassword { get; set; }
        public string SpEncUsername { get; set; }
        public string SpEventDetailsUrl { get; set; }
        public string SpEventList { get; set; }
        public string SpEventUrl { get; set; }

        #endregion Public Properties
    }
}