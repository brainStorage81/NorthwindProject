using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public class SupplierMessages
    {
        public static string Added = "Tedarikçi Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Tedarikçi Eklenemedi";

        public static string Deleted = "Tedarikçi Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Tedarikçi Silinemedi";

        public static string Updated = "Tedarikçi Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Tedarikçi Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string SupplierListed = "Tedarikçi Listelendi";

        public static string SuppliersListed = "Tedarikçiler Listelendi";

        public static string SupplierDetailsListed = "Tedarikçi Detayları Listelendi";

        public static string SupplierCompanyNameInvalid = "Şirket Ünvanı Geçersiz";
        public static string SupplierCompanyNameCannotBeEmpty = "Şirket Ünvanı Boş Olamaz!";

        public static string SupplierContactNameInvalid = "İrtibat Kurulacak Kişi İsmi Geçersiz";
        public static string SupplierContactNameCannotBeEmpty = "İrtibat Kurulacak Kişi İsmi Boş Olamaz!";

        public static string SupplierCityInvalid = "Şehir İsmi Geçersiz";
        public static string SupplierCityCannotBeEmpty = "Şehir İsmi Boş Olamaz!";

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";
    }
}
