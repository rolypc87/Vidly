﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.Owin.Security.DataHandler;

namespace Vidly.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}