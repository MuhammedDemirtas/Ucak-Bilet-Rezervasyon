using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uçak_Rezervasyon
{
    internal class ReservationViewer
    {
        public static void ShowReservationsByTC(string tc)
        {
            string CSVKYT = "MüşteriKayit.csv";

            try
            {
                using (StreamReader sr = new StreamReader(CSVKYT, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');

                        // TC numarasını kontrol et
                        if (values.Length >= 3 && values[2].Trim() == tc)
                        {
                            Console.WriteLine("Rezervasyon Bilgileri:");
                            Console.WriteLine($"Ad: {values[0]}");
                            Console.WriteLine($"Soyad: {values[1]}");
                            Console.WriteLine($"TC: {values[2]}");
                            Console.WriteLine($"Telefon: {values[3]}");
                            Console.WriteLine($"Email: {values[4]}");
                            Console.WriteLine($"Koltuk Numarası: {values[5]}");
                            Console.WriteLine($"Rezervasyon Saati: {values[6]}");
                            Console.WriteLine($"Uçak: {values[7]}");
                            Console.WriteLine($"Ücret: {values[8]}₺");
                            Console.WriteLine($"kalkış: {values[9]}");
                            Console.WriteLine($"Varış: {values[10]}");
                            Console.WriteLine($"Gidiş Tarih: {values[11]}");
                            Console.WriteLine($"Dönüş Tarih: {values[12]}");

                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }

        }


    }


}
