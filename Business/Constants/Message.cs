using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
        public static string CarAdded = "Araba başarı ile eklenmiştir.";
        public static string CarDeleted = "Araba başarı ile silinmiştir.";
        public static string CarDailyPriceInvalid = "Araba fiyatı günlük fiyattan düşük olamaz.";
        public static string CarUpdateInvalid = "Araba model yılı bugünden ileri olamaz.";

        public static string BrandAdded = "Marka başarı ile eklenmiştir.";

        public static string ColorAdded = "Renk başarı ile eklenmiştir.";
        

        public static string CarListed = "Arabalar listelendi";
        public static string IdListed = $"{0} numaralı arabalar listelendi";
        public static string Added = "Başarı ile eklenmiştir.";


    }
}
