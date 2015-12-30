﻿using System;
using System.Linq.Expressions;

namespace FrameLog.Exceptions
{
    public class InvalidPropertyExpressionException : Exception
    {
        public readonly Expression Lambda;

        private const string message =
            "The expression '{0}' was not a property accessor expression. " +
            "It must be in the form x => x.a, x => x.a.b, etc., where 'a' and 'b' properties, not fields or methods.";

        public InvalidPropertyExpressionException(Expression lambda)
            : base(string.Format(message, lambda))
        {
            this.Lambda = lambda;
        }
    }
}
