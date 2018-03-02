using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TietoApp.Models;
using Supremes;

namespace TietoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var doc = Dcsoup.Parse(new Uri("http://www.alistofbooks.com/"), 5000);

            var importedBooks = doc.Select("ul[class=book-list]");

            List<Book> books = new List<Book>();

            foreach (var book in importedBooks)
            {
                int rank = 0;

                int.TryParse(book.Select("span[class=ranking-num]").Text, out rank);

                books.Add(new Book { Rank = rank });
                
                //float userRating = float.Parse(scoreAnchor[1].Text);
            }

            return View(books);
        }

    }
}