using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookSite.ViewModel
{
    public class UserGroup
    {
        public int User { get; set; }
        public int UserCount { get; set; }
    }
}