#pragma checksum "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbdb8c449afc9791f740da33f153d34de763f408"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Congress_Index), @"mvc.1.0.view", @"/Views/Congress/Index.cshtml")]
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
#line 1 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
using IconTrendsPresentation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbdb8c449afc9791f740da33f153d34de763f408", @"/Views/Congress/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b99eb2a21937ed245ee21a72fec6d90306ea201", @"/Views/_ViewImports.cshtml")]
    public class Views_Congress_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Congress>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""col-12  m-4 "">
    <div class=""bg-secondary rounded h-100 p-4"">
        <h6 class=""mb-4"">Kongreler</h6>
        <div class=""table-responsive"">
            <table class=""table table-hover"">
                <thead class=""text-white"">
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Kongre Adı</th>
                        <th scope=""col"">Kongre Hakkında</th>
                        <th scope=""col"">Kongre Şehri</th>
                        <th scope=""col"">Kongre Yeri</th>
                        <th scope=""col"">Kongre tarihi</th>
                        <th scope=""col"">Durumu</th>
                        <th scope=""col"">Detay</th>
                        <th scope=""col"">Güncelle</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 29 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><b class=\"txt-white\">");
#nullable restore
#line 32 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                                            Write(item.CongressId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                       Write(item.CongressName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td> ");
#nullable restore
#line 34 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                         Write(item.CongressAbout.Length > 150 ? item.CongressAbout.Substring(0, item.CongressAbout.Substring(0,155).LastIndexOf(" "))+"..." : item.CongressAbout + "...");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                       Write(item.CongressCity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                       Write(item.CongressPlace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                       Write(item.CongressDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                              
                            string status = "";
                            string color = "";
                            if (item.CongressStatus==true)
                            {
                                status = "Aktif";
                                color = "btn btn-sm btn-success ";
                            }
                            else
                            {
                                status = "Geçmiş";
                                color = "btn btn-primary rounded-pill";
                            }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <p");
            BeginWriteAttribute("class", " class=\"", 2247, "\"", 2261, 1);
#nullable restore
#line 52 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
WriteAttributeValue("", 2255, color, 2255, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                                      Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </td>\r\n                        <td><a href=\"#\" class=\"btn btn-sm btn-outline-info\">Detay</a></td>\r\n                        <td><a href=\"#\" class=\"btn btn-sm btn-outline-warning\">Güncelle</a></td>\r\n                    </tr>\r\n");
#nullable restore
#line 57 "C:\Users\ibrah\source\repos\IconTrendsBackend\IconTrendsPresentation\Views\Congress\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n            <a href=\"yenikongre.html\" type=\"button\" class=\"btn btn-outline-success mt-3\">Yeni Kongre Oluştur</a>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Congress>> Html { get; private set; }
    }
}
#pragma warning restore 1591