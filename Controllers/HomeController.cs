using IlanSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IlanSitesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(UrunleriGetir());
        }

        public List<Ilan> UrunleriGetir()
        {
            var urunler = new List<Ilan>();
            using StreamReader reader = new StreamReader("App_Data/ilanlar.txt");
            var txt = reader.ReadToEnd();

            if (string.IsNullOrEmpty(txt))
            {
                return urunler;
            }

            var txtLines = txt.Split("\n");
            foreach (var urun in txtLines)
            {
                var txtParts = urun.Split("|");
                urunler.Add(
                    new Ilan
                    {
                        Name = txtParts[0],
                        Price = int.Parse(txtParts[1]),
                        Img = txtParts[2],
						Date = DateTime.Parse(txtParts[3])
					});
            }

            return urunler;
        }
    }
}
