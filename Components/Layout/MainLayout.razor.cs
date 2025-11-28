using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Radzen;
using Radzen.Blazor;

namespace DMSTest.Components.Layout
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        protected SweetAlertService? sweetAlert { get; set; }

        [Inject]
        protected NavigationManager? navigation { get; set; }

        [Inject]
        protected ProtectedSessionStorage? protectedSessionStorage { get; set; }

        [Inject]
        TooltipService? tooltipService { get; set; }

        protected RadzenBody? radzenBody { get; set; }
    }
}
