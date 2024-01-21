# UÇAK BİLET REZERVASYON UYGULAMASI
-------------------------------------------------------
- Bu uygulama, kullanıcılara uçak rezervasyonu yapma, rezervasyonları görüntüleme ve silme gibi temel uçak rezervasyon işlemlerini gerçekleştirmek için tasarlanmış bir konsol uygulamasıdır. C# programlama dilinde geliştirilmiştir ve kullanıcı dostu bir arayüz sağlamak amacıyla konsol ekranında çalışır.
---------------------------------------------------------------------------------------------------------------- 
# Genel Bakış
- Uygulama içerisinde üç temel sınıf bulunmaktadır: Aircraft (Uçak), Customer (Müşteri) ve Location (Konum). Her sınıf kendi özelliklerini içerir ve uygulamanın çeşitli işlevlerini destekler. Örneğin, Reservation (Rezervasyon) sınıfı, uçak, müşteri, kalkış ve varış konumları gibi bilgileri içerir ve yeni rezervasyonların oluşturulmasını sağlar. Daha sonra bunları belirtilen "MüşteriKayıt.csv" dosyasına kayıt eder ardından da istenilen işleme göre üzerinde işlem yağılabilir.(Görme, Silme gibi)
-----------------------------------------------------------------------------------------------------------------
# Kullanım
- Uygulama, kullanıcıya ana menü aracılığıyla üç temel işlem seçeneği sunar:
- Rezervasyon Görüntüleme (1): Kullanıcıların TC (Kimlik No) numarasını girerek yapmış oldukları rezervasyonları 
  "MüşteriKayıt" adlı csv dosyasından tc nin ait olduğu verileri çekerek görüntüler.
- Rezervasyon Silme (2): TC (Kimlik No) girilerek belirli bir rezervasyonu "MüşteriKayıt" adlı csv dosyasından tc 
  nin ait olduğu verileri silme işlemi gerçekleştirir.
- Yeni Rezervasyon Kayıt (3): Yeni bir rezervasyon kaydı oluşturur ve kullanıcının bilgilerini, uçuş bilgilerini 
  ve rezervasyon detaylarını içerir.
- Uygulama, müşteri bilgilerini MüşteriKayit.csv dosyasında saklar ve rezervasyon bilgilerini bu dosyaya ekler.
--------------------------------------------------------------------------------------------------------------
# Dosya Yapısı
- Aircraft.cs: Uçak sınıfını içerir.
- Customer.cs: Müşteri sınıfını içerir.
- Location.cs: Konum sınıfını içerir.
- Reservation.cs: Rezervasyon sınıfını içerir.
- LocationManager.cs: Lokasyon yöneticisini içerir.
- AircraftManager.cs: Uçak yöneticisini içerir.
- Program.cs: Ana program dosyasıdır ve uygulamayı başlatır.
- ReservationViewer.cs: Rezervasyonları görüntülemek için kullanılan sınıfı içerir.
- CSVKYT: MüşteriKayıt csv dosyasının parametresi
--------------------------------------------------------------------------- 
