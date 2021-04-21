using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanatik.interfaces
{
    public interface ISettings
    {
        TimeSpan getTokenExperationTime();
        string getSecretKey();
        string MongoConnectionString();
        string DatabaseName();
    }

}