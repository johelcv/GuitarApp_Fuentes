using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guitar.Entities;

namespace GuitarSite.Models
{
    public class ProjectViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Bridge { get; set; }
        public string Neck { get; set; }
        public string Pickup { get; set; }
        public string ImgProject { get; set; }
        
    }
}