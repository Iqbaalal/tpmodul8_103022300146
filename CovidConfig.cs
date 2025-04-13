using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public CovidConfig() {
        satuan_suhu = "celcius";
        batas_hari_deman = 14;
        pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        LoadConfig();
    }

    public void LoadConfig() {
        string configPath = "covid_config.json";
        if (File.Exists(configPath)) {
            string configJson = File.ReadAllText(configPath);
            CovidConfig config = JsonSerializer.Deserialize<CovidConfig>(configJson);

            satuan_suhu = config.satuan_suhu;
            batas_hari_deman = config.batas_hari_deman;
            pesan_ditolak = config.pesan_ditolak;
            pesan_diterima = config.pesan_diterima;
        }
    }

    public void SaveConfig() {
        string configPath = "covid_config.json";
        string configJson = JsonSerializer.Serialize(this);
        File.WriteAllText(configPath, configJson);
    }

    public void UbahSatuan() {
        if (satuan_suhu == "celcius") {
            satuan_suhu = "fahrenheit";
        }else {
            satuan_suhu = "celcius";
        }
        SaveConfig();
    }
}