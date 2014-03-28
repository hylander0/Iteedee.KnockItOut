![KnockItOut](Content/Images/KnockItOut.Png)

##ASP.NET MVC & Knockout Model Sharing Tutorial

This is a open source project on how to share your ASP.NET MVC Model to Knockout Viewmodel structure with the **MVC** framework and **Knockout's** ViewModel. Keeping with the *DRY* methodology we don't want to maintain multiple definitions of the same view model in **JavaScript** and in **C#**.


This also shows how to implement a reusable, self-contained MVC view components that are not relent on a **parent model** or **parent controller**

	@Html.RenderPartialKnockoutResourceWithScope("UserStats", "Widget", (string)Model.ToJson(), "cntrWidgetUserStats")

To touch briefly on the method seen above the `@Html.RenderPartialKnockoutResourceWithScope` does the following:

*   **ViewModel Registration**: Every view requiring MVVM implementation should have a Javascript View Model definition. It expects to file the js file using this pattern: `/Scripts/app/Views/{Controller}/{Action}.ViewModel.js`
*   **Knockout Model & MVC Model Mapping**: During initialization it will take MVC's `(string)Model.ToJson()` model data and map it to a Knockout observable object. This 
*   **Knockout Initialization**: Once the supporting view model class is registered it will be initialized and `applyBindings` will be called. The actuates the glue that is Knockout's **MVVM**.


For more information about the this project check out the articles supporting this project:

[**CLE Developer - ASP.NET MVC Model to Knockout Viewmodel**](http://blog.iteedee.com/2014/03/asp-net-mvc-model-to-knockout-viewmodel)

[**CLE Developer - Using ASP.NET MVC Partial View Controller Action**](http://blog.iteedee.com/2014/03/using-asp-net-mvc-partial-view-controller-action)


## Contributors

* Justin Hyland (author) Email: justin.hyland@live.com [Website](http://blog.iteedee.com)


====


##The MIT License##

Copyright (c) 2013 Justin Hyland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
