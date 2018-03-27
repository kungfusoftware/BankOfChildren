namespace BAH.API.BAHEvents.Models
{
    using System;

    public class User
    {
        #region Public Properties

        public string Email { get; set; }

        public string EmployeeId { get; set; }

        [Obsolete("Used in Zone V1 with SPList")]
        public int LookupId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        #endregion Public Properties
    }
}