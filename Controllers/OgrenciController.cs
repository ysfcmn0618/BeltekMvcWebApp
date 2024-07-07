using BeltekMvcWebApp.Models;
using BeltekMvcWebApp.Models.ViewModels;
using BeltekMvcWebApp.Veritabani;
using Microsoft.AspNetCore.Mvc;

namespace BeltekMvcWebApp.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult OgrenciBilgi(int id)
        {
            var dbco = new DbContextOgrenciler();
            Ogrenci ogr=null;
            if (id == 1)
            {
                ogr = new Ogrenci { Ad="Ali",Soyad="Veli",Numara=123};
                
                dbco.Add(ogr);
            }
            else if (id == 2)
            {
                ogr = new Ogrenci { Ad = "Muhammed", Soyad = "Ali", Numara = 456 };
                dbco.Add(ogr);
            }
            ViewData["ogrenci"]= ogr; //ViewData key-value mantığı ile yürür parantez içi key dir ogr value olur.Farklı bir viewdata oluşturduğumuz zaman farklı bir key değeri belirlenmesi gerekmektedir.key değerleri string değer olmak zorundadır.value değerleri object olur.
            ViewBag.student= ogr;//Viewbag ve viewdata iki taşıma yoönteminide kullanıyorsanız key değerleri farklı olmalıdır.Syntaxı rahat dır fakat dynamik yapılardır.runtime da hata alınabilir.

            var ders = new Ders { Ad = "Matematik", Kod = "Mat-101" };

            var vmOgr=new OgrenciBilgiVM { ders=ders,ogrenci=ogr };//Öğrenci ve ders clasını kapsayan bir model class oluşturulup öğrenci ve dersi tek bir obje altında view a göndermiş olduk


            return View(vmOgr);//View lar aynı zaman da veri taşıma işlemi içinde kullanılır 4 farklı overloadı vardır.ViewModel
        }
        public ViewResult OgrenciListe()
        {
            var ogr1 = new Ogrenci { Ad = "Ali", Soyad = "Veli", Numara = 123 };
            var ogr2 = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 };
            var ogr3 = new Ogrenci { Ad = "ysf", Soyad = "cmn", Numara = 111 };
            
            var lst=new List<Ogrenci>();//generic liste olarak öğrenci class ı oluşturulmuştur Bu listenin her bir nesnesi öğrenci class ı içerir.
            
            lst.Add(ogr1);
            lst.Add(ogr2);
            lst.Add(ogr3);
            
            return View(lst);
        }
    }
}
//Controllerdan view e veri taşıma
//C# kodlarının HTML e dönüştürmeişlemine Render denir.