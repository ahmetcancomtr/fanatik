
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.interfaces;
using fanatik.extention;
using fanatik.data;
using MongoDB.Driver;
using fanatik.models;
using System.Collections.Generic;

namespace fanatik.repositories
{
     public class  NewsRepo:RepoBase,INewsRepo
    {
        const String PUBLISHLIST="publishlist";
        const String ARTICLE="article";
        private readonly ISettings settings;

        public NewsRepo(ISettings settings):base(settings)
        {
            this.settings = settings;
        }

        public async Task CreateArticle(Article article)
        {
            var db=GetDatabase();
            var usersColleciton=db.GetCollection<Article>(ARTICLE);
            await usersColleciton.InsertManyAsync(new []{article});
        }
     
        public async Task RemoveArticle(string articleid)
        {
            var db=GetDatabase();
            var filter = Builders<Article>.Filter.Eq(x => x.Id,articleid);
            var update = Builders<Article>.Update.Set(s => s.Active, false);

            await db.GetCollection<Article>(ARTICLE).UpdateOneAsync(filter,update);
        }
        public async Task<Article> GetArticleById(string articleId)
        {
            var db=GetDatabase();
            var articlesColleciton=db.GetCollection<Article>(ARTICLE);
            return (await articlesColleciton.FindAsync(item=>item.Id==articleId&&item.Active)).FirstOrDefault();
        }
        public async Task<List<Article>> ListArticle()
        {
            var db=GetDatabase();
            var articlesColleciton=db.GetCollection<Article>(ARTICLE);
            return (await articlesColleciton.FindAsync(item=>item.Active&&item.Active)).ToList();
        }
        public async Task CreatePublishList(PublishList publishList)
        {
            var db=GetDatabase();
            var usersColleciton=db.GetCollection<PublishList>(PUBLISHLIST);
            await usersColleciton.InsertManyAsync(new []{publishList});
        }

        public async Task<List<PublishList>> AllActivePublishList()
        {
            var db=GetDatabase();
            var usersColleciton=db.GetCollection<PublishList>(PUBLISHLIST);
            return (await usersColleciton.FindAsync(item=>item.Active)).ToList<PublishList>();
        }
        public async Task UpdatePublishListArticleIdList(string publishlistid,List<string> articles)
        {
            
            var db=GetDatabase();
            var filter = Builders<PublishList>.Filter.Eq(x => x.Id,publishlistid);
            var update = Builders<PublishList>.Update.Set(s => s.ArticleList, articles);

            await db.GetCollection<PublishList>(PUBLISHLIST).UpdateOneAsync(filter,update);
        }
        public async Task RemovePublishList(string publishlistid)
        {
            var db=GetDatabase();
            var filter = Builders<PublishList>.Filter.Eq(x => x.Id,publishlistid);
            var update = Builders<PublishList>.Update.Set(s => s.Active, false);

            await db.GetCollection<PublishList>(PUBLISHLIST).UpdateOneAsync(filter,update);
        }
        public async Task<PublishList> GetPublishListById(string publishListId)
        {
            var db=GetDatabase();
            var usersColleciton=db.GetCollection<PublishList>(PUBLISHLIST);
            return (await usersColleciton.FindAsync(item=>item.Id==publishListId)).FirstOrDefault();
        }
        public async Task<List<Article>> GetArticlesByPublishList(string publishlistid)
        {
            var db=GetDatabase();

            var publisList=await GetPublishListById(publishlistid);
            
            var resultList=new List<Article>();
            if(publisList==null){
                return resultList;
            }
            foreach(var articleId in publisList.ArticleList){
                var article=await GetArticleById(articleId);
                if(article!=null){
                    resultList.Add(article);
                }
                
            }
            return resultList;
            
        }

    }

}