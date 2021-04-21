
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fanatik.models
{
   public class  ResponseData<T>
   {
       public int Status { get; set; }
       public T Data { get; set; }

       
    }


}