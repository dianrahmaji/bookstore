using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Bookstore.Models;

namespace Bookstore.Controllers
{
  public class HomeController : Controller
  {
    public ViewResult Index()
    {
      ViewBag.Title = 123;

      dynamic data = new ExpandoObject();
      data.Id = 1;
      data.Name = "Dian Rahmaji";

      ViewBag.Data = data;

      ViewBag.Type = new BookModel(){Id=1, Author="Dian"};

      return View();
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