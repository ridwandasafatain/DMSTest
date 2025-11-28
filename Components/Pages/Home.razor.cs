using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Blazored.Modal.Services;
using DMSTest.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace DMSTest.Components.Pages
{
    public class HomeBase : ComponentBase
    {
        [CascadingParameter]
        protected IModalService Modal { get; set; } = default!;

        [Inject]
        protected NavigationManager? Navigate { get; set; }

        [Inject]
        protected ProtectedSessionStorage SessionStorage { get; set; } = default!;

        protected List<string> Fields = new()
        {
            "No",
            "Nama",
            "Tempat Lahir",
            "Tanggal Lahir",
            "Jenis Kelamin",
            "Kode Pos",
            "Alamat",
            "Summary Bobot",
            "Result"
        };

        protected List<GeneralInformation> Records = new();

        protected string? SearchKeyword { get; set; }

        protected Dictionary<string, string>? SelectedRecord;

        protected override void OnInitialized()
        {
            
        }

        protected IEnumerable<GeneralInformation> GetFiltered()
        {
            if (string.IsNullOrWhiteSpace(SearchKeyword))
                return Records;

            var q = SearchKeyword.ToLower();
            return Records.Where(r => r.Nama.Contains(q, StringComparison.CurrentCultureIgnoreCase) == true);
        }

        protected string GetValue(GeneralInformation row, string field)
        {
            return field switch
            {
                "No" => row.ID.ToString(),
                "Nama" => row.Nama,
                "Tempat Lahir" => row.TempatLahir,
                "Tanggal Lahir" => row.TanggalLahir?.ToString("dd MMM yyyy") ?? "",
                "Jenis Kelamin" => row.JenisKelamin,
                "Kode Pos" => row.KodePos,
                "Alamat" => row.Alamat,
                "Summary Bobot" => row.SummaryBobot.ToString() ?? "",
                "Result" => row.Result?.ToString() ?? "",
                _ => ""
            };
        }

        protected async Task AddRecord()
        {
            var options = new ModalOptions() { AnimationType = ModalAnimationType.FadeInOut, Size = ModalSize.ExtraLarge, DisableBackgroundCancel = true };
            var formModal = Modal.Show<PopUp>("Add Data", options);
            var ret = await formModal.Result;
            if (!ret.Cancelled)
            {
                var protectedDataList = await SessionStorage!.GetAsync<List<GeneralInformation>>("DataList");
                if (protectedDataList.Success)
                {
                    Records = protectedDataList.Value!;
                    StateHasChanged();
                }
            }
        }

        protected async Task ViewRecord(GeneralInformation r)
        {
            var options = new ModalOptions() { AnimationType = ModalAnimationType.FadeInOut, Size = ModalSize.ExtraLarge, DisableBackgroundCancel = true, HideCloseButton = true };
            var parameters = new ModalParameters
            {                
                { "DataParam", r},
                { "IsView", true }
            };
            var formModal = Modal.Show<PopUp>("View Data", parameters, options);
            var ret = await formModal.Result;
            if (!ret.Cancelled)
            {
                var protectedDataList = await SessionStorage!.GetAsync<List<GeneralInformation>>("DataList");
                if (protectedDataList.Success)
                {
                    Records = protectedDataList.Value!;
                    StateHasChanged();
                }
            }
        }
    }
}
