using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.interfaces;
using fanatik.models;
using System.Collections.Generic;

namespace fanatik.Controllers
{
    public class NewsService : INewsService
    {
        private readonly ISettings settings;
        private readonly INewsRepo newsRepo;

        public NewsService(ISettings settings,INewsRepo newsRepo)
        {
            this.settings = settings;
            this.newsRepo = newsRepo;
        }
       
     
        public async Task<ResponseData<Article>> CreateArticle(Article article)
        {
            article.Id=Guid.NewGuid().ToString();
            article.Active=true;
            await newsRepo.CreateArticle(article);
            return new ResponseData<Article>(){Data=article};
        }
     
        public async Task RemoveArticle(string articleid)
        {
             await newsRepo.RemoveArticle(articleid);
        }
       
        public async Task<ResponseData<List<Article>>> ListArticle()
        {
           var result=await newsRepo.ListArticle();
           return new ResponseData<List<Article>>(){Data=result};
        }
        public async Task<ResponseData<PublishList>> Publish(PublishList publishList)
        {
            publishList.Id=Guid.NewGuid().ToString();
            publishList.Active=true;
            await newsRepo.CreatePublishList(publishList);
            return new ResponseData<PublishList>(){Data=publishList};
        }
        public async Task Unpublish(string publishlistid)
        {
            await newsRepo.RemovePublishList(publishlistid);
        }
        public async Task<ResponseData<List<PublishList>>> ListPublish()
        {
            var result=await newsRepo.AllActivePublishList();
            return new ResponseData<List<PublishList>>(){Data=result};

        }
        public async Task<ResponseData<List<Article>>> ShowPublish(string publislistid)
        {
            var result=await newsRepo.GetArticlesByPublishList(publislistid);
            return new ResponseData<List<Article>>(){Data=result};

        }
    }

}