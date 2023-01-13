# BackendDMBS
backend system to manage charging stations
-Veritabanı projesi için backend sistemi-

Proje Konusu

Proje şarj istasyonlarına kurulacak araç şarj cihazlarının kontrolünü sağlayan bir web + mobil uygulamadan oluşan bir projedir 
Elektrikli araç şarj cihazlarının bakım, arıza tamir gibi işlemlerini takip etmeye yarayan bir projedir. Web uygulamasında personeller,
istasyonlar, servisler gibi bilgiler görüntülenebilecek ve düzenlenebilecektir. Mobil uygulamada ise cihaz için servis ekleme işlemi 
yapılabilecektir.Personel istasyona giderek orada bulunan cihazlara servis işlemi (arıza tamiri, bakım) yapacak ve bunu mobil
uygulamadan kayıt edecektir. Bu repository projenin backend sistemini içermektedir.

Projeyi çalıştırmak için yapılması gerekenler

Api/Properties/launchSettings.json dizinindeki  "applicationUrl": "http://192.168.1.107:5243" kısmı kendi ip adresinizle değiştirmek  http://İP-ADRESİNİZ:5243

DataAccess/MyDbContext.cs dizinindeki     string connString = "Server=localhost; User=; Password=; Database=VTProject"; Kısmına kendi ad ve şifrenizi girmek



Terminal->dotnet ef migrations add myMigration

Update-Database
