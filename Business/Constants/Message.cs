using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
        public static string CarAdded = "Araba başarı ile eklenmiştir.";
        public static string CarDeleted = "Araba başarı ile silinmiştir.";
        public static string CarUpdate = "Araba başarı güncellenmiştir.";
        public static string CarListed = "Arabalar listelendi";


        public static string CarDailyPriceInvalid = "Araba fiyatı günlük fiyattan düşük olamaz.";
        public static string CarUpdateInvalid = "Araba model yılı bugünden ileri olamaz.";

        public static string BrandAdded = "Marka başarı ile eklenmiştir.";
        public static string ColorAdded = "Renk başarı ile eklenmiştir.";


        public static string IdListed = $"{0} numaralı arabalar listelendi";
        public static string Added = "Başarı ile eklenmiştir.";

        public static string CarNotRental = "Araba kiralanmış durumdadır.";
        public static string CarRental = "Araba kiralama işleminiz başarılı.";
        public static string ImageAdded = "Resim başarı ile eklenmiştir.";

        public static string CarImageLimitExceeded;
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string PasswordError ="Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı alınmış";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
    }
}
