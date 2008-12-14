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
using System.Globalization;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotEndWith method.
    /// </summary>
    [TestClass]
    public class StringDoesNotEndWithTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith x' should fail.")]
        public void DoesNotEndWithTest01()
        {
            string a = "test";
            a.Requires().DoesNotEndWith(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"est\"' should fail.")]
        public void DoesNotEndWithTest02()
        {
            string a = "test";
            a.Requires().DoesNotEndWith("est");
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith null' should pass.")]
        public void DoesNotEndWithTest03()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().DoesNotEndWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"\"' should fail.")]
        public void DoesNotEndWithTest04()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().DoesNotEndWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith \"\"' should pass.")]
        public void DoesNotEndWithTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().DoesNotEndWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith null' should fail.")]
        public void DoesNotEndWithTest06()
        {
            string a = null;
            a.Requires().DoesNotEndWith(null);
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"me test\"' should pass.")]
        public void DoesNotEndWithTest07()
        {
            string a = "test";
            a.Requires().DoesNotEndWith("me test");
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"test\"' should fail with a correct exception message.")]
        public void DoesNotEndWithTest08()
        {
            string expectedMessage =
                "a should not end with 'test'." + Environment.NewLine +
                TestHelper.ArgumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").DoesNotEndWith("test");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith with conditionDescription parameter should pass.")]
        public void DoesNotEndWithTest09()
        {
            string a = "test";
            a.Requires().DoesNotEndWith("test me", string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing DoesNotEndWith should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void DoesNotEndWithTest10()
        {
            string a = "test me";
            try
            {
                a.Requires("a").DoesNotEndWith("me", "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description("Calling DoesNotEndWith should be language dependent.")]
        public void DoesNotEndWithTest11()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            string a = "hello and hi";

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

                // We check this using the Turkish-I problem.
                // see: http://msdn.microsoft.com/en-us/library/ms973919.aspx#stringsinnet20_topic5
                string turkishUpperCase = "HI";

                a.Requires().DoesNotEndWith(turkishUpperCase, StringComparison.CurrentCultureIgnoreCase);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }
    }
}