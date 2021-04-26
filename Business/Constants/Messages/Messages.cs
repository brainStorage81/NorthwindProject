using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz Bulunmamaktadır.";

        public static string UserRegistered = "Kullanıcı Kaydı Gerçekleşti";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Giriş Yaptı";
        public static string AccessTokenCreated = "Giriş Bileti Oluşturuldu";
    }
}
