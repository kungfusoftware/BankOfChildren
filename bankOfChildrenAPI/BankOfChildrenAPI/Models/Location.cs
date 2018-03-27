﻿using System.ComponentModel.DataAnnotations;

namespace BAH.API.BAHEvents.Models
{
    public class Location
    {
        #region Public Properties

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string FullAddress { get; set; }

        [Key]
        public int LocationId { get; set; }

        public string Name { get; set; }
        public string Promixity { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        #endregion Public Properties
    }
}