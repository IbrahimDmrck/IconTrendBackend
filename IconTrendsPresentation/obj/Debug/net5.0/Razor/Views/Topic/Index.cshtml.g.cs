#pragma checksum "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39d974be42059fa55c6e2fd3ff9ccf36306c3903"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Topic_Index), @"mvc.1.0.view", @"/Views/Topic/Index.cshtml")]
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
#line 1 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\_ViewImports.cshtml"
using IconTrendsPresentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
using IconTrendsPresentation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39d974be42059fa55c6e2fd3ff9ccf36306c3903", @"/Views/Topic/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b99eb2a21937ed245ee21a72fec6d90306ea201", @"/Views/_ViewImports.cshtml")]
    public class Views_Topic_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Topic>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-11  m-4 "">
    <div class=""bg-secondary rounded h-100 p-4"">
        <h6 class=""mb-4"">Konular</h6>
        <div class=""table-responsive"">
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Kongre Adı</th>
                        <th scope=""col"">Başlık Adı</th>
                        <th scope=""col"">Alt Başlıklar</th>
                        <th scope=""col"">Sil</th>
                        <th scope=""col"">Güncelle</th>

                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 25 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
#nullable restore
#line 28 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 29 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
                           Write(item.CongressId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 30 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
                           Write(item.TopicName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
                           Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><a href=\"#\" class=\"btn btn-outline-primary\">Sil</a></td>\r\n                            <td><a href=\"#\" class=\"btn btn-outline-warning\">Güncelle</a></td>\r\n                        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Topic\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n            <a href=\"BaslikEkle.html\" type=\"button\" class=\"btn btn-outline-success mt-3\">Yeni Başlık Oluştur</a>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Topic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
