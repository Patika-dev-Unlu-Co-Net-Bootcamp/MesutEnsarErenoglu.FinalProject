#pragma checksum "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Shared\SurveyPrompt.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f01c4bf6fd50a6ff8be4e263c88b9e02d6a9b9b7"
// <auto-generated/>
#pragma warning disable 1591
namespace FinalProject.UI.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.Application.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using System.Text.Json.Serialization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.WebApi.Models.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.Application.Token;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI.Pages.SubCategory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.WebApi.Models.Product;

#line default
#line hidden
#nullable disable
    public partial class SurveyPrompt : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "alert alert-secondary mt-4");
            __builder.AddAttribute(2, "role", "alert");
            __builder.AddMarkupContent(3, "<span class=\"oi oi-pencil mr-2\" aria-hidden=\"true\"></span>\r\n    ");
            __builder.OpenElement(4, "strong");
            __builder.AddContent(5, 
#nullable restore
#line 3 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Shared\SurveyPrompt.razor"
             Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n\r\n    ");
            __builder.AddMarkupContent(7, "<span class=\"text-nowrap\">\r\n        Please take our\r\n        <a target=\"_blank\" class=\"font-weight-bold\" href=\"https://go.microsoft.com/fwlink/?linkid=2137813\">brief survey</a></span>\r\n    and tell us what you think.\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Shared\SurveyPrompt.razor"
       
    // Demonstrates how a parent component can supply parameters
    [Parameter]
    public string Title { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
