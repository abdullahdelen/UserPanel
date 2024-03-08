.NET Core 7 User Registration and Listing Application
Project Description:
This project provides a simple user registration and listing application using .NET Core 7 and PostgreSQL. Users can be registered through a form containing TC Identity Number, Name, Surname, and Date of Birth,Date of Create,Date of Update,Status information. During the registration process, TC Identity Number is validated through the NVI KPS Service and field validation is performed with FluentValidation. Registered users can be listed through an HTML table.
Project Features:
.NET Core 7: Modern and cross-platform web development framework.
PostgreSQL: Powerful and reliable open-source database.
User Registration: Form with TC Identity Number, Name, Surname, and Date of Birth information.
NVI KPS Service: Integrated web service for TC Identity Number validation.
FluentValidation: Library used for field validation.
HTML Table: HTML table used to list registered users.
Setup:
Download and install Visual Studio 2022 or a later version.
Create a new ASP.NET Core Web Application (.NET 7) project.
Install the following packages using NuGet Package Manager:
Microsoft.EntityFrameworkCore
Npgsql.EntityFrameworkCore.PostgreSQL
AutoMapper
FluentValidation
Add the PostgreSQL connection string to the appsettings.json file.
Create a model class named User in the Models folder.
Write your code and run the application.
Usage:
Fill out the registration form and click the "Submit" button.
TC Identity Number validation and field validation will be performed.
If the validation is successful, the user is registered in the database and displayed in the list.
If the validation fails, an error message is displayed.
Notes:
This project is designed as a simple example. In a real-world application, you may need to add more features and functionality.
To use the NVI KPS Service, you need to review the API information of the web service at https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx and apply the necessary steps.
GitHub:
You can download the source code of this project from https://github.com/abdullahdelen/UserPanel
Troubleshooting:
If you encounter any problems, please feel free to open an issue report at https://github.com/abdullahdelen



.NET Core 7 ile Kullanıcı Kayıt ve Listeleme Uygulaması
Proje Açıklaması:
Bu proje, .NET Core 7 ve PostgreSQL kullanarak basit bir kullanıcı kayıt ve listeleme uygulaması sunar. Kullanıcılar, TC Kimlik No, Ad, Soyad ve Doğum Tarihi,Oluşturma Tarihi,Güncelleme Tarihi ve Durum bilgilerini içeren bir form aracılığıyla kaydedilebilir. Kayıt işlemi sırasında, TC Kimlik No'nun NVI KPS Servisi aracılığıyla doğrulanması ve FluentValidation ile alan doğrulama işlemleri de yapılmaktadır. Kaydedilen kullanıcılar, bir HTML tablosu aracılığıyla listelenebilir.
Proje Özellikleri:
.NET Core 7: Modern ve platformlar arası web geliştirme için ideal bir framework.
PostgreSQL: Güçlü ve güvenilir bir açık kaynaklı veritabanı.
Kullanıcı Kayıt: TC Kimlik No, Ad, Soyad ve Doğum Tarihi bilgilerini içeren bir form.
NVI KPS Servisi: TC Kimlik No doğrulama için entegre edilmiş web servisi.
FluentValidation: Alan doğrulama için kullanılan kütüphane.
HTML Tablosu: Kayıtlı kullanıcıların listelenmesi için kullanılan HTML tablosu.
Kurulum:
Visual Studio 2022 veya daha yeni bir sürümünü indirin ve yükleyin.
Yeni bir ASP.NET Core Web Uygulaması (.NET 7) projesi oluşturun.
NuGet Paket Yöneticisi aracılığıyla aşağıdaki paketleri yükleyin:
Microsoft.EntityFrameworkCore
Npgsql.EntityFrameworkCore.PostgreSQL
AutoMapper
FluentValidation

appsettings.json dosyasına PostgreSQL bağlantı dizesini ekleyin.
Models klasörüne User adında bir model sınıfı oluşturun.
Kodunuzu yazın ve uygulamayı çalıştırın.
Kullanım:

Kayıt formunu doldurun ve "Submit" butonuna tıklayın.
TC Kimlik No doğrulama ve alan doğrulama işlemleri gerçekleştirilecektir.
Doğrulama işlemleri başarılıysa, kullanıcı veritabanına kaydedilir ve listede gösterilir.
Doğrulama işlemleri başarısızsa, hata mesajı gösterilir.
Notlar:
Bu proje, basit bir örnek olarak tasarlanmıştır. Gerçek bir uygulamada, daha fazla özellik ve işlevsellik eklemeniz gerekebilir.
NVI KPS Servisi kullanımı için, https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx adresinden web servisinin API bilgilerini gözden geçirmeniz ve gerekli adımları uygulamanız gerekmektedir.
GitHub:
Bu projenin kaynak kodunu [https://github.com/](https://github.com/abdullahdelen/UserPanel) adresinden indirebilirsiniz.
Sorun Giderme:
Herhangi bir sorunla karşılaşırsanız, lütfen [https://github.com/](https://github.com/abdullahdelen) adresindeki issue tracker'da bir rapor açmaktan çekinmeyin.
