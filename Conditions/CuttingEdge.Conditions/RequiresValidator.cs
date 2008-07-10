﻿/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * Copyright (C) 2008 S. van Deursen
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser 
 * General Public License as published by the Free Software Foundation; either version 2.1 of the License, or
 * (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the 
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
 * License for more details.
*/

using System;
using System.Globalization;

namespace CuttingEdge.Conditions
{
    // The RequiresValidator can be used for postcondition checks.
    internal sealed class RequiresValidator<T> : Validator<T>
    {
        // Initializes a new instance of the <see cref="EnsuresValidator{T}"/> class.
        internal RequiresValidator(string argumentName, T value)
            : base(argumentName, value)
        {
        }

        internal override Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            string message = condition;

            if (!String.IsNullOrEmpty(additionalMessage))
            {
                message = condition + ". " + additionalMessage;
            }

            switch (type)
            {
                case ConstraintViolationType.OutOfRangeViolation:
                    return new ArgumentOutOfRangeException(this.ArgumentName, message);
                case ConstraintViolationType.InvalidEnumViolation:
                    return new System.ComponentModel.InvalidEnumArgumentException(message + 
                        Environment.NewLine + "Parameter name: " + this.ArgumentName);
                default:
                    if (this.Value != null)
                    {
                        return new ArgumentException(message, this.ArgumentName);
                    }
                    else
                    {
                        return new ArgumentNullException(this.ArgumentName, message);
                    }
            }
        }
    }
}
