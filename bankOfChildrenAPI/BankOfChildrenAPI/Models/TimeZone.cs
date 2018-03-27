using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BAH.API.BAHEvents.Models
{
    public class TimeZone
    {
        #region Public Properties

        public string Abbr { get; set; }

        public string GMT { get; set; }

        [Key]
        public string Id { get; set; }

        public bool IsDefault { get; set; }
        public bool IsDST { get; set; }
        public string Location { get; set; }

        public string Offset { get; set; }
        public string Text { get; set; }

        public List<string> UTC { get; set; }

        #endregion Public Properties
    }
}