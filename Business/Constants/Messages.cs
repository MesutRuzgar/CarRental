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
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Erişim yetkisi verildi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
    }
}
