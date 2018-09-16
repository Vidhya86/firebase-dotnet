using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireSharp.Config;
using FireSharp;
using FireSharp.Interfaces;
using System.Net;

namespace MVCDemo.Models
{
    public class Contact :Fireball<Contact>
    {
       
        public string name { get; set; }

    }
}