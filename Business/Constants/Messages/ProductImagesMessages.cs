using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class ProductImagesMessages
    {

        public static string Added = "Ürün Resmi Eklendi";
        public static string CouldNotBeAdded = "Eksik veya Hatalı bir bilgi girişinden dolayı Ürün Resmi Eklenemedi";

        public static string Deleted = "Ürün Resmi Silindi";
        public static string CouldNotBeDeleted = "Eksik veya Hatalı bir bilgi girişinden dolayı Ürün Resmi Silinemedi";

        public static string Updated = "Ürün Resmi Güncellendi";
        public static string CouldNotBeUpdated = "Eksik veya Hatalı bir bilgi girişinden dolayı Ürün Resmi Güncellenemedi";

        public static string RecordNotFound = "Kayıt Bulunamadı";

        public static string ProductImageListed = "Ürün Resmi Listelendi";

        public static string ProductImagesListed = "Ürün Resimleri Listelendi";

        public static string ProductImageDetailsListed = "Ürün Resimlerinin Detayları Listelendi";

        public static string ProductImageNameInvalid = "Ürün Resim İsmi Geçersiz";
        public static string ProductImageNameCannotBeEmpty = "Ürün Resim İsmi Boş Olamaz!";
        public static string ProductImagePathCannotBeEmpty = "Resim Dosyasının Yerini Giriniz!"; 
        public static string ProductIdCannotBeEmpty = "Ürün ID'sini Giriniz!";   

        public static string MaintenanceTime = "Sistem bakımı yapılmaktadır. Lütfen daha sonra tekrar deneyiniz!";

        public static string ImageNameAlreadyExists = "Bu İsimde Zaten Başka Bir Ürün Resmi Bulunmaktadır";

        public static string ProductImageLimitValueCannotBeExceeded = "Ürün Resmi sınır değeri aşılamaz.";

        public static string ProductImageLimitValueExceeded = "Ürün Resmi sınır değeri aşıldı.";

    }
}
