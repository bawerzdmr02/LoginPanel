# LoginPanel

C# Windows Forms ve SQL Server kullanılarak geliştirilen bu projede, kullanıcılar TC Kimlik numarası ve şifre ile giriş yapabilir. Şifreler SHA256 algoritması ile hashlenerek güvenli şekilde veritabanında saklanır. Kullanıcı 3 kez yanlış giriş yaptığında uygulama otomatik olarak kapanır.

---

## 🚀 Özellikler

- TC Kimlik ve Şifre ile Giriş
- SHA256 ile Şifre Güvenliği
- "Beni Hatırla" kutucuğu
- 3 Hatalı giriş sonrası uygulama kapanır
- Kayıt Ol formu
- SQL Server bağlantısı

---

## 🛠️ Teknolojiler

- C# (.NET Framework)
- Windows Forms
- SQL Server
- ADO.NET
- SHA256 (System.Security.Cryptography)

---

## 📂 Veritabanı Yapısı

```sql
create database UserData;
GO
use UserData
create table Users(

id int primary key identity(1,1),
TCKimlik char(11) not null,
Sifre nvarchar(64) not null

)
```

---

## 🔐 Güvenlik ve Giriş Akışı
- Kullanıcı şifre girdiğinde SHA256 ile hashlenir.
- @parametre ile SQL sorgusu çalıştırılır.
- Başarısız girişte hak düşürülür.
- 3 kez yanlış girildiğinde: Application.Exit() ile uygulama kapanır.

---

## 🖼️ Ekran Görüntüsü

![Giriş Ekranı](https://github.com/bawerzdmr02/LoginPanel/blob/main/GirisYap.png)
![Kayıt Ekranı](https://github.com/bawerzdmr02/LoginPanel/blob/main/KayitOl.png)

---

## 👤 Geliştirici
- Adı: bawerzdmr02
- Yaş: 15
- Okul: Meslek Lisesi - Bilişim Teknolojileri
- Bu proje bireysel öğrenim ve gelişim amacıyla yapılmıştır.

---

## 📌 Notlar
- Şifreler düz metin olarak saklanmaz.
- SQL Injection’a karşı parametreli sorgular kullanılmıştır.
- Formlar arası veri taşıma constructor yöntemiyle yapılabilir.
- Giriş kontrolü kod tarafında yapılır, kullanıcı hataları mesajlarla bildirilir.
- Visual Studio ile açıp çalıştırmak için SQL bağlantı cümlesini güncellemen yeterlidir.

---

## ▶️ Çalıştırmak İçin
1. Visual Studio ile projeyi aç.
2. SQL Server’da “Users” tablosunu oluştur.
3. Kod içinde SqlConnection cümlesini kendi SQL bilgilerine göre ayarla.
4. Projeyi başlat (Start).



