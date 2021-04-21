using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fanatik.models;

namespace fanatik.interfaces
{
    public interface INewsService
    {
        
        Task<ResponseData<Article>> CreateArticle(Article request);
        Task RemoveArticle(string articleid);
        Task<ResponseData<List<Article>>> ListArticle();
        Task<ResponseData<PublishList>> Publish(PublishList request);
        Task Unpublish(string publishlistid);
        Task<ResponseData<List<PublishList>>> ListPublish();
        Task<ResponseData<List<Article>>> ShowPublish(string publislistid);
        
    }

}