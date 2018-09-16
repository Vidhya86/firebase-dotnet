﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Question:Fireball<Question>
    {
        public string Text{ get; set; }

        public List<string> answers{ get; set; }

    }
}