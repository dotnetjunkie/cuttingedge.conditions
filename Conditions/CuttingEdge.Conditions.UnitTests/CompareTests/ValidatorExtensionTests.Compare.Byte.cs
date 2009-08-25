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

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Byte'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareByteTests
    {
        private static readonly Byte One = 1;
        private static readonly Byte Two = 2;
        private static readonly Byte Three = 3;
        private static readonly Byte Four = 4;
        private static readonly Byte Five = 5;

        #region IsByteInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should fail.")]
        public void IsByteInRangeTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound = x < upper bound' should pass.")]
        public void IsByteInRangeTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x < upper bound' should pass.")]
        public void IsByteInRangeTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with 'lower bound < x = upper bound' should pass.")]
        public void IsByteInRangeTest04()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Byte x with 'lower bound < x > upper bound' should fail.")]
        public void IsByteInRangeTest05()
        {
            Byte a = Five;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Byte x with conditionDescription should pass.")]
        public void IsByteInRangeTest06()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteInRangeTest07()
        {
            Byte a = Five;
            try
            {
                Condition.Requires(a, "a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteInRange

        #region IsByteNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound > x < upper bound' should pass.")]
        public void IsByteNotInRangeTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should fail.")]
        public void IsByteNotInRangeTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x < upper bound' should fail.")]
        public void IsByteNotInRangeTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x = upper bound' should fail.")]
        public void IsByteNotInRangeTest04()
        {
            Byte a = Four;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x > upper bound' should pass.")]
        public void IsByteNotInRangeTest05()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Byte x with conditionDescription should pass.")]
        public void IsByteNotInRangeTest06()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotInRangeTest07()
        {
            Byte a = Four;
            try
            {
                Condition.Requires(a, "a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteNotInRange

        #region IsByteGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should fail.")]
        public void IsByteGreaterThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound = x' should fail.")]
        public void IsByteGreaterThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterThanTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterThanTest05()
        {
            Byte a = Three;
            try
            {
                Condition.Requires(a, "a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteGreaterThan

        #region IsByteNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with 'x = upper bound' should pass.")]
        public void IsByteNotGreaterThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterThanTest05()
        {
            Byte a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteNotGreaterThan

        #region IsByteGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteGreaterOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound = x' should pass.")]
        public void IsByteGreaterOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterOrEqualTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterOrEqualTest05()
        {
            Byte a = One;
            try
            {
                Condition.Requires(a, "a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteGreaterOrEqual

        #region IsByteNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterOrEqualTest04()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterOrEqualTest05()
        {
            Byte a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteNotGreaterOrEqual

        #region IsByteLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should fail.")]
        public void IsByteLessThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteLessThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessThanTest05()
        {
            Byte a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteLessThan

        #region IsByteNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound = x' should pass.")]
        public void IsByteNotLessThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessThanTest05()
        {
            Byte a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteNotLessThan

        #region IsByteLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with 'x = upper bound' should pass.")]
        public void IsByteLessOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteLessOrEqualTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessOrEqualTest05()
        {
            Byte a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteLessOrEqual

        #region IsByteNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound = x' should fail.")]
        public void IsByteNotLessOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessOrEqualTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessOrEqualTest05()
        {
            Byte a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsNotLessOrEqual

        #region IsByteEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should fail.")]
        public void IsByteEqualToTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with 'x = other' should pass.")]
        public void IsByteEqualToTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Byte x with 'x > other' should fail.")]
        public void IsByteEqualToTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteEqualToTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteEqualToTest05()
        {
            Byte a = Three;
            try
            {
                Condition.Requires(a, "a").IsEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteEqualTo

        #region IsByteNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x < other' should pass.")]
        public void IsByteNotEqualToTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should fail.")]
        public void IsByteNotEqualToTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with 'x > other' should pass.")]
        public void IsByteNotEqualToTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteNotEqualToTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotEqualToTest05()
        {
            Byte a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsByteNotEqualTo
    }
}