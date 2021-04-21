
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.interfaces;

namespace fanatik.Controllers
{
    public class Settings : ISettings
    {
        public TimeSpan getTokenExperationTime()
        {
            return TimeSpan.FromHours(int.Parse(Environment.GetEnvironmentVariable("AUTH_TOKEN_EXP_HOURS")));
        }
        public string getSecretKey()
        {
            return Environment.GetEnvironmentVariable("AUTH_SECRETKEY");
        }
        public string MongoConnectionString()
        {
            return Environment.GetEnvironmentVariable("MONGO_CONNECTION");
        }
        public string DatabaseName()
        {
             return Environment.GetEnvironmentVariable("MONGO_DATABASE");
        }
      
    }

}