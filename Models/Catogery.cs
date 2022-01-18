using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEWS_SITE.Models
{
    public class Catogery
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public List<News> Newslst { get; set; }
    }
}
