#pragma checksum "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "469f76782783dfcdc8cb9ea767adb2c7d1f61c01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"469f76782783dfcdc8cb9ea767adb2c7d1f61c01", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6443989dff877cf3bb82482603cd54cef33c9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml"
  
  ViewData["Title"] = "داشبورد";

#line default
#line hidden
#nullable disable
            DefineSection("contentheader", async() => {
                WriteLiteral(@"
<div class=""content-header"">
  <div class=""container-fluid"">
    <div class=""row mb-2"">
      <div class=""col-sm-6"">
        <h1 class=""m-0 text-dark"">داشبورد</h1>
      </div><!-- /.col -->
      <div class=""col-sm-6"">
        <ol class=""breadcrumb float-sm-left"">
          <li class=""breadcrumb-item""><a href=""#"">خانه</a></li>
          <li class=""breadcrumb-item active"">داشبورد</li>
        </ol>
      </div><!-- /.col -->
    </div><!-- /.row -->
  </div><!-- /.container-fluid -->
</div>
");
            }
            );
            WriteLiteral("<div class=\"row\">\r\n  ");
#nullable restore
#line 22 "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("LessonCountComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  ");
#nullable restore
#line 23 "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("BookCountComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  ");
#nullable restore
#line 24 "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("InvoiceCountComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  ");
#nullable restore
#line 25 "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("UserCountComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div class=\"row\">\r\n  <div class=\"col-md-8\">\r\n");
#nullable restore
#line 29 "I:\Asp.net Core Projects\Barnama\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("LastUsersComponent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  </div>\r\n  <div class=\"col-md-4\">\r\n\r\n  </div>\r\n</div>\r\n");
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