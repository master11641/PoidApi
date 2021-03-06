#pragma checksum "I:\Asp.net Core Projects\Barnama\Views\Book\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fba966aa43a5799bb3c0fdb8bce8c6e5ca4461e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_Index), @"mvc.1.0.view", @"/Views/Book/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fba966aa43a5799bb3c0fdb8bce8c6e5ca4461e", @"/Views/Book/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6443989dff877cf3bb82482603cd54cef33c9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Book>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "I:\Asp.net Core Projects\Barnama\Views\Book\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--نحوه‌ی راست به چپ سازی گرید-->\r\n<div class=\"k-rtl\">\r\n    <div id=\"report-grid\"></div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n     <script type=\"text/javascript\">\r\n        $(function () {\r\n            var productsDataSource = new kendo.data.DataSource({\r\n                transport: {\r\n                    read: {\r\n                        url: \"");
#nullable restore
#line 17 "I:\Asp.net Core Projects\Barnama\Views\Book\Index.cshtml"
                         Write(Url.Action("GetBooks", "Book"));

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
                    { field: ""title"", title: ""عنوان کتاب"" },
                    {
                        field: ""id"", title: ""عملیات"",
                        template: '<a  href=""/book/edit/#=id#"" class=""btn btn-primary"" >ویرایش</a>  <a  href=""/book/delete/#=id#"" class=""btn btn-danger"" >حذف</a>'
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591
