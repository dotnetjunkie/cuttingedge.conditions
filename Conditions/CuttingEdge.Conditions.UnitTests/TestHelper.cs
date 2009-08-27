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

namespace CuttingEdge.Conditions.UnitTests
{
    /// <summary>
    /// Helper class for testing.
    /// </summary>
    public static class TestHelper
    {
        // Cache the language dependent 'Parameter name' string.
        // This enables all unit tests to succeed, even when run on different languages of the .NET FX.
        public static readonly string CultureSensitiveArgumentExceptionParameterText =
            GetCultureSensitiveArgumentExceptionParameterText();          

        private static string GetCultureSensitiveArgumentExceptionParameterText()
        {
            ArgumentException exception = new ArgumentException(string.Empty, "p");

            string exceptionPart = exception.Message.Replace(": p", string.Empty);

            string cultureSensitiveParameterText = exceptionPart.Trim();

            return cultureSensitiveParameterText;
        }
    }
}