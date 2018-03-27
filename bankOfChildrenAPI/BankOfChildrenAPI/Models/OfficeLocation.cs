using System;
using System.ComponentModel.DataAnnotations;

namespace BAH.API.BAHEvents.Models
{
    [Obsolete("Only used in Zone V1")]
    public class OfficeLocation
    {
        #region Public Properties

        public bool BAHLocation { get; set; }
        public string FullAddress { get; set; }

        [Key]
        public string Name { get; set; }

        #endregion Public Properties
    }
}