using Microsoft.AspNetCore.Mvc;

namespace BeltekMvcWebApp.Controllers
{
    public class OgrenciController : Controller
    {
        public string Index()
        {
            return "Selam canım!!!";
        }

        public string OgrenciBilgi()
        {
            return "Öğrenci Bilgileri";
        }
    }
}
