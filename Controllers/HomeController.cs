using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
  public class HomeController : Controller
  {
    public ViewResult Index()
    {
      return View("../../TempView/Temp");
    }

    public ViewResult AboutUs()
    {
      return View();
    }

    public ViewResult ContactUs()
    {
      return View();
    }
  }
}