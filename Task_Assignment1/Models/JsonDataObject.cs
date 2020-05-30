using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_Assignment1.Models
{
    public class JsonDataObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public int level { get; set; }
        public List<JsonDataObject> children { get; set; }
        public int? parent_id { get; set; }
    }
}