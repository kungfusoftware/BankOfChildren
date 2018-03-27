using System.ComponentModel.DataAnnotations;

namespace BAH.API.BAHEvents.Models
{
    public class Type
    {
        #region Public Properties

        [Key]
        public string Id { get; set; }

        #endregion Public Properties
    }
}