﻿using System;

namespace FrameLog.Exceptions
{
    public class UnableToCloneObjectException : Exception
    {
        public readonly Type Type;

        private const string message =
            "Attempted to clone an object of type '{0}', the object does not support any of the permitted cloning strategies.";
        private const string messageWithType =
            "An error of type '{1}' occured during the attempted cloning of '{0}'. See inner exception for more details.";

        public UnableToCloneObjectException(Type type)
            : base(string.Format(message, type))
        {
        }
        public UnableToCloneObjectException(Type type, Exception innerException)
            : base(string.Format(messageWithType, type, innerException.GetType()), innerException)
        {
            Type = type;
        }
    }
}
