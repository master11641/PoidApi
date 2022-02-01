#pragma checksum "I:\Asp.net Core Projects\Barnama\Views\Lesson\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e2599476e17d990cbdacb87323e149244ab86f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lesson_Index), @"mvc.1.0.view", @"/Views/Lesson/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2599476e17d990cbdacb87323e149244ab86f7", @"/Views/Lesson/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6443989dff877cf3bb82482603cd54cef33c9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Lesson_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Lesson>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "I:\Asp.net Core Projects\Barnama\Views\Lesson\Index.cshtml"
  
    ViewData["Title"] = "درس ها";

#line default
#line hidden
#nullable disable
            DefineSection("contentheader", async() => {
                WriteLiteral(@"
<div class=""content-header"">
  <div class=""container-fluid"">
    <div class=""row mb-2"">
      <div class=""col-sm-6"">
        <h1 class=""m-0 text-dark"">دروس</h1>
      </div><!-- /.col -->
      <div class=""col-sm-6"">
        <ol class=""breadcrumb float-sm-left"">
          <li class=""breadcrumb-item""><a");
                BeginWriteAttribute("href", " href=\'", 409, "\'", 443, 1);
#nullable restore
#line 15 "I:\Asp.net Core Projects\Barnama\Views\Lesson\Index.cshtml"
WriteAttributeValue("", 416, Url.Action("Index","Home"), 416, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">خانه</a></li>\r\n          <li class=\"breadcrumb-item active\">درس ها</li>\r\n        </ol>\r\n      </div><!-- /.col -->\r\n    </div><!-- /.row -->\r\n  </div><!-- /.container-fluid -->\r\n</div>\r\n");
            }
            );
            WriteLiteral("<!--نحوه‌ی راست به چپ سازی گرید-->\r\n<div class=\"k-rtl\">\r\n    <div id=\"report-grid\"></div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n     <script type=\"text/javascript\">\r\n        $(function () {\r\n            var productsDataSource = new kendo.data.DataSource({\r\n                transport: {\r\n                    read: {\r\n                        url: \"");
#nullable restore
#line 34 "I:\Asp.net Core Projects\Barnama\Views\Lesson\Index.cshtml"
                         Write(Url.Action("GetLessons", "Lesson"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                        dataType: ""json"",
                        contentType: 'application/json; charset=utf-8',
                        type: 'GET'
                    },
                    parameterMap: function (options) {
                        return kendo.stringify(options);
                    }
                },
                schema: {
                    data: ""data"",
                    total: ""total"",
                    model: {
                        fields: {
                            ""id"": { type: ""number"" }, //تعیین نوع فیلد برای جستجوی پویا مهم است
                            ""title"": { type: ""string"" }                       
                        }
                    }
                },
                error: function (e) {
                    alert(e.errorThrown);
                },
                pageSize: 10,
                sort: { field: ""id"", dir: ""desc"" },
                serverPaging: true,
                serverFiltering: true,
            ");
                WriteLiteral(@"    serverSorting: true
            });

            $(""#report-grid"").kendoGrid({
                dataSource: productsDataSource,
                autoBind: true,
                scrollable: false,
                pageable: true,
                sortable: true,
                filterable: true,
                reorderable: true,
                columnMenu: true,
                columns: [
                    { field: ""id"", title: ""شماره"", width: ""130px"" },
                    { field: ""title"", title: ""عنوان درس"" },
                    {
                        field: ""id"", title: ""عملیات"",
                        template: '<a  href=""/lesson/edit/#=id#"" class=""btn btn-primary"" >ویرایش</a>  <a  href=""/lesson/delete/#=id#"" class=""btn btn-danger"" >حذف</a>'
                    }
              
                ]
            });
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Lesson>> Html { get; private set; }
    }
}
#pragma warning restore 1591
