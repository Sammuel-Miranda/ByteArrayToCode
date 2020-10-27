# ByteArrayToCode
A quick tool if you want to internalize a file declaring it as a byte array variable instead of a resource declaration in C# code

---

Sometimes instead of adding a file (usually a small one) as a resource file, implementing the RESX via a **StronglyTypedResourceBuilder** as allowed be the Visual Studio Resource Manager, i prefer to declare a static function that would return the array of bytes (**_for any particular reason_**). This simple piece of code is intended to do just that.

The "**ToCode(params)**" functions will return a string containing "**_return new byte[] { 0, 0, [...] 0 };_**" (with Ident options, line breaks after a _N_ number of bytes on a line and decoration options - printing 000 pattern instead of default _ToString()_ method) that can be copied at a source code file to serve as the returned byte array.
