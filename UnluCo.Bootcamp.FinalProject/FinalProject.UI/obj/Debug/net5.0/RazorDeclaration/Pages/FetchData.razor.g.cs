// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FinalProject.UI.Pages
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
#nullable restore
#line 3 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\FetchData.razor"
using FinalProject.UI.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
