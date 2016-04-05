using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookSite.ViewModel
{
    public class AdminGroup
    {
        public int User { get; set; }
        public int AdminCount { get; set; }
    }
}