using System;

namespace BAH.API.EventPlanner.Models
{
    public class TaxField
    {
        #region Public Properties

        public string Label { get; set; }
        public Guid TermGuid { get; set; }
        public int WssId { get; set; }

        #endregion Public Properties
    }
}