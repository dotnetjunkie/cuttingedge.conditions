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
    /// Tests the ValidatorExtensions.EndsWith method.
    /// </summary>
    [TestClass]
    public class StringEndsWithTests
    {
        [TestMethod]
        [Description("Calling EndsWith on string x with 'x EndsWith x' should pass.")]
        public void EndsWithTest01()
        {
            string a = "test";
            a.Requires().EndsWith(a);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"est\"' should pass.")]
        public void EndsWithTest02()
        {
            string a = "test";
            a.Requires().EndsWith("est");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith null' should fail.")]
        public void EndsWithTest03()
        {
            string a = "test";
            // A null value will never be found
            a.Requires().EndsWith(null);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"\"' should pass.")]
        public void EndsWithTest04()
        {
            string a = "test";
            // An empty string will always be found
            a.Requires().EndsWith(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Calling EndsWith on string x (null) with 'x EndsWith \"\"' should fail.")]
        public void EndsWithTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            a.Requires().EndsWith(String.Empty);
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (null) with 'x EndsWith null' should pass.")]
        public void EndsWithTest06()
        {
            string a = null;
            a.Requires().EndsWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"me test\"' should fail.")]
        public void EndsWithTest07()
        {
            string a = "test";
            a.Requires().EndsWith("me test");
        }

        [TestMethod]
        [Description("Calling EndsWith on string x (\"test\") with 'x EndsWith \"test me\"' should fail with a correct exception message.")]
        public void EndsWithTest08()
        {
            string expectedMessage =
                "a should end with 'test me'." + Environment.NewLine +
                TestHelper.ArgumentExceptionParameterName + ": a";

            try
            {
                string a = "test";
                a.Requires("a").EndsWith("test me");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [Description("Calling EndsWith with conditionDescription parameter should pass.")]
        public void EndsWithTest09()
        {
            string a = null;
            a.Requires().EndsWith(null, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing EndsWith should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void EndsWithTest10()
        {
            string a = "test";
            try
            {
                a.Requires("a").EndsWith("test me", "qwe {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("qwe a xyz"));
            }
        }

        [TestMethod]
        [Description("Calling EndsWith should be language dependent.")]
        public void StartsWithTest11()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            string a = "hello and hi";

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

                // We check this using the Turkish-I problem.
                // see: http://msdn.microsoft.com/en-us/library/ms973919.aspx#stringsinnet20_topic5
                string turkishUpperCase = "Hİ";

                a.Requires().EndsWith(turkishUpperCase, StringComparison.CurrentCultureIgnoreCase);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }
    }
}