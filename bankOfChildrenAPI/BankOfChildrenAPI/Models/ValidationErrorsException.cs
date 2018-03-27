using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace BAH.API.BAHEvents.Models
{
    [Serializable]
    // Important: This attribute is NOT inherited from Exception, and MUST be specified
    // otherwise serialization will fail with a SerializationException stating that
    // "Type X in Assembly Y is not marked as serializable."
    public class ValidationErrorsException : Exception
    {
        #region Private Fields

        private readonly IList<ValidationResult> validationResults;

        #endregion Private Fields

        #region Public Constructors

        public ValidationErrorsException()
        {
        }

        public ValidationErrorsException(string message)
            : base(message)
        {
        }

        public ValidationErrorsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ValidationErrorsException(string message, IList<ValidationResult> validationResults)
            : base(message)
        {
            this.validationResults = validationResults;
        }

        public ValidationErrorsException(string message, IList<ValidationResult> validationResults, Exception innerException)
            : base(message, innerException)
        {
            this.validationResults = validationResults;
        }

        #endregion Public Constructors

        #region Protected Constructors

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        // Constructor should be protected for unsealed classes, private for sealed classes.
        // (The Serializer invokes this constructor through reflection, so it can be private)
        protected ValidationErrorsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.validationResults = (IList<ValidationResult>)info.GetValue("ValidationErrors", typeof(IList<string>));
        }

        #endregion Protected Constructors

        #region Public Properties

        public IList<ValidationResult> ValidationResults
        {
            get { return this.validationResults; }
        }

        #endregion Public Properties

        #region Public Methods

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            // Note: if "List<T>" isn't serializable you may need to work out another
            //       method of adding your list, this is just for show...
            info.AddValue("ValidationResults", this.ValidationResults, typeof(IList<ValidationResult>));

            // MUST call through to the base class to let it save its own state
            base.GetObjectData(info, context);
        }

        #endregion Public Methods
    }
}