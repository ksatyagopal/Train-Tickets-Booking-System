#pragma checksum "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4eb3c4b20beedfa75d42f9b9a1abb14eb4e63c0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserAccount_ListTransactions), @"mvc.1.0.view", @"/Views/UserAccount/ListTransactions.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\_ViewImports.cshtml"
using DigitalBankWebAppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\_ViewImports.cshtml"
using DigitalBankWebAppMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4eb3c4b20beedfa75d42f9b9a1abb14eb4e63c0a", @"/Views/UserAccount/ListTransactions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8385a4855ecf422bc1530d781ba874b8d270acda", @"/Views/_ViewImports.cshtml")]
    public class Views_UserAccount_ListTransactions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DigitalBankWebAppMVC.Models.Transaction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Transactions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:500px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nolist.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("No Transactions"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
  
    ViewData["Title"] = "ListTransactions";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-right\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4eb3c4b20beedfa75d42f9b9a1abb14eb4e63c0a6540", async() => {
                WriteLiteral("Back to Menu");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<br />\r\n\r\n");
#nullable restore
#line 14 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
 if (ViewBag.TransactionCount != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Transactions List</h1>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayNameFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayNameFor(model => model.TransactionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 28 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayNameFor(model => model.FromAccountNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 31 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayNameFor(model => model.ToAccountNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 34 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayNameFor(model => model.TransactionAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 37 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayNameFor(model => model.TransactionReason));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
             foreach (Transaction item in ViewBag.allTransactions)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.FromAccountNavigation.AccHolderName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <b>");
#nullable restore
#line 54 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                  Write(item.FromAccount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.ToAccountNavigation.AccHolderName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <b>");
#nullable restore
#line 58 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                  Write(item.ToAccount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                </td>\r\n");
#nullable restore
#line 60 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                 if (item.FromAccount.ToString() == httpaccesor.HttpContext.Session.GetString("useraccountnumber"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"color:red\">\r\n                        -");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                    Write(Html.DisplayFor(modelItem => item.TransactionAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td style=\"color:green\">\r\n                        +");
#nullable restore
#line 69 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                    Write(Html.DisplayFor(modelItem => item.TransactionAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 71 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 73 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionReason));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4eb3c4b20beedfa75d42f9b9a1abb14eb4e63c0a15040", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
                                                                                              WriteLiteral(item.TransactionId);

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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 79 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 83 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1>No Transactions Made</h1>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4eb3c4b20beedfa75d42f9b9a1abb14eb4e63c0a18194", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 90 "C:\Users\Admin\Desktop\Eurofins\WebApps\DigitalBankWebAppMVC\Views\UserAccount\ListTransactions.cshtml"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor httpaccesor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DigitalBankWebAppMVC.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591