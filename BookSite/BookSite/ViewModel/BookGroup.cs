using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookSite.ViewModel
{
    public class BookGroup
    {
        public string Type { get; set; }
        public int BookCount { get; set; }
    }
}