#pragma checksum "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77edc70b4ea955dc9d0cc3f5a36acfb71307c63c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_RegisterConfirm), @"mvc.1.0.view", @"/Views/Account/RegisterConfirm.cshtml")]
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
#line 1 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.Domain.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\_ViewImports.cshtml"
using Portfolio.Domain.Models.FormModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77edc70b4ea955dc9d0cc3f5a36acfb71307c63c", @"/Views/Account/RegisterConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51eb672d7c68a36c22bd56ffe03513e2801ddb56", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_RegisterConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml"
  
    var m = ViewBag.message as Tuple<bool, string>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-content mt-10 pt-7  mb-10\">\r\n    <section class=\"contact-section\">\r\n        <div class=\"container\">\r\n            <div class=\"row d-flex justify-content-center\">\r\n");
#nullable restore
#line 9 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml"
                 if (m.Item1 == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-8 alert alert-danger text-white\">\r\n                        ");
#nullable restore
#line 12 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml"
                   Write(m.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 14 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-8 alert alert-success text-white\">\r\n                        ");
#nullable restore
#line 18 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml"
                   Write(m.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 20 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Account\RegisterConfirm.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n</div>\r\n\r\n");
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
