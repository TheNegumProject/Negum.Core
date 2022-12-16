using System;
using System.Runtime.Serialization;

namespace Negum.Core.Exceptions;

public class NegumException : Exception
{
    public NegumException(string? message)
        : base(message)
    {
    }
    
    public NegumException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected NegumException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
    {
    }
}