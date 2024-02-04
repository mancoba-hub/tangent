using System;
using System.Net;

namespace Liso.Tangent
{
    [Serializable]
    public class TangentException : Exception
    {
        #region Properties

        public HttpStatusCode StatusCode { get; set; }

        public string StatusMessage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TangentException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public TangentException(string statusMessage) : base(statusMessage)
        {
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TangentException"/> class.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusMessage"></param>
        public TangentException(HttpStatusCode statusCode, string statusMessage) : base(statusMessage)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TangentException"/> class.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="inner"></param>
        public TangentException(string statusMessage, Exception inner) : base(statusMessage, inner)
        {
            StatusCode = HttpStatusCode.InternalServerError;
            StatusMessage = statusMessage;
        }

        #endregion
    }
}
