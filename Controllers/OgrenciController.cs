using BeltekMvcWebApp.Models;
using BeltekMvcWebApp.Models.ViewModels;
using BeltekMvcWebApp.Veritabani;
using Microsoft.AspNetCore.Mvc;

namespace BeltekMvcWebApp.Controllers
{
    public class OgrenciController : Controller
    {
        DbContextOgrenciler dbco = new DbContextOgrenciler();
        public ViewResult Index()
        {
            using (var ctx = new DbContextOgrenciler())
            {
                var lst = ctx.Students.ToList();
                return View(lst);
            }
            //return View();
        }

        public ViewResult OgrenciBilgi(int id)
        {
            
            Student ogr=null;
            if (id == 1)
            {
                ogr = new Student { Name="Ali",Surname="Veli",Number=123};
                
                dbco.Add(ogr);
                dbco.SaveChanges();
            }
            else if (id == 2)
            {
                ogr = new Student { Name = "Muhammed", Surname = "Ali", Number = 456 };
                dbco.Add(ogr);
                dbco.SaveChanges();
            }
            ViewData["ogrenci"]= ogr; //ViewData key-value mantığı ile yürür parantez içi key dir ogr value olur.Farklı bir viewdata oluşturduğumuz zaman farklı bir key değeri belirlenmesi gerekmektedir.key değerleri string değer olmak zorundadır.value değerleri object olur.
            ViewBag.student= ogr;//Viewbag ve viewdata iki taşıma yoönteminide kullanıyorsanız key değerleri farklı olmalıdır.Syntaxı rahat dır fakat dynamik yapılardır.runtime da hata alınabilir.

            //var ders = new Ders { Ad = "Matematik", Kod = "Mat-101" ,GunlukDersSaati=12,HaftalikSaat=12};
            //dbco.Add(ders);
            //dbco.SaveChanges();
            var vmOgr=new OgrenciBilgiVM { Student=ogr };//Öğrenci ve ders clasını kapsayan bir model class oluşturulup öğrenci ve dersi tek bir obje altında view a göndermiş olduk


            return View(vmOgr);//View lar aynı zaman da veri taşıma işlemi içinde kullanılır 4 farklı overloadı vardır.ViewModel
        }
        public ViewResult OgrenciListe()
        {
            //var ogr1 = new Student {Name = "Ali", Surname = "Veli", Number = 123 };
            //var ogr2 = new Student {Name = "Ahmet", Surname = "Mehmet", Number = 456 };
            //var ogr3 = new Student {Name = "ysf", Surname = "cmn", Number = 111 };
            
            //var lst=new List<Student>();//generic liste olarak öğrenci class ı oluşturulmuştur Bu listenin her bir nesnesi öğrenci class ı içerir.
            
            //lst.Add(ogr1);
            //lst.Add(ogr2);
            //lst.Add(ogr3);
            //dbco.Add(ogr1);
            //dbco.Add(ogr2);
            //dbco.Add(ogr3);
            //dbco.SaveChanges();
            using (var ctx = new DbContextOgrenciler())
            {
                var lst = ctx.Students.ToList();
                return View(lst);
            }
                //return View(lst);
        }
    }
}
//Controllerdan view e veri taşıma
//C# kodlarının HTML e dönüştürmeişlemine Render denir.