#pragma checksum "I:\Asp.net Core Projects\Barnama\Views\Book\BookCountPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23aee7c395695125ee97280e2b86593b71772560"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_BookCountPartial), @"mvc.1.0.view", @"/Views/Book/BookCountPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "I:\Asp.net Core Projects\Barnama\Views\_ViewImports.cshtml"
using Barnama;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\Asp.net Core Projects\Barnama\Views\_ViewImports.cshtml"
using Barnama.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23aee7c395695125ee97280e2b86593b71772560", @"/Views/Book/BookCountPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6443989dff877cf3bb82482603cd54cef33c9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_BookCountPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""col-12 col-sm-6 col-md-3"">
    <div class=""info-box"">
        <span class=""info-box-icon bg-info elevation-1""><i class=""fa fa-gear""></i></span>

        <div class=""info-box-content"">
            <span class=""info-box-text"">کتابها</span>
            <span class=""info-box-number"">
               ");
#nullable restore
#line 8 "I:\Asp.net Core Projects\Barnama\Views\Book\BookCountPartial.cshtml"
          Write(ViewBag.BookCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <small>%</small>\r\n            </span>\r\n        </div>\r\n        <!-- /.info-box-content -->\r\n    </div>\r\n    <!-- /.info-box -->\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
