﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookSite.ViewModel
{
    public class MessageGroup
    {
        public string UserName { get; set; }
        public int MessageCount { get; set; }
    }
}