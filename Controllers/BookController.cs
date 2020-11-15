using System.Collections.Generic;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
  public class BookController : Controller
  {
    private readonly BookRepository _bookRepository = null;

    public BookController(BookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task<ViewResult> GetAllBooks()
    {
      var data = await _bookRepository.GetAllBooks();
      return View(data);
    }

    [Route("book-details/{id}", Name="bookDetailsRoute")]
    public async Task<ViewResult> GetBook(int id)
    {
      var data = await _bookRepository.GetBookById(id);
      return View(data);
    }

    public List<BookModel> SearchBooks(string bookName, string authorName)
    {
      return _bookRepository.SearchBook(bookName, authorName);
    }

    public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0) 
    {
      ViewBag.isSuccess = isSuccess;
      ViewBag.bookId = bookId;
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddNewBook(BookModel bookModel) 
    {
      int id = await _bookRepository.AddNewBook(bookModel);
      if(id > 0) 
      {
        return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
      }
      return View();
    }
  }
}