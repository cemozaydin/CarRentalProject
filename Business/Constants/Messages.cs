using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarsListed = "Mevcut Araçlar Listelendi...";
        public static string CarDeleted = "Araç silindi";
        public static string CheckDailyPrice = "Günlük kira ücreti 0'dan fazla olmalı";
        public static string CarNameInvalid = "Araç ismi minimum 2 karakter olmalıdır";
        
        public static string BrandAdded = "Marka başarıyla veritabanına eklendi.";
        public static string BrandUpdate = "Marka başarıyla güncellendi.";
        public static string BrandsListed = "Markalar Listelendi...";
        public static string BrandDeleted = "Marka başarıyla veritabanından silindi.";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorUpdate = "Renk Güncellendi";
        public static string ColorListed = "Renkler Listelendi...";
        public static string ColorDeleted = "Renk Silindi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string FirstNameLastNameInvalid = "İsim veya Soyisim Girilmemiş";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserNotDeleted = "HATA. Kullanıcı Silinemedi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listelendi...";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerNotAdded = "HATA. Müşteri Eklenemedi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerNotDeleted = "HATA. Müşteri Silinemedi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomersListed = "Müşteriler Listelendi...";

        public static string RentalAdded = "Kiralama Bilgisi Eklendi";
        public static string RentalAddedError = "Araç teslim edilmediği için tekrar kiraya verilemez";
        public static string RentalUpdateReturnDate = "Araç Teslim Alındı";
        public static string RentalUpdateReturnDateError = "Araç Teslim Alınmış";
        public static string RentalUpdated = "Kiralama Bilgisi Güncellendi";
        public static string RentalListed = "Kiralama Bilgileri Listelendi...";
        public static string RentalDeleted = "Kiralama Bilgisi Silindi";

        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarImageLimitExceeded = "Fotoğraf yükleme limitine takıldınız. En fazla 5 fotoğraf eklenebilir.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";

        public static string ModelAdded = "Araç Modeli Eklendi";
        public static string ModelDeleted = "Araç Modeli Silindi";
        public static string ModelUptated = "Araç Modeli Güncellendi";
        public static string ModelListed ="Araç Modelleri Listelendi...";
        public static string BodyTypeAdded;
        public static string BodyTypeDeleted;
        public static string BodyTypeUpdated;
        public static string BodyTypeListed = "Araç Kasa Tipi Listelendi...";
        public static string FuelTypeAdded;
        public static string FuelTypeDeleted;
        public static string FuelTypeUpdated;
        public static string FuelTypeListed = "Yakıt Tipi Listelendi...";
        public static string GearTypeAdded;
        public static string GearTypeDeleted;
        public static string GearTypeUpdated;
        public static string GearTypeListed = "Vites Tipi Listelendi...";
    }
}
