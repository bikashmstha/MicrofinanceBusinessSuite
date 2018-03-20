using System;
using System.Data;
using System.Configuration;

using System.Runtime.Serialization;

namespace BusinessObjects.MessageBase
{
    /// <summary>
    /// Enumeration of message response acknowledgements. This is a simple
    /// enumerated values indicating success of failure.
    /// </summary>
    public enum AcknowledgeType
    {
        /// <summary>
        /// Respresents an failed response.
        /// </summary>
        Failure = 0,

        /// <summary>
        /// Represents a successful response.
        /// </summary>
        Success = 1
    }
}