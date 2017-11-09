# Welcome to CuttingEdge.Conditions
CuttingEdge.Conditions is a library that helps developers to write pre- and postcondition validations in their C# 3.0 and VB.NET 9.0 code base. Writing these validations is easy and it improves the readability and maintainability of code.
## Overview
CuttingEdge.Conditions is build up upon the new C# 3.0 and VB.NET 9.0 extension method mechanism and it allows you to validate arguments in a simple and fluent way. The following example gives a quick overview on the way you could write your pre- and postconditions.

**C# example**
``` c#
public ICollection GetData(Nullable<int> id, string xml, IEnumerable<int> col)
{
    // Check all preconditions:
    Condition.Requires(id, nameof(id))
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsInRange(1, 999)    // ArgumentOutOfRangeException on failure
        .IsNotEqualTo(128);   // throws ArgumentException on failure

    Condition.Requires(xml, nameof(xml))
        .StartsWith("<data>") // throws ArgumentException on failure
        .EndsWith("</data>")  // throws ArgumentException on failure
        .Evaluate(xml.Contains("abc") || xml.Contains("cba")); // arg ex

    Condition.Requires(col, nameof(col))
        .IsNotNull()          // throws ArgumentNullException on failure
        .IsEmpty()            // throws ArgumentException on failure
        .Evaluate(c => c.Contains(id.Value) || c.Contains(0)); // arg ex

    // Do some work

    // Example: Call a method that should not return null
    object result = BuildResults(xml, col);

    // Check all postconditions:
    Condition.Ensures(result, nameof(result))
        .IsOfType(typeof(ICollection)); // throws PostconditionException on failure

    return (ICollection)result;
}
    
public static int[] Multiply(int[] left, int[] right)
{
    Condition.Requires(left, nameof(left)).IsNotNull();
    
    // You can add an optional description to each check
    Condition.Requires(right, nameof(right))
        .IsNotNull()
        .HasLength(left.Length, "left and right should have the same length");
    
    // Do multiplication
}
```

**VB.NET example**
``` vb
Public Function GetData(ByVal id As Integer?, ByVal xml As String, _
    ByVal col As ICollection) As ICollection
    ' Check all preconditions:
    Condition.Requires(id, nameof(id)).IsNotNull().IsInRange(1, 999).IsNotEqualTo(128)
    
    Condition.Requires(xml, nameof(xml)).StartsWith("<data>").EndsWith("</data>")
    
    Condition.Requires(col, nameof(col)).IsNotNull().IsEmpty()
    
    ' Do some work
   
    ' Example: Call a method that should not return null
    Dim result = BuildResults(xml, col)
    
    ' Check all postconditions:
    Condition.Ensures(result, "result").IsOfType(GetType(ICollection))
    
    Return result
End Function
    
Public Shared Function Multiply(left As Integer(), right As Integer()) As Integer()
    left.Requires("left").IsNotNull()
    
    ' You can add an optional description to each check
    right.Requires("right").IsNotNull() _
        .HasLength(left.Length, "left and right should have the same length")
    
    ' Do multiplication
End Function
```

The previous example showed some important features of the library. The example showed the library's ability to:

* do precondition checks by writing **`Condition.Requires`**;
* do postcondition checks by writing **`Condition.Ensures`**;
* fluently chain calls to the validation methods, just separated by a dot;
* work with nullable data types;
* validate string objects;
* validate collections;
* do a type check on the variable.

**Note:** _A particular validation is executed immediately when it's method is called, and therefore all checks are executed in the order in which they are written._

## Getting started
CuttingEdge Conditions is [available as NuGet package](http://nuget.org/List/Packages/CuttingEdge.Conditions). If you're not using [NuGet](http://nuget.org), please follow the steps below, to start using CuttingEdge.Conditions:
* Go to the [Downloads](http://conditions.codeplex.com/Release/ProjectReleases.aspx#ReleaseFiles) tab and download the latest _runtime library_;
* Unpack the downloaded .zip file;
* Add the CuttingEdge.Conditions.dll to your C# 3.0 or VB.NET 9.0 project by right-clicking on the project in the Visual Studio solution explorer and selecting 'Add Reference...'. Note that you can safely use CuttingEdge.Conditions in .NET 2.0 projects, as long as you use C# 3.0 or VB.NET 9.0.
* Optionally (but advisable), you can copy the contents of the unpacked 'Code Snippets' folder to your "{MY DOCUMENTS}\Visual Studio 2008\Code Snippets" folder.
* You are ready to validate! Just add the **`CuttingEdge.Conditions`** namespace at the top of a source file and use the 'requires' and 'ensures' code snippets to start writing pre- and postconditions within your code.

## More information
For more information on this project please visit the following blog post or wiki page:
* [.NET Junkie's blog - Introducing CuttingEdge.Conditions](http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=38) or jump directly to the [Designed Behavior](http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=38#Designed_Behavior) section of the post to find out more about design choices that might affect you.
* [Wiki: Extending CuttingEdge.Conditions](https://github.com/dotnetjunkie/cuttingedge.conditions/wiki/Extending-CuttingEdge.Conditions)
There are some interesting discussions about CuttingEdge.Conditions here:
* [The Code Project - CuttingEdge.Conditions - Discussions](http://www.codeproject.com/KB/library/conditions.aspx#_comments)
* or you can start a new discussion in the [Discussions](http://conditions.codeplex.com/Thread/List.aspx) tab.
You can download the library documentation from the [Downloads](http://conditions.codeplex.com/Release/ProjectReleases.aspx) tab or browse it online here:
* [CuttingEdge.Conditions - Reference Library](http://conditions.cuttingedge.it/ReferenceLibrary/)
