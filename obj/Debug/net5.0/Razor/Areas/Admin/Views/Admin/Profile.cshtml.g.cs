#pragma checksum "C:\Users\Caner INALI\source\repos\ProductPromotion\ProductPromotion\Areas\Admin\Views\Admin\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3e5d03a5fefdc42f67b46dbbdc99d0866038445"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_Profile), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/Profile.cshtml")]
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
#line 1 "C:\Users\Caner INALI\source\repos\ProductPromotion\ProductPromotion\Areas\Admin\Views\_ViewImports.cshtml"
using ProductPromotion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Caner INALI\source\repos\ProductPromotion\ProductPromotion\Areas\Admin\Views\_ViewImports.cshtml"
using ProductPromotion.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Caner INALI\source\repos\ProductPromotion\ProductPromotion\Areas\Admin\Views\_ViewImports.cshtml"
using Entities.Abstract;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Caner INALI\source\repos\ProductPromotion\ProductPromotion\Areas\Admin\Views\_ViewImports.cshtml"
using Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3e5d03a5fefdc42f67b46dbbdc99d0866038445", @"/Areas/Admin/Views/Admin/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c871feaa6c6e7ad619b5603d1dc05e0393c84b32", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Admin_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disabled", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""content"">
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""card card-primary"">
                <div class=""card-header"">
                    <h3 class=""card-title"">General</h3>
                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    <div class=""form-group"">
                        <label for=""inputName"">Project Name</label>
                        <input type=""text"" id=""inputName"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <label for=""inputDescription"">Project Description</label>
                        <textarea id=""inputDescription"" class=""form-control"" rows=""4""></textarea>");
            WriteLiteral("\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"inputStatus\">Status</label>\r\n                        <select id=\"inputStatus\" class=\"form-control custom-select\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e5d03a5fefdc42f67b46dbbdc99d08660384455742", async() => {
                WriteLiteral("Select one");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e5d03a5fefdc42f67b46dbbdc99d08660384456898", async() => {
                WriteLiteral("On Hold");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e5d03a5fefdc42f67b46dbbdc99d08660384457885", async() => {
                WriteLiteral("Canceled");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e5d03a5fefdc42f67b46dbbdc99d08660384458873", async() => {
                WriteLiteral("Success");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""form-group"">
                        <label for=""inputClientCompany"">Client Company</label>
                        <input type=""text"" id=""inputClientCompany"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <label for=""inputProjectLeader"">Project Leader</label>
                        <input type=""text"" id=""inputProjectLeader"" class=""form-control"">
                    </div>
                </div>

            </div>

        </div>
        <div class=""col-md-6"">
            <div class=""card card-secondary collapsed-card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Budget</h3>
                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" title=""Collapse"">
                            <i class=""fas fa-plus""></i");
            WriteLiteral(@">
                        </button>
                    </div>
                </div>
                <div class=""card-body"" style=""display: none;"">
                    <div class=""form-group"">
                        <label for=""inputEstimatedBudget"">Estimated budget</label>
                        <input type=""number"" id=""inputEstimatedBudget"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <label for=""inputSpentBudget"">Total amount spent</label>
                        <input type=""number"" id=""inputSpentBudget"" class=""form-control"">
                    </div>
                    <div class=""form-group"">
                        <label for=""inputEstimatedDuration"">Estimated project duration</label>
                        <input type=""number"" id=""inputEstimatedDuration"" class=""form-control"">
                    </div>
                </div>

            </div>

        </div>
    </div>
    <div class=""row"">
       ");
            WriteLiteral(" <div class=\"col-12\">\r\n            <a href=\"#\" class=\"btn btn-secondary\">Cancel</a>\r\n            <input type=\"submit\" value=\"Create new Project\" class=\"btn btn-success float-right\">\r\n        </div>\r\n    </div>\r\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
