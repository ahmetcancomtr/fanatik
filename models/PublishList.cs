
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fanatik.models
{
    public class PublishList
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public List<string> ArticleList { get; set; }
        public List<string> Tags { get; set; }


    }


}