#pragma checksum "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Account\ForgotPassword.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8089adde75dd3abe58586962e6b9ddacfd40a21f"
// <auto-generated/>
#pragma warning disable 1591
namespace FinalProject.UI.Pages.Account
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
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\_Imports.razor"
using FinalProject.UI.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/accounts/forgotpassword")]
    public partial class ForgotPassword : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-sm-6 mx-auto");
            __builder.AddMarkupContent(2, "<h3 class=\"text-center\">\r\n        Şifremi Unuttum\r\n    </h3>\r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 9 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Account\ForgotPassword.razor"
                      forgotPasswordModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 9 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Account\ForgotPassword.razor"
                                                           Submit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n\r\n        ");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "mb-3");
                __builder2.AddMarkupContent(11, "<label for=\"email\" class=\"col-form-label\">Mail Adresi</label>\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(12);
                __builder2.AddAttribute(13, "id", "email");
                __builder2.AddAttribute(14, "class", "form-control");
                __builder2.AddAttribute(15, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Account\ForgotPassword.razor"
                                               forgotPasswordModel.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => forgotPasswordModel.Email = __value, forgotPasswordModel.Email))));
                __builder2.AddAttribute(17, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => forgotPasswordModel.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(18, "\r\n            ");
                __Blazor.FinalProject.UI.Pages.Account.ForgotPassword.TypeInference.CreateValidationMessage_0(__builder2, 19, 20, 
#nullable restore
#line 15 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Account\ForgotPassword.razor"
                                    () => forgotPasswordModel.Email

#line default
#line hidden
#nullable disable
                , 21, "invalid-feedback");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(22, "\r\n       \r\n        ");
                __builder2.AddMarkupContent(23, "<button type=\"submit\" class=\"btn btn-primary\">Yeni Şifre Talebi</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "C:\Users\o_nea\source\repos\Patika-dev-Unlu-Co-Net-Bootcamp\MesutEnsarErenoglu.FinalProject\UnluCo.Bootcamp.FinalProject\FinalProject.UI\Pages\Account\ForgotPassword.razor"
       

    public ForgotPasswordModel forgotPasswordModel = new ForgotPasswordModel();

    private async Task Submit()
    {
        forgotPasswordModel.URL = "https://localhost:44355/accounts/changepassword/";
        var result = await accountService.ForgotPassword(forgotPasswordModel);

        if (result)
        {

            navManager.NavigateTo("/");
        }
        navManager.NavigateTo("/error");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountClientService accountService { get; set; }
    }
}
namespace __Blazor.FinalProject.UI.Pages.Account.ForgotPassword
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0, int __seq1, System.Object __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
