using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models; // Проверьте, существует ли модель HomeViewModel

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        // Метод для отображения главной страницы
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Title = "Главная страница",
                Items = new List<string> { "Элемент 1", "Элемент 2", "Элемент 3" }
            };
            return View(model);
        }

        // Метод для отображения страницы "О нас"
        public IActionResult About()
        {
            return View();
        }

        // Метод для отображения страницы "Контакты"
        public IActionResult Contact()
        {
            return View();
        }
    }
}