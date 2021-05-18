using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class UserMessages
    {
        public static string Added = "Kullanıcı Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Kullanıcı Eklenemedi";

        public static string Deleted = "Kullanıcı Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Kullanıcı Silinemedi";

        public static string Updated = "Kullanıcı Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Kullanıcı Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string UserListed = "Kullanıcı Listelendi";

        public static string UserClaimListed = "Kullanıcı Yetkisi Listelendi";

        public static string UserClaimsListed = "Kullanıcı Yetkileri Listelendi";

        public static string UsersListed = "Kullanıcılar Listelendi";

        public static string UserDetailsListed = "Kullanıcı Detayları Listelendi";

        public static string UserFirsNameInvalid = "Kullanıcı İsmi Geçersiz";
        public static string UserFirsNameCannotBeEmpty = "Kullanıcı İsmi Boş Olamaz!";
        public static string UserFirsNameLimitValueExceeded = "Kullanıcı İsmi Sınır Değeri Aşıldı";

        public static string UserLastNameInvalid = "Kullanıcı Soyismi Geçersiz";
        public static string UserLastNameCannotBeEmpty = "Kullanıcı Soyismi Boş Olamaz!";
        public static string UserLastNameLimitValueExceeded = "Kullanıcı Soyisim Sınır Değeri Aşıldı";

        public static string UserEmailInvalid = "Geçersiz Email Adresi!";
        public static string UserEmailCannotBeEmpty = "Email Adresi Boş Olamaz!";         

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";

        public static string UserEmailAlreadyExists = "Bu Email Adresi başka bir kullanıcı tarafından kullanılmaktadır.";

        
    }
}
