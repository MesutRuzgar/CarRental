using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
  public static  class Messages
    {               
        public static string Added = "Ekleme işlemi başarılı";
        public static string Updated = "Güncelleme İşlemi Başarılı.";
        public static string Deleted = "Silme İşlemi Başarılı.";
        public static string Error = "İşlem Sırasında Hata Oluştu.";
        public static string DataInvalid = "Geçersiz Kayıt";
        public static string Listed = "Listeleme Başarılı";
        public static string Succecss = "İşlem Başarılı";
        public static string MaintenanceTime = "Sistem Güncelleniyor.";
        public static string CarImageLimitExceeded = "Resim limiti doldu";
        public static string AuthorizationDenied = "Yetkisiz işlem.";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserRegistered = "Tebrikler! Kayıt olundu!";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
     
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string CarModelNameMinLengt = "Model ismi yetersiz";
        public static string CarDailyPriceError = "Araç ücreti 0 olamaz";
        public static string CreditCardNotValidation = "Kredi Kartı Doğrulama Hatası";
        public static string CreditCardValidateSuccess = "Kredi Kartı Doğrulaması Başarılı";
        public static string BrandExist = "Marka mevcut!";
        public static string BrandNotExist = "Marka mecvut değil!";
        public static string ColorNotExist = "Renk mevcut değil!";
        public static string ColorExist = "Renk mevcut!";
        public static string CustomerCreditCardExist = "Kredi Kartı Kayıtlı!";
    }
}
