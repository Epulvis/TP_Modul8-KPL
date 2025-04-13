using tpmodul8_103022300057;

internal class Program
{
    private static void Main(string[] args)
    {
        var config = new CovidConfig();    
        config.LoadConfig();
        config.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hari = int.Parse(Console.ReadLine());

        bool suhuNormal = false;

        if (config.SatuanSuhu == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.SatuanSuhu == "fahrenheit")
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariAman = hari < config.BatasHariDemam;

        if (suhuNormal && hariAman)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }
    }
}