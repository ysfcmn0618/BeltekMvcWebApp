﻿using BeltekMvcWebApp.Models;
using BeltekMvcWebApp.Models.ViewModels;
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
            Ogrenci ogr=null;
            if (id == 1)
            {
                ogr = new Ogrenci { Ad="Ali",Soyad="Veli",Numara=123};
            }
            else if (id == 2)
            {
                ogr = new Ogrenci { Ad = "Muhammed", Soyad = "Ali", Numara = 456 };
            }
            ViewData["ogrenci"]= ogr; //ViewData key-value mantığı ile yürür parantez içi key dir ogr value olur.Farklı bir viewdata oluşturduğumuz zaman farklı bir key değeri belirlenmesi gerekmektedir.key değerleri string değer olmak zorundadır.value değerleri object olur.
            ViewBag.student= ogr;//Viewbag ve viewdata iki taşıma yoönteminide kullanıyorsanız key değerleri farklı olmalıdır.Syntaxı rahat dır fakat dynamik yapılardır.runtime da hata alınabilir.

            var ders = new Ders { Ad = "Matematik", Kod = "Mat-101" };

            var vmOgr=new OgrenciBilgiVM { ders=ders,ogrenci=ogr };//Öğrenci ve ders clasını kapsayan bir model class oluşturulup öğrenci ve dersi tek bir obje altında view a göndermiş olduk


            return View(vmOgr);//View lar aynı zaman da veri taşıma işlemi içinde kullanılır 4 farklı overloadı vardır.ViewModel
        }
    }
}
//Controllerdan view e veri taşıma
//C# kodlarının HTML e dönüştürmeişlemine Render denir.