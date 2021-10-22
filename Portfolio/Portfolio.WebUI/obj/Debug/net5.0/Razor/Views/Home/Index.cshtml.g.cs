#pragma checksum "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d024397e65a87e488c02401bf2289e47cfc6ac4"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d024397e65a87e488c02401bf2289e47cfc6ac4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51eb672d7c68a36c22bd56ffe03513e2801ddb56", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div role=""tabpanel"" class=""tab-pane fade in active"" id=""about-me"">
    <div class=""inside-sec"">
        <!-- BIO AND SKILLS -->
        <h5 class=""tittle"">About Me</h5>

        <!-- Blog -->
        <section class=""about-me padding-top-10"">

            <!-- Personal Info -->
            <ul class=""personal-info"">
                <li>
                    <p> <span> Name</span> ");
#nullable restore
#line 17 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                      Write(Model.PersonalDetails.PortfolioUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Age</span> ");
#nullable restore
#line 20 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                     Write(Model.PersonalDetails.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Location</span>");
#nullable restore
#line 23 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                         Write(Model.PersonalDetails.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Experience</span> ");
#nullable restore
#line 26 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                            Write(Model.PersonalDetails.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Degree</span>");
#nullable restore
#line 29 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                       Write(Model.PersonalDetails.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Career Level</span>");
#nullable restore
#line 32 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                             Write(Model.PersonalDetails.CareerLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Phone</span>");
#nullable restore
#line 35 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                      Write(Model.PersonalDetails.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> FAX</span>");
#nullable restore
#line 38 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                    Write(Model.PersonalDetails.Fax);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> E-mail</span> <a href=\"#.\">");
#nullable restore
#line 41 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                                     Write(Model.PersonalDetails.PortfolioUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </p>\r\n                </li>\r\n                <li>\r\n                    <p> <span> Website</span><a href=\"#.\"> ");
#nullable restore
#line 44 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                                      Write(Model.PersonalDetails.Website);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></p>\r\n                </li>\r\n            </ul>\r\n\r\n            <!-- I’m Web Designer -->\r\n            <h5 class=\"tittle\">");
#nullable restore
#line 49 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                          Write(Model.PersonalDetails.Occupation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <div class=\"padding-20\">\r\n                ");
#nullable restore
#line 51 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
           Write(Html.Raw(Model.PersonalDetails.About));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <!-- Services -->\r\n            <h5 class=\"tittle\">Services</h5>\r\n            <div class=\"row padding-20 margin-top-50\">\r\n");
#nullable restore
#line 56 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                 foreach (var item in Model.Services)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-4 text-center\">\r\n                        <div class=\"icon-box i-large ib-black\">\r\n                            <div class=\"ib-icon\"> <i");
            BeginWriteAttribute("class", " class=\"", 2342, "\"", 2410, 1);
#nullable restore
#line 60 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
WriteAttributeValue("", 2350, item.Icons.FirstOrDefault(i=>i.ServiceId==item.Id).IconLink, 2350, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i> </div>\r\n                            <div class=\"ib-info\">\r\n                                <h4 class=\"h6\">");
#nullable restore
#line 62 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                          Write(item.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p>");
#nullable restore
#line 63 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                              Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 67 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n            <!-- Skills -->\r\n            <h5 class=\"tittle\">Skills</h5>\r\n\r\n            <!-- Sound Engineering -->\r\n            <div class=\"panel-group accordion padding-20\" id=\"accordion\">\r\n\r\n");
#nullable restore
#line 76 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                 foreach (var item in Model.Skills)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""panel panel-default"">
                        <div class=""row"">
                            <div class=""col-sm-4"">
                                <!-- PANEL HEADING -->
                                <div class=""panel-heading"">
                                    <h4 class=""panel-title""> <a data-toggle=""collapse"" data-parent=""#accordion""");
            BeginWriteAttribute("href", " href=\"", 3384, "\"", 3400, 2);
            WriteAttributeValue("", 3391, "#", 3391, 1, true);
#nullable restore
#line 83 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
WriteAttributeValue("", 3392, item.Id, 3392, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapsed\">");
#nullable restore
#line 83 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                                                                                                                              Write(item.SkillName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a> </h4>
                                </div>
                            </div>
                            <!-- Skillls Bars -->
                            <div class=""col-sm-8"">
                                <div class=""progress"">
                                    <div class=""progress-bar"" role=""progressbar"" aria-valuenow=""80"" aria-valuemin=""0"" aria-valuemax=""100""");
            BeginWriteAttribute("style", " style=\"", 3819, "\"", 3856, 3);
            WriteAttributeValue("", 3827, "width:", 3827, 6, true);
#nullable restore
#line 89 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 3833, item.SkillPercentage, 3834, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3855, ";", 3855, 1, true);
            EndWriteAttribute();
            WriteLiteral("> <span class=\"sr-only\">60% Complete</span> </div>\r\n                                </div>\r\n\r\n                                <!-- Skillls Text -->\r\n                                <div");
            BeginWriteAttribute("id", " id=\"", 4042, "\"", 4055, 1);
#nullable restore
#line 93 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
WriteAttributeValue("", 4047, item.Id, 4047, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse collapsed\">\r\n                                    <div class=\"panel-body\">\r\n                                        <p>");
#nullable restore
#line 95 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                                      Write(item.SkillDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 101 "C:\Users\ACER\OneDrive\Desktop\Portfolio Project\PortfolioIB\Portfolio\Portfolio.WebUI\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </section>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
