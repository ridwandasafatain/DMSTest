namespace DMSTest.Model
{
    public class Data
    {
        public int ID { get; set; }
        public string Item { get; set; } = string.Empty;
        public decimal Bobot { get; set; }
        public decimal BobotMaster { get; set; }

        public List<Data> GetData()
        {
            return new List<Data>();
        }

        public List<Data> JenisKelaminList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Laki - Laki" },
                new Data { ID = 2, Item = "Perempuan" }
            };
        }

        public List<Data> UmurPemohonList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "56 - 65 Tahun", Bobot = 25, BobotMaster = 30 },
            new Data { ID = 2, Item = "21 - 30 Tahun", Bobot = 50, BobotMaster = 30 },
            new Data { ID = 3, Item = "31 - 45 Tahun", Bobot = 100, BobotMaster = 30 },
            new Data { ID = 4, Item = "46 - 55 Tahun", Bobot = 75, BobotMaster = 30 }
        };
        }

        public List<Data> UmurPlusTenorList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "Diatas Ketentuan", Bobot = 25, BobotMaster = 10 },
            new Data { ID = 2, Item = "Dibawah Ketentuan", Bobot = 100, BobotMaster = 10 }
        };
        }

        public List<Data> StatusPerkawinanList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "Belum Kawin dengan > 2 tanggungan", Bobot = 25, BobotMaster = 40},
            new Data { ID = 2, Item = "Belum Kawin dengan <= 2 tanggungan", Bobot = 45, BobotMaster = 40 },
            new Data { ID = 3, Item = "Belum Kawin dengan 0 tanggungan", Bobot = 65, BobotMaster = 40 },
            new Data { ID = 4, Item = "Kawin dengan > 2 tanggungan", Bobot = 85, BobotMaster = 40 },
            new Data { ID = 5, Item = "Kawin dengan <= 2 tanggungan", Bobot = 100, BobotMaster = 40 }
        };
        }

        public List<Data> PendidikanList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "SMA atau dibawahnya", Bobot = 25, BobotMaster = 20 },
            new Data { ID = 2, Item = "D1, D2, D3, D4", Bobot = 50, BobotMaster = 20 },
            new Data { ID = 3, Item = "S1", Bobot = 75, BobotMaster = 20 },
            new Data { ID = 4, Item = "Master atau diatasnya (S2, S3)", Bobot = 100, BobotMaster = 20 }
        };
        }

        public List<Data> AlamatList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "Tidak sesuai dengan data Bank", Bobot = 25, BobotMaster = 40 },
            new Data { ID = 2, Item = "Sesuai dengan data Bank", Bobot = 100, BobotMaster = 40 }
        };
        }

        public List<Data> KepemilikanAlamatList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "Lain-lain", Bobot = 25, BobotMaster = 30 },
            new Data { ID = 2, Item = "Sewa / Kontrak", Bobot = 50, BobotMaster = 30 },
            new Data { ID = 3, Item = "Milik sendiri masih diangsur", Bobot = 75, BobotMaster = 30 },
            new Data { ID = 4, Item = "Milik sendiri", Bobot = 100, BobotMaster = 30 }
        };
        }

        public List<Data> LamaMenempatiAlamatList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "<= 2 tahun", Bobot = 25, BobotMaster = 30 },
            new Data { ID = 2, Item = "> 2 - 5 tahun", Bobot = 50, BobotMaster = 30},
            new Data { ID = 3, Item = "> 5 - 8 tahun", Bobot = 75, BobotMaster = 30 },
            new Data { ID = 4, Item = "> 8 tahun", Bobot = 100, BobotMaster = 30 }
        };
        }

        public List<Data> KategoriPerusahaanList()
        {
            return new List<Data> {
            new Data { ID = 1, Item = "Lembaga Departemen", Bobot = 100, BobotMaster = 20 },
            new Data { ID = 2, Item = "BUMD", Bobot = 25, BobotMaster = 20 },
            new Data { ID = 3, Item = "SWASTA tidak punya rating", Bobot = 100, BobotMaster = 20 },
            new Data { ID = 4, Item = "SWASTA dengan rating", Bobot = 25, BobotMaster = 20 },
            new Data { ID = 5, Item = "SWASTA Kategori I", Bobot = 75, BobotMaster = 20 },
            new Data { ID = 6, Item = "SWASTA Kategori II", Bobot = 50, BobotMaster = 20 },
            new Data { ID = 7, Item = "SWASTA Kategori III", Bobot = 0, BobotMaster = 20 }
        };
        }

        public List<Data> JabatanList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Staff", Bobot = 25, BobotMaster = 20 },
                new Data { ID = 2, Item = "Direktur", Bobot = 75, BobotMaster = 20 },
                new Data { ID = 3, Item = "Komisaris", Bobot = 100, BobotMaster = 20 }
            };
        }

        public List<Data> LamaBekerjaList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "<= 2 tahun", Bobot = 0, BobotMaster = 20 },
                new Data { ID = 2, Item = "> 2 - 5 tahun", Bobot = 25, BobotMaster = 20 },
                new Data { ID = 3, Item = "> 5 - 10 tahun", Bobot = 75, BobotMaster = 20 },
                new Data { ID = 4, Item = "> 10 tahun", Bobot = 100, BobotMaster = 20 }
            };
        }

        public List<Data> PendapatanList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "<= Rp 10 juta", Bobot = 25, BobotMaster = 40 },
                new Data { ID = 2, Item = "> Rp 10 - Rp 25 juta", Bobot = 50, BobotMaster = 40 },
                new Data { ID = 3, Item = "> Rp 25 - Rp 50 juta", Bobot = 75, BobotMaster = 40 },
                new Data { ID = 4, Item = "> Rp 50 juta", Bobot = 100, BobotMaster = 40 }
            };
        }

        public List<Data> RekeningList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Tidak ada", Bobot = 25, BobotMaster = 10 },
                new Data { ID = 2, Item = "Tabungan", Bobot = 50, BobotMaster = 10 },
                new Data { ID = 3, Item = "Giro", Bobot = 75, BobotMaster = 10 },
                new Data { ID = 4, Item = "Tabungan/Giro + Deposito", Bobot = 100, BobotMaster = 10 }
            };
        }

        public List<Data> AverageSaldoList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "<= Rp 10 juta", Bobot = 25, BobotMaster = 15 },
                new Data { ID = 2, Item = "Rp 10 - Rp 25 juta", Bobot = 50, BobotMaster = 15 },
                new Data { ID = 3, Item = "Rp 25 - Rp 50 juta", Bobot = 75, BobotMaster = 15 },
                new Data { ID = 4, Item = "> Rp 50 juta", Bobot = 100, BobotMaster = 15 }
            };
        }

        public List<Data> TrackRecordAngsuranList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Peminjam baru", Bobot = 25, BobotMaster = 15 },
                new Data { ID = 2, Item = "Angsuran terlambat tapi lancar", Bobot = 50, BobotMaster = 15 },
                new Data { ID = 3, Item = "Angsuran tepat waktu", Bobot = 100, BobotMaster = 15 }
            };
        }

        public List<Data> TrackSLIKList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Kolektibilitas 3 sd 5", Bobot = 0, BobotMaster = 40 },
                new Data { ID = 2, Item = "Ada tunggakan < 3 bulan", Bobot = 50, BobotMaster = 40 },
                new Data { ID = 3, Item = "Tidak ada fasilitas", Bobot = 75, BobotMaster = 40 },
                new Data { ID = 4, Item = "Lancar", Bobot = 100, BobotMaster = 40 }
            };
        }

        public List<Data> KartuKreditList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Tidak Ada", Bobot = 25, BobotMaster = 20 },
                new Data { ID = 2, Item = "Basic", Bobot = 50, BobotMaster = 20 },
                new Data { ID = 3, Item = "Gold", Bobot = 75, BobotMaster = 20 },
                new Data { ID = 4, Item = "Platinum atau diatasnya", Bobot = 100, BobotMaster = 20 }
            };
        }

        public List<Data> TenorList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "> 15 Tahun", Bobot = 25, BobotMaster = 25 },
                new Data { ID = 2, Item = "> 10 - 15 Tahun", Bobot = 50, BobotMaster = 25 },
                new Data { ID = 3, Item = "> 5 - 10 Tahun", Bobot = 75, BobotMaster = 25},
                new Data { ID = 4, Item = "<= 5 Tahun", Bobot = 100, BobotMaster = 25 }
            };
        }

        public List<Data> DebtServiceRatioList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "> 50%", Bobot = 0, BobotMaster = 75 },
                new Data { ID = 2, Item = "> 40 - 50%", Bobot = 50, BobotMaster = 75 },
                new Data { ID = 3, Item = "> 30 - 40%", Bobot = 75, BobotMaster = 75 },
                new Data { ID = 4, Item = "<= 30%", Bobot = 100, BobotMaster = 75 }
            };
        }

        public List<Data> HasilAppraisalList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Tidak Direkomendasikan", Bobot = 0, BobotMaster = 10 },
                new Data { ID = 2, Item = "Marketable", Bobot = 100, BobotMaster = 10 }
            };
        }

        public List<Data> LuasBangunanList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "> 200 M2", Bobot = 25, BobotMaster = 20 },
                new Data { ID = 2, Item = "> 100 - 200 M2", Bobot = 50, BobotMaster = 20 },
                new Data { ID = 3, Item = "> 45 - 100 M2", Bobot = 75, BobotMaster = 20 },
                new Data { ID = 4, Item = "<= 45 M2", Bobot = 100, BobotMaster = 20 }
            };
        }

        public List<Data> TujuanPembiayaanList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "Lain-Lain", Bobot = 25, BobotMaster = 10 },
                new Data { ID = 2, Item = "Disewakan/Investasi", Bobot = 50, BobotMaster = 10 },
                new Data { ID = 3, Item = "Renovasi", Bobot = 75, BobotMaster = 10 },
                new Data { ID = 4, Item = "Pertama & Ditempati Sendiri", Bobot = 100, BobotMaster = 10 }
            };
        }

        public List<Data> LTVList()
        {
            return new List<Data> {
                new Data { ID = 1, Item = "LTV > 90%", Bobot = 25, BobotMaster = 60 },
                new Data { ID = 2, Item = "LTV > 80%", Bobot = 50, BobotMaster = 60 },
                new Data { ID = 3, Item = "LTV > 70%", Bobot = 75, BobotMaster = 60 },
                new Data { ID = 4, Item = "LTV <= 70%", Bobot = 100, BobotMaster = 60 },
                new Data { ID = 5, Item = "LTV > 100%", Bobot = 0, BobotMaster = 60 }
            };
        }

    }

}
