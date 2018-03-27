using BAH.API.BAHEvents.Globals;

namespace BAH.API.BAHEvents.Models
{
    public class Coordinator : User
    {
        #region Public Constructors

        public Coordinator(User usr)
        {
            usr.CopyProperties<User>((User)this);
        }

        public Coordinator()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Host { get; set; }

        #endregion Public Properties
    }
}