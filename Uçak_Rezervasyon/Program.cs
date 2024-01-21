using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uçak_Rezervasyon;

internal class Program
{
    private static void Main(string[]args)
    {

        Console.ForegroundColor = ConsoleColor.Blue;

        Console.WriteLine("            |-|Uçak Rezervasyon Uygulamamıza Hoş Geldin|-|\n");
        Console.WriteLine("                      |-|Doğru Yerdesiniz|-|\n\n\n\n");

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("                  1 - Rezervasyon Görüntüle");
        Console.WriteLine("                  2 - Rezervasyon Sil");
        Console.WriteLine("                  3 - Yeni Rezervasyon Kayıt");
        Console.Write("                   İŞLEMİNİZ NEDİR ? 1 - 2 - 3 : ");

        string CSVKYT = "MüşteriKayit.csv";
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("> TC Numarasını Girin: ");
                string tcToSearch = Console.ReadLine();
               
                ReservationViewer.ShowReservationsByTC(tcToSearch);
                break;

            case "2":
                // Rezervasyon Sil
                Console.WriteLine("Rezervasyon Sil");

                // TC (Kimlik No) girilerek silinecek rezervasyonu belirle
                Console.Write("Lütfen TC (Kimlik No) Girin = ");
                string tcToDelete = Console.ReadLine();
                // CSV dosyasındaki mevcut rezervasyonları okuma
                List<string> linesToDelete = File.ReadAllLines(CSVKYT).ToList();

                // Belirtilen TC ile rezervasyonu bul ve listeden kaldır
                bool reservationToDeleteFound = false;
                for (int i = 0; i < linesToDelete.Count; i++)
                {
                    string[] fields = linesToDelete[i].Split(',');

                    if (fields.Length >= 3 && fields[2].Trim() == tcToDelete.Trim())
                    {
                        linesToDelete.RemoveAt(i);
                        reservationToDeleteFound = true;
                        break;
                    }
                }

                if (reservationToDeleteFound)
                {
                    // Rewrite the file after removing the reservation
                    File.WriteAllLines(CSVKYT, linesToDelete);
                    Console.WriteLine("Rezervasyon başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Belirtilen TC ile rezervasyon bulunamadı.");
                }

                break;

            case "3":
                // Yeni rezervasyon kayıt işlemi için gerekli kodları ekleyin
                Console.WriteLine("Yeni Rezervasyon Kayıt İşlemi");
                break;

            default:
                Console.WriteLine("Geçersiz işlem seçimi.");
                break;
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Write("> Lütfen Adınızı (Name's) Girin = ");
        string name = Console.ReadLine();

        // Adın boş olup olmadığını kontrol et
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Geçerli bir ad giriniz.");
            Console.Write("> Lütfen Adınızı (Name's) Girin = ");
            name = Console.ReadLine();
        }

        Console.Write("> Lütfen Soyadınızı (Surname's) Girin = ");
        string surname = Console.ReadLine();

        // Soyadın boş olup olmadığını kontrol et
        while (string.IsNullOrWhiteSpace(surname))
        {
            Console.WriteLine("Geçerli bir soyad giriniz.");
            Console.Write("> Lütfen Soyadınızı (Surname's) Girin = ");
            surname = Console.ReadLine();
        }

        Console.Write("> Lütfen KimlikNo (ID Card's) Girin = ");
        string ıdcard = Console.ReadLine();

        // Kimlik numarasının belirli bir uzunlukta olup olmadığını kontrol et
        while (string.IsNullOrWhiteSpace(ıdcard) || ıdcard.Length != 11)
        {
            Console.WriteLine("Geçerli bir kimlik numarası giriniz (11 karakter).");
            Console.Write("> Lütfen KimlikNo (ID Card's) Girin = ");
            ıdcard = Console.ReadLine();
        }

        Console.Write("> Lütfen Telefon Numaranızı (Phone Number's) Girin = ");
        string phoneno = Console.ReadLine();

        // Telefon numarasının belirli bir uzunlukta olup olmadığını kontrol et
        while (string.IsNullOrWhiteSpace(phoneno) || phoneno.Length != 10)
        {
            Console.WriteLine("Geçerli bir telefon numarası giriniz (10 karakter).");
            Console.Write("> Lütfen Telefon Numaranızı (Phone Number's) Girin = ");
            phoneno = Console.ReadLine();
        }

        Console.Write("> Lütfen E-posta Adresinizi (E-mail address's) Girin = ");
        string email = Console.ReadLine();

        // Geçerli bir e-posta adresi olup olmadığını kontrol et
        while (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
        {
            Console.WriteLine("Geçerli bir e-posta adresi giriniz.");
            Console.Write("> Lütfen E-posta Adresinizi (E-mail address's (@)) Girin = ");
            email = Console.ReadLine();
        }

        // Diğer gerekli kodları buraya ekleyin

        // IsValidEmail metodu, e-posta adresinin geçerli olup olmadığını kontrol eder
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        LocationManager locationManager = new LocationManager();
        Location[] locations = LocationManager.GetLocations();

        Console.WriteLine("\n|Şu An Aktif Olan Uçuş Ve Havalimanı Güzergahları| \n");

        Console.WriteLine("> Mevcut Uçuş Noktaları (Available Loactions's) = \n");
        for (int i = 0; i < locations.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {locations[i]}");
        }

        Location departure;
        Location destination;

        while (true)
        {
            Console.Write("\n> Lütfen Kalkış Noktası Numarasını (Departure Number's) Girin = ");
            int departureIndex = int.Parse(Console.ReadLine()) - 1;
            departure = locations[departureIndex];

            Console.Write("\n> Lütfen Varış Noktası Numarasını (Arrival Number's) Girin = ");
            int destinationIndex = int.Parse(Console.ReadLine()) - 1;
            destination = locations[destinationIndex];

            if (departureIndex != destinationIndex)
            {
                break;
            }

            Console.WriteLine("\n!!DİKKAT = Kalkış Noktası Ve Varış Noktası Aynı Olamaz Tekrar Giriniz(Mistake, Try Again).\n");
        }

        // Save selected locations to a text file
        string selectedLocationsFilePath = "Locations.txt";

        using (StreamWriter sw = new StreamWriter(selectedLocationsFilePath, true, Encoding.UTF8))
        {
            sw.WriteLine($"Kalkış Noktası: {departure}, Varış Noktası: {destination}");
        }

        AircraftManager aircraftManager = new AircraftManager();
        Aircraft[] aircrafts = AircraftManager.GetAircrafts();

        Console.WriteLine("\n|Şu An Aktif Olan Uçaklar Ve Boş Koltuk - Hız Bilgileri| \n");

        Console.WriteLine("> Mevcut Uçaklar (Available Aircrafts) = ");
        for (int i = 0; i < aircrafts.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {aircrafts[i]}");
        }

        Console.Write("\n> Lütfen Uçak Tercihinizi Yapın (flight Choice's) = ");
        int aircraftIndex = int.Parse(Console.ReadLine()) - 1;
        Aircraft aircraft = aircrafts[aircraftIndex];

        Console.WriteLine("\n|TARİH(DATE)| \n");
        DateTime departureDate = DateTime.MinValue;
        DateTime returnDate = DateTime.MinValue;
        DateTime currentDate = DateTime.Now;

        // Gidiş tarihi kontrolü
        bool isValidDepartureDate = false;

        while (!isValidDepartureDate)
        {
            Console.Write("\n>Lütfen Gidiş Tarihini (gg.aa.yyyy) Girin: ");
            string departureInput = Console.ReadLine();

            if (DateTime.TryParseExact(departureInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out departureDate))
            {
                isValidDepartureDate = true;

                if (departureDate.Year == currentDate.Year && departureDate >= currentDate)
                {
                    // Gidiş tarihi kontrolü tamamlandı, şimdi dönüş tarihini kontrol et
                    bool isValidReturnDate = false;

                    while (!isValidReturnDate)
                    {
                        Console.Write("\n>Lütfen Dönüş Tarihini (gg.aa.yyyy) Girin: ");
                        string returnInput = Console.ReadLine();

                        if (DateTime.TryParseExact(returnInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out returnDate))
                        {
                            isValidReturnDate = true;

                            if (returnDate.Year == currentDate.Year && returnDate >= currentDate && returnDate >= departureDate)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Hatalı giriş! Dönüş tarihi bu yıl içinde olmalı, gidiş tarihinden ileri bir tarih olmalıdır ve gidiş tarihinden önce olmamalıdır. Lütfen tekrar deneyin.");
                                isValidReturnDate = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen doğru bir tarih formatı kullanın (gg.aa.yyyy).");
                        }
                    }

                    // Dönüş tarihi kontrolü tamamlandı
                    break;
                }
                else
                {
                    Console.WriteLine($"Hatalı giriş! Gidiş tarihi bu yıl içinde olmalı ve şu andan ileri bir tarih olmalıdır. Lütfen tekrar deneyin.");
                    isValidDepartureDate = false;
                }
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Lütfen doğru bir tarih formatı kullanın (gg.aa.yyyy).");
            }
        }

        Customer customer = new Customer(name, surname, ıdcard, phoneno, email);
        Reservation reservation = new Reservation(aircraft, departure, destination, departureDate, returnDate, customer);

        Console.Write("\n>Boşta Olan Koltuk Numarası (Empty Seat Number) = ");
        Console.WriteLine(reservation.SeatNumber);

        Console.Write("\n>Rezervasyon Saatiniz (Reservation Time) = ");
        Console.WriteLine(reservation.ReservationTime);

        Console.Write("\n>Kabul Etmek İçin Enter'a Basın (Enter for Accept) = ");
        Console.ReadLine();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n|Rezervasyonunuz Oluşturulmuştur Aşağıda Görebilirsiniz (Reservation's Confirmed)| \n");
        Console.WriteLine(reservation);


        using (StreamWriter sw = new StreamWriter(CSVKYT, true, Encoding.UTF8))
        {
            sw.WriteLine($"{name},{surname},{ıdcard},{phoneno},{email},{reservation.SeatNumber},{reservation.ReservationTime},{reservation.Aircraft.Name},{reservation.Aircraft.Price},{reservation.Departure.Airport},{reservation.Destination.Airport},{reservation.DepartureDate},{reservation.ReturnDate}");
        }
        Console.ReadLine();

        Console.Write("\n> Ana Menüye Dönmek İster Misiniz? (Evet/Hayır): ");
        string anaMenuDonusSecimi = Console.ReadLine();

        if (anaMenuDonusSecimi.ToLower() == "evet")
        {
            // Kullanıcı evet derse ana menüye dön
            Console.Clear();
            Main(null);
        }
        else
        {
            // Kullanıcı hayır veya geçerli bir seçenek girmezse uygulamadan çık
            Environment.Exit(0);
        }
    }
}