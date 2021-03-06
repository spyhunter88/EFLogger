﻿using System;

namespace FrameLog.Exceptions
{
    public class UnableToInstantiateObjectException : Exception
    {
        public readonly Type Type;

        private const string message =
            "Attempted to instantiate an object of type '{0}', but failed because the object does not have a public or private paramterless constructor.";

        public UnableToInstantiateObjectException(Type type, Exception innerException = null)
            : base(string.Format(message, type), innerException)
        {
            Type = type;
        }
    }
}
