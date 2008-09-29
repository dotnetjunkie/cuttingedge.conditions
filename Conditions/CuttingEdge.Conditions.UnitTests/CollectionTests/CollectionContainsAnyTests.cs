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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.ContainsAny method.
    /// </summary>
    [TestClass]
    public class CollectionContainsAnyTests
    {
        // Calling ContainsAny on an array should compile.
        internal static void CollectionContainsAnyShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> any = c;
            c.Requires().ContainsAny(any);
        }

        // Calling ContainsAny on a Collection should compile.
        internal static void CollectionContainsAnyShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAny(c);
        }

        // Calling ContainsAny on an IEnumerable should compile.
        internal static void CollectionContainsAnyShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            c.Requires().ContainsAny(c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling ContainsAny on a null collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            c.Requires().ContainsAny(elements);
        }

        [TestMethod]
        [Description("Calling ContainsAny with a 'any' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAnyTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionContainsAnyTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 4, 5, 6, 7 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with a 'any' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAnyTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 5, 6, 7, 8 };
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an untyped 'any' collection containing one element of the tested typed collection should pass.")]
        public void CollectionContainsAnyTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 4, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an untyped 'any' collection containing one element of the tested untyped collection should pass.")]
        public void CollectionContainsAnyTest11()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an untyped 'any' collection containing one element of different types of the tested untyped collection should pass.")]
        public void CollectionContainsAnyTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Friday, 2 };

            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an untyped 'any' collection containing no elements of the tested typed collection should fail.")]
        public void CollectionContainsAnyTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an untyped 'any' collection containing no elements of the tested untyped collection should fail.")]
        public void CollectionContainsAnyTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an untyped 'any' collection containing no elements of different types of the tested untyped collection should fail.")]
        public void CollectionContainsAnyTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Saturday, 2, new object() };

            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an empty untyped collection should fail.")]
        public void CollectionContainsAnyTest16()
        {
            ArrayList c = new ArrayList();
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling ContainsAny with an empy 'any' collection should fail.")]
        public void CollectionContainsAnyTest17()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList();
            c.Requires().ContainsAny(any);
        }

        [TestMethod]
        [Description("Calling ContainsAny with an two collections that implement IEnumerable<T> but not IColletion<T> should pass.")]
        public void CollectionContainsAnyTest18()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            c.Requires().ContainsAny(c);
        }
    }
}