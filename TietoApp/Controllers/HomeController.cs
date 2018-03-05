using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TietoApp.Models;
using Supremes;
using PagedList;

namespace TietoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LikedBooks = new Dictionary<string, bool>();

            var doc = Dcsoup.Parse(new Uri("http://www.alistofbooks.com/"), 5000);

            var bookListElem = doc.Select("ul.book-list").First;

            var bookList = bookListElem.ChildNodes;

            List<Book> books = new List<Book>();

            foreach (var book in bookList)
            {
                var tempBook = Dcsoup.Parse(book.OuterHtml);

                int rank = 0;

                int.TryParse(tempBook.Select("span.ranking-num").Text, out rank);

                string author = tempBook.Select("p.book-author").Text.Replace("by ", "");

                string title = tempBook.Select("a.book-title").Text;

                string imageUrl = tempBook.Select("img.book-cover").Attr("src");

                string desc = tempBook.Select("p.first-words").Text.Replace("\"", "");

                books.Add(new Book { Rank = rank, Author = author, Title = title, ImageUrl = imageUrl, Description = HttpUtility.HtmlDecode(desc) });
            }

            books = books.Where(b => b.Rank != 0).ToList();

            switch (sortOrder)
            {
                case "rank":
                    books = books.OrderBy(b => b.Rank).ToList();
                    break;
                case "author":
                    books = books.OrderBy(b => b.Author).ToList();
                    break;
                case "title":
                    books = books.OrderBy(b => b.Title).ToList();
                    break;
                default:
                    books = books.OrderBy(b => b.Rank).ToList();
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(books.ToPagedList(pageNumber, pageSize));
        }

}
}