
using BAH.API.BAHEvents.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAH.API.BAHEvents.Globals
{
    public static class Extensions
    {
       

        #region Public Methods

        /// <summary>
        ///   properties copy with the same class without creating new instance object.
        /// </summary>
        public static void CopyProperties<T>(this T source, T destination)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                property.SetValue(destination, property.GetValue(source, null), null);
            }
        }

    
        #endregion Public Methods

    
    }
}