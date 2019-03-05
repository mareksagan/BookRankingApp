using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRankingApp.Models
{
    public class Book
    {
        public int Rank { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}