
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.interfaces;
using fanatik.extention;
using fanatik.data;
using MongoDB.Driver;

namespace fanatik.repositories
{
     public class  RepoBase
    {
        MongoClient client=null;
        private readonly ISettings settings;
        
        public RepoBase(ISettings settings)
        {
            this.settings = settings;
        }

        protected IMongoDatabase GetDatabase()
        {
            if(client==null){
                client=new MongoClient(MongoUrl.Create(settings.MongoConnectionString()));
            }
            return client.GetDatabase(settings.DatabaseName());
             
        }

    }

}