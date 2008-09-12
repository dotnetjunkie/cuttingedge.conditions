﻿#region Copyright (c) 2008 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
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
#endregion

using System;

namespace CuttingEdge.Conditions
{
    // Type checks
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        [MethodToBigToBeInlined]
        public static Validator<T> IsOfType<T>(this Validator<T> validator, Type type)
            where T : class
        {
            // The call to this method is pretty expensive, so it optimizing it for inlining will have no
            // significant effect.
            T value = validator.Value;

            if (value != null)
            {
                bool valueIsValid = type.IsAssignableFrom(value.GetType());

                if (!valueIsValid)
                {
                    Throw.ValueShouldBeOfType(validator, type);
                }
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the <see cref="Type"/> of the given value is not of <paramref name="type"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/>.</typeparam>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="type">The <see cref="Type"/> that will be used to perform the check.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is of the specified <paramref name="type"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        [MethodToBigToBeInlined]
        public static Validator<T> IsNotOfType<T>(this Validator<T> validator, Type type)
            where T : class
        {
            // The call to this method is pretty expensive, so it optimizing it for inlining will have no 
            // significant effect.
            T value = validator.Value;

            if (value != null)
            {
                bool valueIsInvalid = type.IsAssignableFrom(value.GetType());

                if (valueIsInvalid)
                {
                    Throw.ValueShouldNotBeOfType(validator, type);
                }
            }

            return validator;
        }
    }
}