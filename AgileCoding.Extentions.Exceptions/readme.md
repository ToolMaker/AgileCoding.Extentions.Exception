AgileCoding.Extensions.Exception
================================

Overview
--------

AgileCoding.Extensions.Exception is a .NET library that provides enhanced functionality for handling exceptions in your .NET applications. The package offers extension methods that can be used to obtain more comprehensive information from exceptions, including details from inner exceptions and reflection type load exceptions.

Installation
------------

This library is available as a NuGet package. You can install it using the NuGet package manager console:

bashCopy code

`Install-Package AgileCoding.Extensions.Exception -Version 2.0.5`

Features
--------

The library introduces the following extension methods for `System.Exception`:

1.  ToStringAll: Provides a string representation of an exception and all its inner exceptions.

2.  AddReflectionTypeLoadException: Extends an exception with additional information if the exception is of type `ReflectionTypeLoadException`.

Usage
-----

Here's a brief example of how to use these features in your code:

```csharp
using AgileCoding.Extentions.Exceptions;
using System;

try
{
    // Your code here...
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToStringAll());
    var updatedEx = ex.AddReflectionTypeLoadException<Exception>();
    // Handle or log the updatedEx...
}
```

Documentation
-------------

For more detailed information about the usage of this library, please refer to the [official documentation](https://github.com/ToolMaker/AgileCoding.Extentions.Exception/wiki).

License
-------

This project is licensed under the terms of the MIT license. For more information, see the [LICENSE](https://github.com/ToolMaker/AgileCoding.Extentions.Exception/blob/main/LICENSE) file.

Contributing
------------

Contributions are welcome! Please see our [contributing guidelines](https://github.com/ToolMaker/AgileCoding.Extentions.Exception/blob/main/CONTRIBUTING.md) for more details.