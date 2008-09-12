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

namespace CuttingEdge.Conditions
{
    // Comparable checks for byte
    public static partial class ValidatorExtensions
    {
        /// <summary>
        /// Checks whether the given value is between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsInRange(this Validator<byte> validator, byte minValue, byte maxValue)
        {
            byte value = validator.Value;

            if (!(value >= minValue && value <= maxValue))
            {
                Throw.ValueShouldBeBetween(validator, minValue, maxValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not between <paramref name="minValue"/> and 
        /// <paramref name="maxValue"/> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is in the specified range, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsNotInRange(this Validator<byte> validator, byte minValue, byte maxValue)
        {
            byte value = validator.Value;

            if (value >= minValue && value <= maxValue)
            {
                Throw.ValueShouldNotBeBetween(validator, minValue, maxValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater than the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsGreaterThan(this Validator<byte> validator, byte minValue)
        {
            if (!(validator.Value > minValue))
            {
                Throw.ValueShouldBeGreaterThan(validator, minValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater than the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsNotGreaterThan(this Validator<byte> validator, byte maxValue)
        {
            if (validator.Value > maxValue)
            {
                Throw.ValueShouldNotBeGreaterThan(validator, maxValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is greater or equal to the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsGreaterOrEqual(this Validator<byte> validator, byte minValue)
        {
            if (!(validator.Value >= minValue))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo(validator, minValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not greater or equal to the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsNotGreaterOrEqual(this Validator<byte> validator, byte maxValue)
        {
            if (validator.Value >= maxValue)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo(validator, maxValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is less than the specified <paramref name="maxValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater or equal to <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsLessThan(this Validator<byte> validator, byte maxValue)
        {
            if (!(validator.Value < maxValue))
            {
                Throw.ValueShouldBeSmallerThan(validator, maxValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not less than the specified <paramref name="minValue"/>.
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller than <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsNotLessThan(this Validator<byte> validator, byte minValue)
        {
            if (validator.Value < minValue)
            {
                Throw.ValueShouldNotBeSmallerThan(validator, minValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is smaller or equal to the specified <paramref name="maxValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is greater than <paramref name="maxValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsLessOrEqual(this Validator<byte> validator, byte maxValue)
        {
            if (!(validator.Value <= maxValue))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo(validator, maxValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is not smaller or equal to the specified <paramref name="minValue"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is smaller or equal to <paramref name="minValue"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsNotLessOrEqual(this Validator<byte> validator, byte minValue)
        {
            if (validator.Value <= minValue)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo(validator, minValue);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is equal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is not equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>
        public static Validator<byte> IsEqualTo(this Validator<byte> validator, byte value)
        {
            if (!(validator.Value == value))
            {
                Throw.ValueShouldBeEqualTo(validator, value);
            }

            return validator;
        }

        /// <summary>
        /// Checks whether the given value is unequal to the specified <paramref name="value"/>. 
        /// An exception is thrown otherwise.
        /// </summary>
        /// <remarks>This method will get inlined by the JIT compiler and calling it is therefore very cheap.</remarks>
        /// <param name="validator">The <see cref="Validator{T}"/> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Requires{T}(T,string)">Requires</see> extension method.</exception>
        /// <exception cref="PostconditionException">Thrown when the <see cref="Validator{T}.Value">Value</see> of the specified <paramref name="validator"/> is equal to <paramref name="value"/>, while the specified <paramref name="validator"/> is created using the <see cref="Ensures{T}(T,string)">Ensures</see> extension method.</exception>   
        public static Validator<byte> IsNotEqualTo(this Validator<byte> validator, byte value)
        {
            if (validator.Value == value)
            {
                Throw.ValueShouldBeUnequalTo(validator, value);
            }

            return validator;
        }
    }
}