
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fanatik.models
{
   public class  Article
    {
       public string Id { get; set; }
       public bool Active{ get; set; }

       public string Title { get; set; }
       public string Content { get; set; }
       public List<string> Tags { get; set; }
       
    }


}
