using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
  public class HomeController : Controller
  {
    public ViewResult Index()
    {
      return View();
    }

    public ViewResult AboutUs()
    {
      return View();
    }
  }
}