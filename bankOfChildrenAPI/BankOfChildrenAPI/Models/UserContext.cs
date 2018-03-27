namespace BAH.API.BAHEvents.Models
{
    public class UserContext
    {
        #region Public Properties

        public bool IsAttendee { get; set; }
        public bool IsAttendeeVirtual { get; set; }
        public bool IsAttendeeWaitlisted { get; set; }
        public bool IsCoordinator { get; set; }
        public bool IsDelegate { get; set; }
        public bool IsEditor { get; set; }
        public bool IsHost { get; set; }

        #endregion Public Properties
    }
}