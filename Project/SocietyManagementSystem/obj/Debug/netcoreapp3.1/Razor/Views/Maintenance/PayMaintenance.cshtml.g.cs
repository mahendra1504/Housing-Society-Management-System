#pragma checksum "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26cef4b1b4aa0f67578b6114bece75131ad78608"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Maintenance_PayMaintenance), @"mvc.1.0.view", @"/Views/Maintenance/PayMaintenance.cshtml")]
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
#line 1 "C:\Asp.Net Project\SocietyManagementSystem\Views\_ViewImports.cshtml"
using SocietyManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Asp.Net Project\SocietyManagementSystem\Views\_ViewImports.cshtml"
using SocietyManagementSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26cef4b1b4aa0f67578b6114bece75131ad78608", @"/Views/Maintenance/PayMaintenance.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28c303a05b9ea411dac0b935f240a92aad37942c", @"/Views/_ViewImports.cshtml")]
    public class Views_Maintenance_PayMaintenance : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SocietyManagementSystem.Models.Maintenance>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/loginhd.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-image1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PayMaintenanceDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
  
    ViewData["Title"] = "PayMaintenance";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>

    .bg-image {
        position: absolute;
        width: 35%;
        height: 50%;
        margin-right: 30px;
        margin-left: 600px;
        margin-top: 10px;
    }

    .bg-image1 {
        width: 100%;
        height: 100%;
        position: fixed;
        right: 0;
        left: 0;
        top: 0;
        bottom: 0;
    }

    .reg_label {
        position: absolute;
        top: 60px;
        bottom: 0;
        margin-left: 30px;
        margin-right: 0;
        color: snow;
    }

    div {
        width: 200%;
    }

    input[type=text], input[type=password], input[type=email], input[type=number], input[type=date] {
        border-radius: 25px;
    }

    label {
        color: snow;
        font-size: 18px;
        font-weight: 500;
    }

    h1 {
        text-shadow: 2px 2px 5px;
    }

    .table {
        position: absolute;
        margin-top: 70px;
        margin-left: 0;
        width: 70%;
    }

    th {
        color: s");
            WriteLiteral("now;\r\n    }\r\n\r\n    a {\r\n        color: snow;\r\n    }\r\n\r\n    td {\r\n        color: snow;\r\n    }\r\n\r\n    th, td {\r\n        border-bottom: 1px solid #ddd;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cef4b1b4aa0f67578b6114bece75131ad786085996", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "26cef4b1b4aa0f67578b6114bece75131ad786086258", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <h1 class=\"reg_label\">Maintenance</h1>\r\n\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 85 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
               Write(Html.DisplayNameFor(model => model.Member_name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 88 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
               Write(Html.DisplayNameFor(model => model.house_no));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 91 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
               Write(Html.DisplayNameFor(model => model.Total_Amount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 94 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
               Write(Html.DisplayNameFor(model => model.Maintenance_date));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 99 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 103 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Member_name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
                   Write(Html.DisplayFor(modelItem => item.house_no));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 111 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Total_Amount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 115 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Maintenance_date));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cef4b1b4aa0f67578b6114bece75131ad7860810787", async() => {
                    WriteLiteral("Details");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
                                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 123 "C:\Asp.Net Project\SocietyManagementSystem\Views\Maintenance\PayMaintenance.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SocietyManagementSystem.Models.Maintenance>> Html { get; private set; }
    }
}
#pragma warning restore 1591
