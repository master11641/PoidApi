#pragma checksum "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\LastUsersComponent\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "802e0adf1262df7d185b4f0de2f1a9f46a7c0102"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LastUsersComponent_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LastUsersComponent/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"802e0adf1262df7d185b4f0de2f1a9f46a7c0102", @"/Views/Shared/Components/LastUsersComponent/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6443989dff877cf3bb82482603cd54cef33c9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LastUsersComponent_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("100x100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/user.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- USERS LIST -->
<div class=""card"">
  <div class=""card-header"">
    <h3 class=""card-title"">آخرین اعضا</h3>

    <div class=""card-tools"">
      <span class=""badge badge-danger"">۸ پیام جدید</span>
      <button type=""button"" class=""btn btn-tool"" data-widget=""collapse""><i class=""fa fa-minus""></i>
      </button>
      <button type=""button"" class=""btn btn-tool"" data-widget=""remove""><i class=""fa fa-times""></i>
      </button>
    </div>
  </div>
  <!-- /.card-header -->
  <div class=""card-body p-0"">
    <ul class=""users-list clearfix"">
");
#nullable restore
#line 19 "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\LastUsersComponent\Default.cshtml"
       foreach (var user in Model)
      {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "802e0adf1262df7d185b4f0de2f1a9f46a7c01025471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n          <a class=\"users-list-name mt-2\" href=\"#\">");
#nullable restore
#line 23 "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\LastUsersComponent\Default.cshtml"
                                              Write(user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 23 "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\LastUsersComponent\Default.cshtml"
                                                         Write(user.Family);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n");
            WriteLiteral("        </li>\r\n");
#nullable restore
#line 26 "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\LastUsersComponent\Default.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </ul>\r\n    <!-- /.users-list -->\r\n  </div>\r\n  <!-- /.card-body -->\r\n  <div class=\"card-footer text-center\">\r\n    <a");
            BeginWriteAttribute("href", " href=\'", 1040, "\'", 1074, 1);
#nullable restore
#line 34 "I:\Asp.net Core Projects\Barnama\Views\Shared\Components\LastUsersComponent\Default.cshtml"
WriteAttributeValue("", 1047, Url.Action("Index","User"), 1047, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">مشاهده همه کاربران</a>\r\n  </div>\r\n  <!-- /.card-footer -->\r\n</div>\r\n<!--/.card -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
