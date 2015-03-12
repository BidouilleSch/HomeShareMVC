using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Models
{
    public class JgridMembre
    {
        public string records { get; set; }
        public string page { get; set; }
        public string total { get; set; }
        public List<JsonMembre> rows { get; set; }
    }
}