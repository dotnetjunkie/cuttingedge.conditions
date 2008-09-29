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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.HasLength method.
    /// </summary>
    [TestClass]
    public class CollectionHasLengthTests
    {
        [TestMethod]
        [Description("Calling HasLength(0) with an untyped collection containing no elements should pass.")]
        public void CollectionHasLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            queue.Requires().HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(0) with an typed collection containing no elements should pass.")]
        public void CollectionHasLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(1) with an untyped collection containing one element should pass.")]
        public void CollectionHasLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            queue.Requires().HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength(1) with an typed collection containing one element should pass.")]
        public void CollectionHasLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            set.Requires().HasLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(0) with a collection containing one element should fail.")]
        public void CollectionHasLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            set.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(1) with an ArrayList containing one element should fail.")]
        public void CollectionHasLengthTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().HasLength(1);
        }

        [TestMethod]
        [Description("Calling HasLength(0) with an ArrayList containing no elements should pass.")]
        public void CollectionHasLengthTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            list.Requires().HasLength(0);
        }

        [TestMethod]
        [Description("Calling HasLength(0) on a null reference should pass.")]
        public void CollectionHasLengthTest08()
        {
            IEnumerable list = null;

            list.Requires().HasLength(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling HasLength(1) on a null reference should fail.")]
        public void CollectionHasLengthTest09()
        {
            IEnumerable list = null;

            list.Requires().HasLength(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling HasLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionHasLengthTest10()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            set.Requires().HasLength(1);
        }
    }
}