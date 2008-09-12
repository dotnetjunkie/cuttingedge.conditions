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
    /// <summary>
    /// This attribute is used to indicate that the decorated method is to big to be a candidate to be inlined 
    /// by the JIT compiler and that we don't check the method if it's small enough during unit testing.
    /// </summary>
    internal sealed class MethodToBigToBeInlinedAttribute : Attribute
    {
    }
}