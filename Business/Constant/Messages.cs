using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {
        public static string AddedMessage = "Ekleme işlemi başarılı.";
        public static string RemovedMessage = "Silme işlemi başarılı.";
        public static string UpdatedMessage = "Güncelleme işlemi başarılı.";
        public static string ListedMessage = "Listeleme işlemi başarılı.";
        public static string NameInvalid = "Geçersiz isim kullanımı!";
        public static string PriceInvalid = "Geçersiz ücret girişi!";
        public static string ErrorAddedMessage = "Ekleme işlemi başarısız!";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı oluşturuldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı kaydı bulunmaktadır.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
