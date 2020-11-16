using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Repository
{
  public class BookRepository
  {
    private readonly BookstoreContext _context = null;

    public BookRepository(BookstoreContext context)
    {
      _context = context;
    }

    public async Task<int> AddNewBook(BookModel model)
    {
      var book = new Books()
      {
        Author = model.Author,
        CreatedOn = DateTime.UtcNow,
        Description = model.Description,
        Title = model.Title,
        Language = model.Language,
        TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
        UpdatedOn = DateTime.UtcNow
      };

      await _context.Books.AddAsync(book);
      await _context.SaveChangesAsync();

      return book.Id;
    }

    public async Task<List<BookModel>> GetAllBooks()
    {
      var bookList = new List<BookModel>();
      var books = await _context.Books.ToListAsync();
      if(books.Any() == true) {
        foreach (var book in books)
        {
          bookList.Add(new BookModel(){
            Id = book.Id,
            Author = book.Author,
            Category = book.Category,
            Description = book.Description,
            Language = book.Language,
            Title = book.Title,
            TotalPages = book.TotalPages,
          });
        }
      }
      return bookList;
    }

    public async Task<BookModel> GetBookById(int id)
    {
      var book = await _context.Books.FindAsync(id);
      if(book != null) 
      {  
        var bookDetails = new BookModel()
        {
          Id = book.Id,
          Author = book.Author,
          Category = book.Category,
          Description = book.Description,
          Language = book.Language,
          Title = book.Title,
          TotalPages = book.TotalPages, 
        };

        return bookDetails;
      }

      return null;
    }

    public List<BookModel> SearchBook(string title, string authorName)
    {
      return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
    }

    private List<BookModel> DataSource()
    {
      return new List<BookModel>()
      {
        new BookModel(){Id=1, Title="MVC", Author="Dian", Description="This is the description of the MVC book", Category="Programming", TotalPages=399, Language="English"},
        new BookModel(){Id=2, Title="C#", Author="Rahmaji", Description="This is the description of the C# book", Category="Programming", TotalPages=1000, Language="Chinnese"},
        new BookModel(){Id=3, Title="React", Author="Rahmaji", Description="This is the description the of React book", Category="Programming", TotalPages=699, Language="Japanese"},
        new BookModel(){Id=4, Title="Vue", Author="Dian", Description="This is the description of the Vue book", Category="Programming", TotalPages=329, Language="Korean"},
        new BookModel(){Id=5, Title="DevOps", Author="Dian", Description="This is the description of the DevOps book", Category="Programming", TotalPages=249, Language="Indonesian"},
        new BookModel(){Id=6, Title="GoLang", Author="Dian", Description="This is the description of the GoLang book", Category="Programming", TotalPages=489, Language="Dutch"},
        new BookModel(){Id=7, Title="NodeJS", Author="Dian", Description="This is the description of the NodeJS book", Category="Programming", TotalPages=729, Language="Russian"},
      };
    }
  }
}
