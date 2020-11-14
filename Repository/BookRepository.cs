using System.Collections.Generic;
using System.Linq;
using Bookstore.Models;

namespace Bookstore.Repository
{
  public class BookRepository
  {
    public List<BookModel> GetAllBooks()
    {
      return DataSource();
    }

    public BookModel GetBookById(int id)
    {
      return DataSource().Where(x => x.Id == id).FirstOrDefault();
    }

    public List<BookModel> SearchBook(string title, string authorName)
    {
      return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
    }

    private List<BookModel> DataSource()
    {
      return new List<BookModel>()
      {
        new BookModel(){Id=1, Title="MVC", Author="Dian", Description="This is the description of the MVC book"},
        new BookModel(){Id=2, Title="C#", Author="Rahmaji", Description="This is the description of the C# book"},
        new BookModel(){Id=3, Title="React", Author="Rahmaji", Description="This is the description the of React book"},
        new BookModel(){Id=4, Title="Vue", Author="Dian", Description="This is the description of the Vue book"},
        new BookModel(){Id=5, Title="DevOps", Author="Dian", Description="This is the description of the DevOps book"},
        new BookModel(){Id=6, Title="GoLang", Author="Dian", Description="This is the description of the GoLang book"},
        new BookModel(){Id=7, Title="NodeJS", Author="Dian", Description="This is the description of the NodeJS book"},
      };
    }
  }
}