using Microsoft.AspNetCore.Components;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.Modal;
using DMSTest.Model;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace DMSTest.Components.Pages
{
    public class PopUpBase : ComponentBase
    {
        [Parameter]
        public GeneralInformation? DataParam { get; set; }

        [Parameter]
        public bool IsView { get; set; } = false;

        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; } = default!;

        [Inject]
        protected NavigationManager? Navigation { get; set; }

        [Inject]
        protected SweetAlertService SweetAlert { get; set; } = default!;

        [Inject]
        protected ProtectedSessionStorage SessionStorage { get; set; } = default!;

        protected GeneralInformation generalInformation { get; set; } = new();
        protected Data data { get; set; } = new();
        protected List<Data> jenisKelaminList { get; set; } = new();

        protected override void OnInitialized()
        {
            if(DataParam != null)
            {
                generalInformation = DataParam;
            }
        }
        
        protected async Task TanggalLahirChange()
        {
            generalInformation.Umur = HitungUmur(generalInformation.TanggalLahir!.Value);
            if (generalInformation.Umur >= 56 && generalInformation.Umur <= 65) generalInformation.UmurID = 1;
            else if (generalInformation.Umur >= 21 && generalInformation.Umur <= 30) generalInformation.UmurID = 2;
            else if (generalInformation.Umur >= 31 && generalInformation.Umur <= 45) generalInformation.UmurID = 3;
            else if (generalInformation.Umur >= 46 && generalInformation.Umur <= 55) generalInformation.UmurID = 4;
            else if(generalInformation.Umur > 65)
            {
                await SweetAlert.FireAsync(new SweetAlertOptions { Icon = SweetAlertIcon.Warning, Title = "Warning", Text = "Umur Pemohon maksimal 65 tahun." });
                generalInformation.Umur = 0;
                generalInformation.TanggalLahir = null;
            }
            else if(generalInformation.Umur < 21)
            {
                await SweetAlert.FireAsync(new SweetAlertOptions { Icon = SweetAlertIcon.Warning, Title = "Warning", Text = "Umur Pemohon minimal 21 tahun." });
                generalInformation.Umur = 0;
                generalInformation.TanggalLahir = null;
            }

            StateHasChanged();
        }

        protected async Task Submit()
        {
            if (Validate(generalInformation))
            {
                var dataList = new List<GeneralInformation>();
                var protectedDataList = await SessionStorage!.GetAsync<List<GeneralInformation>>("DataList");
                if (protectedDataList.Success)
                {
                    if(protectedDataList.Value!.Where(a => a.Nama.Trim() == generalInformation.Nama.Trim() && a.ID != generalInformation.ID).Count() > 0)
                    {
                        await SweetAlert.FireAsync(new SweetAlertOptions { Icon = SweetAlertIcon.Error, Title = "Error", Text = "Nama sudah ada. Silahkan masukkan nama lain." });
                        return;
                    }
                    if(DataParam == null)
                    {
                        generalInformation.ID = protectedDataList.Value!.Count + 1;
                    }
                    dataList.AddRange(protectedDataList.Value!);
                }
                else
                {
                    generalInformation.ID = 1;
                }

                HitungBobot();
                
                if(DataParam == null)
                {
                    dataList.Add(generalInformation);
                }
                else
                {
                    var index = dataList.FindIndex(x => x.ID == generalInformation.ID);

                    if (index >= 0)
                    {
                        dataList[index] = generalInformation;
                    }
                }

                await SessionStorage!.SetAsync("DataList", dataList);
                await ModalInstance.CloseAsync(ModalResult.Ok());
            }
            else
            {
                await SweetAlert.FireAsync(new SweetAlertOptions { Icon = SweetAlertIcon.Warning, Title = "Warning", Text = "Data tidak valid. Semua informasi harus terisi." });
            }
        }

        private decimal HitungUmur(DateTime tanggalLahir)
        {
            var today = DateTime.Today;

            int tahun = today.Year - tanggalLahir.Year;
            int bulan = today.Month - tanggalLahir.Month;

            if (today.Day < tanggalLahir.Day)
            {
                bulan--;
            }

            if (bulan < 0)
            {
                tahun--;
                bulan += 12;
            }

            decimal umurDecimal = tahun + (bulan / 12m);
            return Math.Round(umurDecimal, 2);
        }

        private bool Validate(GeneralInformation data)
        {
            if (data == null)
                return false;

            if (string.IsNullOrWhiteSpace(data.Nama)) return false;
            if (string.IsNullOrWhiteSpace(data.TempatLahir)) return false;
            if (string.IsNullOrWhiteSpace(data.JenisKelamin)) return false;
            if (string.IsNullOrWhiteSpace(data.KodePos)) return false;
            if (string.IsNullOrWhiteSpace(data.Alamat)) return false;

            if (data.TanggalLahir == null) return false;
            if (data.Umur <= 0) return false;

            var intProperties = typeof(GeneralInformation).GetProperties().Where(p => p.PropertyType == typeof(int));
            foreach (var prop in intProperties)
            {
                int value = (int)prop.GetValue(data)!;
                if (value <= 0 && prop.Name != "ID")
                {
                    return false;
                }
            }

            return true;
        }

        private void HitungBobot()
        {
            generalInformation.SummaryBobot = -1;
            generalInformation.Result = "Not Valid";

            //Informasi 1
            var umurPemohon = data.UmurPemohonList().Where(a => a.ID == generalInformation.UmurID).First();
            var umurPemohonPlusTenor = data.UmurPlusTenorList().Where(a => a.ID == generalInformation.UmurPlusTenorID).First();
            var statusPerkawinan = data.StatusPerkawinanList().Where(a => a.ID == generalInformation.StatusPerkawinanID).First();
            var pendidikan = data.PendidikanList().Where(a => a.ID == generalInformation.PendidikanID).First();

            var bobot1 = ((umurPemohon.Bobot * umurPemohon.BobotMaster / 100)
                        + (umurPemohonPlusTenor.Bobot * umurPemohonPlusTenor.BobotMaster / 100)
                        + (statusPerkawinan.Bobot * statusPerkawinan.BobotMaster / 100)
                        + (pendidikan.Bobot * pendidikan.BobotMaster / 100)) * 5 / 100;

            //Informasi 2
            var alamat = data.AlamatList().Where(a => a.ID == generalInformation.AlamatID).First();
            var kepemilikanAlamat = data.KepemilikanAlamatList().Where(a => a.ID == generalInformation.KepemilikanAlamatID).First();
            var lamaMenempatiAlamat = data.LamaMenempatiAlamatList().Where(a => a.ID == generalInformation.LamaMenempatiAlamatID).First();    
            
            var bobot2 = ((alamat.Bobot * alamat.BobotMaster / 100)
                        + (kepemilikanAlamat.Bobot * kepemilikanAlamat.BobotMaster / 100)
                        + (lamaMenempatiAlamat.Bobot * lamaMenempatiAlamat.BobotMaster / 100)) * 5 / 100;

            //Informasi 3
            var kategoriPerusahaan = data.KategoriPerusahaanList().Where(a => a.ID == generalInformation.KategoriPerusahaanID).First();
            var jabatan = data.JabatanList().Where(a => a.ID == generalInformation.JabatanID).First();
            var lamaBekerja = data.LamaBekerjaList().Where(a => a.ID == generalInformation.LamaBekerjaID).First();
            var pendapatan = data.PendapatanList().Where(a => a.ID == generalInformation.PendapatanID).First();

            var bobot3 = ((kategoriPerusahaan.Bobot * kategoriPerusahaan.BobotMaster / 100)
                        + (jabatan.Bobot * jabatan.BobotMaster / 100)
                        + (lamaBekerja.Bobot * lamaBekerja.BobotMaster / 100)
                        + (pendapatan.Bobot * pendapatan.BobotMaster / 100)) * 20 / 100;

            //Informasi 4
            var rekening = data.RekeningList().Where(a => a.ID == generalInformation.RekeningID).First();
            var averageSaldo = data.AverageSaldoList().Where(a => a.ID == generalInformation.AverageSaldoID).First();
            var trackRecordAngsuran = data.TrackRecordAngsuranList().Where(a => a.ID == generalInformation.TrackRecordAngsuranID).First();
            var trackSLIK = data.TrackSLIKList().Where(a => a.ID == generalInformation.TrackSLIKID).First();
            var kartuKredit = data.KartuKreditList().Where(a => a.ID == generalInformation.KartuKreditID).First();

            var bobot4 = ((rekening.Bobot * rekening.BobotMaster / 100)
                        + (averageSaldo.Bobot * averageSaldo.BobotMaster / 100)
                        + (trackRecordAngsuran.Bobot * trackRecordAngsuran.BobotMaster / 100)
                        + (trackSLIK.Bobot * trackSLIK.BobotMaster / 100)
                        + (kartuKredit.Bobot * kartuKredit.BobotMaster / 100)) * 15 / 100;

            //Informasi 5
            var tenor = data.TenorList().Where(a => a.ID == generalInformation.TenorID).First();
            var debtServiceRatio = data.DebtServiceRatioList().Where(a => a.ID == generalInformation.DebtServiceRatioID).First();

            var bobot5 = ((tenor.Bobot * tenor.BobotMaster / 100)
                        + (debtServiceRatio.Bobot * debtServiceRatio.BobotMaster / 100)) * 30 / 100;

            //Informasi 6
            var hasilAppraisal = data.HasilAppraisalList().Where(a => a.ID == generalInformation.HasilAppraisalID).First();
            var luasBangunan = data.LuasBangunanList().Where(a => a.ID == generalInformation.LuasBangunanID).First();
            var tujuanPembiayaan = data.TujuanPembiayaanList().Where(a => a.ID == generalInformation.TujuanPembiayaanID).First();
            var LTV = data.LTVList().Where(a => a.ID == generalInformation.LTVID).First();

            var bobot6 = ((hasilAppraisal.Bobot * hasilAppraisal.BobotMaster / 100)
                        + (luasBangunan.Bobot * luasBangunan.BobotMaster / 100)
                        + (tujuanPembiayaan.Bobot * tujuanPembiayaan.BobotMaster / 100)
                        + (LTV.Bobot * LTV.BobotMaster / 100)) * 25 / 100;

            generalInformation.SummaryBobot = bobot1 + bobot2 + bobot3 + bobot4 + bobot5 + bobot6;
            generalInformation.Result = ResultBobot(generalInformation.SummaryBobot);
        }

        private string ResultBobot(decimal summaryBobot)
        {
            if (summaryBobot > 70) return "LOW RISK";
            else if (summaryBobot >= 56 && summaryBobot <= 70) return "MEDIUM RISK";
            else if (summaryBobot <= 55) return "HIGH RISK";
            else return "NOT VALID";
        }
    }
}
