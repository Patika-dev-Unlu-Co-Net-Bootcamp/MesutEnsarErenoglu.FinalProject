#pragma checksum "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "552f72439c690f570326d971f4bbf3fab1412a7e"
// <auto-generated/>
#pragma warning disable 1591
namespace FinalProject.UI.Pages.Category
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/categories")]
    public partial class Categories : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Categories</h3>");
#nullable restore
#line 6 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
 if (getCategoryDtosError)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p>Unable to get Categories. Please try again later.</p>");
#nullable restore
#line 9 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
}
else if (categoryDtos == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p>");
#nullable restore
#line 13 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "ul");
#nullable restore
#line 17 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
         foreach (var item in categoryDtos)
        {
            

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "li");
            __builder.OpenElement(5, "a");
            __builder.AddAttribute(6, "href", "/category/" + (
#nullable restore
#line 20 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
                                    item.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenComponent<FinalProject.UI.Pages.Category.Category>(7);
            __builder.AddAttribute(8, "Id", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
                                                            item.Id.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 21 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 23 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Category\Categories.razor"
       
    private List<CategoryDto> categoryDtos;
    private bool shouldRender;
    private bool getCategoryDtosError;



    protected override bool ShouldRender() => shouldRender;

    protected override async Task OnInitializedAsync()
    {
        categoryDtos = await categoryService.GetAllActive();

        if (categoryDtos == null)
        {
            getCategoryDtosError = true;
        }

        shouldRender = true;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICategoryClientService categoryService { get; set; }
    }
}
#pragma warning restore 1591
