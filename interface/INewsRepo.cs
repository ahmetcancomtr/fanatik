using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fanatik.models;

namespace fanatik.interfaces
{
    public interface INewsRepo
    {
        Task CreateArticle(Article article);
        Task RemoveArticle(string articleid);
        Task<Article> GetArticleById(string articleId);
        
        Task<List<Article>> ListArticle();
        
        Task CreatePublishList(PublishList publishList);
        
        Task<List<PublishList>> AllActivePublishList();
        
        Task UpdatePublishListArticleIdList(string publishlistid,List<string> articles);
        
        Task RemovePublishList(string publishlistid);
        
        Task<PublishList> GetPublishListById(string publishListId);
        
        Task<List<Article>> GetArticlesByPublishList(string publishlistid);
        
    }

}