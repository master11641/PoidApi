#pragma checksum "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\InvoiceCountComponent\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f170e0b322ade94c34ad8211b6797d9350b5e1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_InvoiceCountComponent_Default), @"mvc.1.0.view", @"/Views/Shared/Components/InvoiceCountComponent/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f170e0b322ade94c34ad8211b6797d9350b5e1d", @"/Views/Shared/Components/InvoiceCountComponent/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6443989dff877cf3bb82482603cd54cef33c9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_InvoiceCountComponent_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""col-12 col-sm-6 col-md-3"">
            <div class=""info-box mb-3"">
              <span class=""info-box-icon bg-success elevation-1""><i class=""fa fa-shopping-cart""></i></span>

              <div class=""info-box-content"">
                <span class=""info-box-text"">درآمد کل</span>
                <span class=""info-box-number"">");
#nullable restore
#line 7 "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\InvoiceCountComponent\Default.cshtml"
                                         Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ریال</span>\r\n              </div>\r\n              <!-- /.info-box-content -->\r\n            </div>\r\n            <!-- /.info-box -->\r\n          </div>");
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
