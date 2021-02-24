using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class OrderMessages
    {
        public static string Added = "Sipariş Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Sipariş Eklenemedi";

        public static string Deleted = "Sipariş Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Sipariş Silinemedi";

        public static string Updated = "Sipariş Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Sipariş Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string OrderListed = "Sipariş Listelendi";

        public static string OrdersListed = "Siparişler Listelendi";

        public static string OrderDetailsListed = "Sipariş Detayları Listelendi";

        public static string ShipCityInvalid = "Geçersiz Şehir İsmi";
        public static string ShipCityCannotBeEmpty = "Şehir İsmi Boş Olamaz!";

        public static string OrderDateCannotBeEmpty = "Tarih Boş Olamaz!";

        public static string ShipNameInvalid = "Geçersiz Gemi İsmi";
        public static string ShipNameCannotBeEmpty = "Gemi İsmi Boş Olamaz!";

        public static string ShipCountryInvalid = "Geçersiz Ülke İsmi";
        public static string ShipCountryCannotBeEmpty = "Ülke İsmi Boş Olamaz!";

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";
    }
}
