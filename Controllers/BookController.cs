using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
  public class BookController : Controller
  {
    public string GetAllBooks()
    {
      return "All books";
    }

    public string GetBook(int id)
    {
      return $"Book with id = {id}";
    }

    public string SearchBooks(string bookName, string authorName)
    {
      return $"Book with name = {bookName} & Author = {authorName}";
    }
  }
}