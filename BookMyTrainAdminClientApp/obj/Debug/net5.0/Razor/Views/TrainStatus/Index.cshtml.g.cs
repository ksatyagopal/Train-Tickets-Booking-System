#pragma checksum "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75e5115107a9cbea121e731e3d0f4e486ba5ab58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TrainStatus_Index), @"mvc.1.0.view", @"/Views/TrainStatus/Index.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\_ViewImports.cshtml"
using BookMyTrainAdminClientApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\_ViewImports.cshtml"
using BookMyTrainAdminClientApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75e5115107a9cbea121e731e3d0f4e486ba5ab58", @"/Views/TrainStatus/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd0e56edc804897a909ee1a336c64baee578886d", @"/Views/_ViewImports.cshtml")]
    public class Views_TrainStatus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookMyTrainAdminClientApp.Models.TrainStatus>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<div class=\"d-flex justify-content-between\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75e5115107a9cbea121e731e3d0f4e486ba5ab584848", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75e5115107a9cbea121e731e3d0f4e486ba5ab586011", async() => {
                WriteLiteral("Back to Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Doj));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TrainNumberNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AcSeats1Booked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AcSeats2Booked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AcSeats3Booked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SlSeatsBooked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SsSeatsBooked));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 42 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TrainNumberNavigation.TrainNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Doj));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(item.AcSeats1Booked);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 51 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
                                  Write(item.AcSeats1Available);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(item.AcSeats2Booked);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 54 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
                                  Write(item.AcSeats2Available);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(item.AcSeats3Booked);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 57 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
                                  Write(item.AcSeats3Available);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(item.SlSeatsBooked);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 60 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
                                 Write(item.SlSeatsAvailable);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
           Write(item.SsSeatsBooked);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
                                 Write(item.SsSeatsAvailable);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75e5115107a9cbea121e731e3d0f4e486ba5ab5814339", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
                                          WriteLiteral(item.tsId);

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
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\Admin\Desktop\Eurofins\WebApps\TrainTicketsBookingSystem\BookMyTrainAdminClientApp\Views\TrainStatus\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookMyTrainAdminClientApp.Models.TrainStatus>> Html { get; private set; }
    }
}
#pragma warning restore 1591
