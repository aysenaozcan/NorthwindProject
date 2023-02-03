using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{ 
    //Sürekli newlemeyi önleyebilmek için sabit bir yapı olusturulmalıdır. O yüzden static yazdık.
    public static class Messages
    {   //public fieldler büyük harfle yazılır, private olsaydı başharfi küçük olurdu.
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersizdir.";
        public static string MaintenanceTime= "Sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
    }
}
