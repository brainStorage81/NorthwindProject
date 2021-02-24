using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class CustomerMessages
    {
        public static string Added = "Müşteri Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Müşteri Eklenemedi";

        public static string Deleted = "Müşteri Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Müşteri Silinemedi";

        public static string Updated = "Müşteri Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Müşteri Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string CustomerListed = "Müşteri Listelendi";

        public static string CustomersListed = "Müşteriler Listelendi";

        public static string CustomerDetailsListed = "Müşteri Detayları Listelendi";
        
        public static string CompanyNameInvalid = "Şirket İsmi Geçersiz";
        public static string CompanyNameCannotBeEmpty = "Şirket İsmi Boş Olamaz!";

        public static string ContactNameInvalid = "Geçersiz İrtibat Sağlanacak Kişi İsmi";
        public static string ContactNameCannotBeEmpty = "İrtibat Sağlanacak Kişinin İsmi Boş Olamaz!";

        public static string CustomerCityCannotBeEmpty = "Şehir İsmi Boş Olamaz!";
        public static string CustomerCityInvalid = "Geçersiz Şehir İsmi";

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";
    }
}
