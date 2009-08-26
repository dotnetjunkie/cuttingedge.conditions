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

// NOTE: Some methods and properties are decorated with the EditorBrowsableAttribute to prevent those methods
// and properties from showing up in IntelliSense. These members will not be used by users that try to 
// validate arguments and are therefore misleading.
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CuttingEdge.Conditions
{
    /// <summary>
    /// Enables validation of pre- and postconditions. This class isn't used directly by developers. Instead 
    /// the class should be created by the <see cref="Condition.Requires{T}(T)">Requires</see> and
    /// <see cref="Condition.Ensures{T}(T)">Ensures</see> extension methods.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    /// <example>
    /// The following example shows how to use <b>CuttingEdge.Conditions</b>.
    /// <code><![CDATA[
    /// using System.Collections;
    /// 
    /// using CuttingEdge.Conditions;
    /// 
    /// public class ExampleClass
    /// {
    ///     private enum StateType { Uninitialized = 0, Initialized };
    ///     
    ///     private StateType currentState;
    /// 
    ///     public ICollection GetData(int? id, string xml, IEnumerable col)
    ///     {
    ///         // Check all preconditions:
    ///         Condition.Requires(id, "id")
    ///             .IsNotNull()          // throws ArgumentNullException on failure
    ///             .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
    ///             .IsNotEqualTo(128);   // throws ArgumentException on failure
    /// 
    ///         Condition.Requires(xml, "xml")
    ///             .StartsWith("<data>") // throws ArgumentException on failure
    ///             .EndsWith("</data>"); // throws ArgumentException on failure
    /// 
    ///         Condition.Requires(col, "col")
    ///             .IsNotNull()          // throws ArgumentNullException on failure
    ///             .IsEmpty();           // throws ArgumentException on failure
    /// 
    ///         // Do some work
    /// 
    ///         // Example: Call a method that should return a not null ICollection
    ///         object result = BuildResults(xml, col);
    /// 
    ///         // Check all postconditions:
    ///         // A PostconditionException will be thrown at failure.
    ///         Condition.Ensures(result, "result")
    ///             .IsNotNull()
    ///             .IsOfType(typeof(ICollection));
    /// 
    ///         return result as ICollection;
    ///     }
    /// }
    /// ]]></code>
    /// The following code examples shows how to extend the library with your own 'Invariant' entry point
    /// method. The first example shows a class with an Add method that validates the class state (the
    /// class invariants) before adding the <b>Person</b> object to the internal array and that code should
    /// throw an <see cref="InvalidOperationException"/>.
    /// <code><![CDATA[
    /// using CuttingEdge.Conditions;
    /// 
    /// public class Person { }
    /// 
    /// public class PersonCollection 
    /// {
    ///     public PersonCollection(int capicity)
    ///     {
    ///         this.Capacity = capicity;
    ///     }
    /// 
    ///     public void Add(Person person)
    ///     {
    ///         // Throws a ArgumentNullException when person == null
    ///         Condition.Requires(person, "person").IsNotNull();
    ///         
    ///         // Throws an InvalidOperationException on failure
    ///         Invariants.Invariant(this.Count, "Count").IsLessOrEqual(this.Capacity);
    ///         
    ///         this.AddInternal(person);
    ///     }
    ///
    ///     public int Count { get; private set; }
    ///     public int Capacity { get; private set; }
    ///     
    ///     private void AddInternal(Person person)
    ///     {
    ///         // some logic here
    ///     }
    ///     
    ///     public bool Contains(Person person)
    ///     {
    ///         // some logic here
    ///         return false;
    ///     }
    /// }
    /// ]]></code>
    /// The following code example will show the implementation of the <b>Invariants</b> class.
    /// <code><![CDATA[
    /// using System;
    /// using CuttingEdge.Conditions;
    /// 
    /// namespace MyCompanyRootNamespace
    /// {
    ///     public static class Invariants
    ///     {
    ///         public static ConditionValidator<T> Invariant<T>(T value)
    ///         {
    ///             return new InvariantValidator<T>("value", value);
    ///         }
    /// 
    ///         public static ConditionValidator<T> Invariant<T>(T value, string argumentName)
    ///         {
    ///             return new InvariantValidator<T>(argumentName, value);
    ///         }
    /// 
    ///         // Internal class that inherits from ConditionValidator<T>
    ///         sealed class InvariantValidator<T> : ConditionValidator<T>
    ///         {
    ///             public InvariantValidator(string argumentName, T value) : base(argumentName, value)
    ///             {
    ///             }
    ///             
    ///             public override Exception BuildException(string condition, string additionalMessage,
    ///                 ConstraintViolationType type)
    ///             {
    ///                 string message = condition + ".";
    ///                 
    ///                 if (!String.IsNullOrEmpty(additionalMessage))
    ///                 {
    ///                     message = condition + ". " + additionalMessage;
    ///                 }
    ///                 
    ///                 return new InvalidOperationException(message);
    ///             }
    ///         }
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    [DebuggerDisplay("{GetType().Name} ( ArgumentName: {ArgumentName}, Value: {Value} )")]
    public abstract class ConditionValidator<T>
    {
        /// <summary>Gets the value of the argument.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        // NOTE: We chose to make the Value a public field, so the Extension methods can use it, 
        // without we have to worry about extra method calls.
        public readonly T Value;

        private readonly string argumentName;

        /// <summary>Initializes a new instance of the <see cref="ConditionValidator{T}"/> class.</summary>
        /// <param name="argumentName">The name of the argument to be validated</param>
        /// <param name="value">The value of the argument to be validated</param>
        protected ConditionValidator(string argumentName, T value)
        {
            // This constructor is internal. It is not useful for a user to inherit from this class.
            // When this ctor is made protected, so should be the BuildException method.
            this.Value = value;
            this.argumentName = argumentName;
        }

        /// <summary>Gets the name of the argument.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public string ArgumentName
        {
            get { return this.argumentName; }
        }

        /// <summary>
        /// Throws an <see cref="Exception"/> which explains that the given condition does not hold.
        /// The exact type of <see cref="Exception"/> that will be thrown is determined by the
        /// <see cref="ConditionValidator{T}"/> implementation. The <see cref="ConditionValidator{T}"/> that
        /// is created by calling the <see cref="Condition.Requires{T}(T, string)">Requires</see> will always 
        /// call a <see cref="ArgumentException"/>, while the <see cref="ConditionValidator{T}"/> that is 
        /// created by the <see cref="Condition.Ensures{T}(T, string)">Ensures</see> method will always throw
        /// a <see cref="PostconditionException"/>.
        /// </summary>
        /// <param name="condition">
        /// A string describing the condition that does not hold. The condition should be written in the 
        /// following format: "{ArgumentName} should (not) be {check}". i.e. "value should be equal to 10".
        /// This way the generated exception message will be valid for both the Requires as Ensures 
        /// validations.
        /// </param>
        /// <exception cref="Exception">Will always be thrown.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public void Throw(string condition)
        {
            throw this.BuildException(condition, null, ConstraintViolationType.Default);
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>
        /// true if the specified System.Object is equal to the current System.Object; otherwise, false.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        [Obsolete("This method is not part of the conditions framework. Please use the IsEqualTo method.", true)]
#pragma warning disable 809 // Remove the Obsolete attribute from the overriding member, or add it to the ...
        public override bool Equals(object obj)
#pragma warning restore 809
        {
            return base.Equals(obj);
        }

        /// <summary>Returns the hash code of the current instance.</summary>
        /// <returns>The hash code of the current instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the <see cref="ConditionValidator{T}"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents the <see cref="ConditionValidator{T}"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>Gets the <see cref="System.Type"/> of the current instance.</summary>
        /// <returns>The <see cref="System.Type"/> instance that represents the exact runtime 
        /// type of the current instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public new Type GetType()
        {
            return base.GetType();
        }

        /// <summary>Builds an exception, that has to be thrown.</summary>
        /// <param name="condition">Describes the condition that doesn't hold, e.g., "Value should not be 
        /// null".</param>
        /// <param name="additionalMessage">An additional message that will be appended to the exception
        /// message, e.g. "The actual value is 3.". This value may be null or empty.</param>
        /// <param name="type">Gives extra information on the exception type that must be build. The actual
        /// implementation of the validator may ignore some or all values.</param>
        /// <returns>A newly created <see cref="Exception"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)] // see top of page for note on this attribute.
        public abstract Exception BuildException(string condition, string additionalMessage,
            ConstraintViolationType type);

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition, string additionalMessage)
        {
            return this.BuildException(condition, additionalMessage, ConstraintViolationType.Default);
        }

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition, ConstraintViolationType type)
        {
            return this.BuildException(condition, null, type);
        }

        // Builds an Exception with the specified condition
        internal Exception BuildException(string condition)
        {
            return this.BuildException(condition, null, ConstraintViolationType.Default);
        }
    }
}
