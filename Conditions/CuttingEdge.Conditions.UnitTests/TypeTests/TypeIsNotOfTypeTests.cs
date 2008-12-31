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
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.TypeTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotOfType method.
    /// </summary>
    [TestClass]
    public class TypeIsNotOfTypeTests
    {
        [TestMethod]
        [Description("Calling IsNotOfType on null reference should pass.")]
        public void IsNotOfTypeTest0()
        {
            object o = null;

            // Null objects are not checked, so check must always succeed.
            o.Requires().IsNotOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotOfTypeTest1()
        {
            object o = "String";

            o.Requires().IsNotOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a down-casted object tested to be the real type should fail.")]
        public void IsNotOfTypeTest2()
        {
            object o = "String";

            o.Requires().IsNotOfType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on an object tested to be the parent type should fail.")]
        public void IsNotOfTypeTest3()
        {
            string s = "String";

            s.Requires().IsNotOfType(typeof(object));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotOfTypeTest4()
        {
            string s = "String";

            s.Requires().IsNotOfType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a System.Object tested to be System.Object type should fail.")]
        public void IsNotOfTypeTest5()
        {
            object o = new object();

            o.Requires().IsNotOfType(typeof(object));
        }

        [TestMethod]
        [Description("Calling IsNotOfType on a down-casted object tested to be an incomparable type should pass.")]
        public void IsNotOfTypeTest6()
        {
            object o = "String";

            o.Requires().IsNotOfType(typeof(EventArgs));
        }

        [TestMethod]
        [Description("Calling IsNotOfType on an object tested to be an incomparable type should pass.")]
        public void IsNotOfTypeTest7()
        {
            string s = "String";

            s.Requires().IsNotOfType(typeof(EventArgs));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on an object implementing ICollection tested not to implement ICollection should fail.")]
        public void IsNotOfTypeTest8()
        {
            ICollection o = new Collection<int>();

            o.Requires().IsNotOfType(typeof(ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotOfType on a DayOfWeek tested to implement DayOfWeek should fail with an ArgumentException.")]
        public void IsNotOfTypeTest9()
        {
            object day = DayOfWeek.Monday;

            day.Requires().IsNotOfType(typeof(DayOfWeek));
        }
    }
}