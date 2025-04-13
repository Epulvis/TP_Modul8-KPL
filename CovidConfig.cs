using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103022300057
{
    public class CovidConfig
    {
        private const string ConfigFilePath = "covid_config.json";

        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDemam { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                var json = File.ReadAllText(ConfigFilePath);
                var config = JsonSerializer.Deserialize<CovidConfig>(json);
                SatuanSuhu = config.SatuanSuhu;
                BatasHariDemam = config.BatasHariDemam;
                PesanDitolak = config.PesanDitolak;
                PesanDiterima = config.PesanDiterima;
            }
            else
            {
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFilePath, json);
        }

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }

}