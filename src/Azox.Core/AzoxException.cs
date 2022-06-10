namespace Azox.Core
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class AzoxException :
        Exception
    {
        #region Ctor

        public AzoxException() : base() { }

        public AzoxException(string message) : base(message) { }

        public AzoxException(string message, Exception innerException) : base(message, innerException) { }

        #endregion Ctor
    }
}
