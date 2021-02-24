using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class EmployeeMessages
    {
        public static string Added = "Çalışan Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Çalışan Eklenemedi";

        public static string Deleted = "Çalışan Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Çalışan Silinemedi";

        public static string Updated = "Çalışan Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Çalışan Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string EmployeeListed = "Çalışan Listelendi";

        public static string EmployeesListed = "Çalışanlar Listelendi";

        public static string EmployeeDetailsListed = "Çalışan Detayları Listelendi";

        public static string FirstNameInvalid = "Geçersiz İsim";
        public static string FirstNameCannotBeEmpty = "İsim Boş Olamaz!";

        public static string LastNameInvalid = "Geçersiz Soyisim";
        public static string LastNameCannotBeEmpty = "Soyisim Boş Olamaz!";

        public static string EmployeeCityInvalid = "Geçersiz Şehir İsmi";
        public static string EmployeeCityCannotBeEmpty = "Şehir İsmi Boş Olamaz!";

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";
    }
}
