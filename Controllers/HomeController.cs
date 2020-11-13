using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
  public class HomeController : Controller
  {
    public string Index()
    {
      return "BookStore";
    }
  }
}