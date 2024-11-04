// Models/HomeViewModel.cs
namespace MyWebApp.Models
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<string> Items { get; set; }

        public HomeViewModel()
        {
            Items = new List<string>();
        }
    }
}