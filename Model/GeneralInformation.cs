namespace DMSTest.Model
{
    public class GeneralInformation
    {
        public int ID { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string TempatLahir { get; set; } = string.Empty;
        public DateTime? TanggalLahir { get; set; }
        public string JenisKelamin { get; set; } = string.Empty;
        public string KodePos { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public decimal SummaryBobot { get; set; }
        public string Result { get; set; } = string.Empty;

        //Informasi 1
        public decimal Umur { get; set; }
        public int UmurID { get; set; }
        public int UmurPlusTenorID { get; set; }
        public int StatusPerkawinanID { get; set; }
        public int PendidikanID { get; set; }

        //Informasi 2
        public int AlamatID { get; set; }
        public int KepemilikanAlamatID { get; set; }
        public int LamaMenempatiAlamatID { get; set; }

        //Informasi 3
        public int KategoriPerusahaanID { get; set; }
        public int JabatanID { get; set; }
        public int LamaBekerjaID { get; set; }
        public int PendapatanID { get; set; }

        //Informasi 4
        public int RekeningID { get; set; }
        public int AverageSaldoID { get; set; }
        public int TrackRecordAngsuranID { get; set; }
        public int TrackSLIKID { get; set; }
        public int KartuKreditID { get; set; }

        //Informasi 5
        public int TenorID { get; set; }
        public int DebtServiceRatioID { get; set; }

        //Informasi 6
        public int HasilAppraisalID { get; set; }
        public int LuasBangunanID { get; set; }
        public int TujuanPembiayaanID { get; set; }
        public int LTVID { get; set; }
    }
}
