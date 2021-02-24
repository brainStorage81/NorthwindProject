using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class OrderDetailMessages
    {
        public static string Added = "Sipariş Detayı Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Sipariş Detayı Eklenemedi";

        public static string Deleted = "Sipariş Detayı Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Sipariş Detayı Silinemedi";

        public static string Updated = "Sipariş Detayı Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Sipariş Detayı Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string OrderDetailListed = "Sipariş Detayı Listelendi";

        public static string OrderDetailsListed = "Sipariş Detayları Listelendi";

        public static string UnitPriceCannotBeNegativeValue = "Birim Fiyatı Negatif Olamaz!";
        public static string UnitPriceCannotBeEmpty = "Birim Fiyatı Boş Olamaz!";

        public static string DiscountCannotBeNegativeValue = "indirim Oranı Negatif Olamaz!";

        public static string QuantityCannotBeEmpty = "Miktar Boş Olamaz!";

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";
    }
}
