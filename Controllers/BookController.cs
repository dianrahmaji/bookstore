using System.Collections.Generic;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
  public class BookController : Controller
  {
    private readonly BookRepository _bookRepository = null;

    public BookController()
    {
      _bookRepository = new BookRepository();
    }

    public ViewResult GetAllBooks()
    {
      var data = _bookRepository.GetAllBooks();
      return View(data);
    }

    [Route("book-details/{id}", Name="bookDetailsRoute")]
    public ViewResult GetBook(int id)
    {
      var data = _bookRepository.GetBookById(id);
      return View(data);
    }

    public List<BookModel> SearchBooks(string bookName, string authorName)
    {
      return _bookRepository.SearchBook(bookName, authorName);
    }
  }
}