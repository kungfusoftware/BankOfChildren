using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BankOfChildrenAPI.Models
{
    public class ChildModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "middleName")]
        public string middleName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public string gender { get; set; }
        [JsonProperty(PropertyName = "birthDate")]
        public DateTime birthDate { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string address { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string city { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string state { get; set; }
        [JsonProperty(PropertyName = "pinCode")]
        public string pinCode { get; set; }
        
        [JsonProperty(PropertyName = "balance")]
        public decimal balance { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        public List<Tansaction> Transactions { get; set; }


    }
}
