using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class ShipperMessages
    {
        public static string Added = "Nakliyeci Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Nakliyeci Eklenemedi";

        public static string Deleted = "Nakliyeci Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Nakliyeci Silinemedi";

        public static string Updated = "Nakliyeci Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Nakliyeci Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string ShipperListed = "Nakliyeci Listelendi";

        public static string ShippersListed = "Nakliyeciler Listelendi";

        public static string ShipperDetailsListed = "Nakliyeci Detayları Listelendi";

        public static string ShipCompanyPhoneCannotBeEmpty = "Telefon Numarası Boş Olamaz!";
        public static string ShipCompanyPhoneLength = "Lütfen, numarayı başında sıfır olmadan 10 karakter olarak yazınız!..";

        public static string ShipperCompanyNameCannotBeEmpty = "Şirket Ünvanı Boş Olamaz!";
        public static string ShipperCompanyNameInvalid = "Şirket Ünvanı Geçersiz";

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";

    }
}
