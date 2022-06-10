namespace Azox.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class AzoxBugException:
        AzoxException
    {
        #region Ctor

        public AzoxBugException() : base("[BUG]") { }

        public AzoxBugException(string message) : base($"[BUG] {message}") { }

        #endregion Ctor
    }
}
