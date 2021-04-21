using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using fanatik.extention;
using fanatik.interfaces;
using fanatik.models;
using fanatik.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fanatik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService service;

        public NewsController(INewsService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("create-article")]
        [FrontAuth]
        public async Task<ResponseData<Article>> CreateArticle(Article request)
        {
            return await service.CreateArticle(request);
        }
        [HttpGet]
        [Route("remove-article/{articleid}")]
        [FrontAuth]
        public async Task RemoveArticle(string articleid)
        {
            await service.RemoveArticle(articleid);
        }
        [HttpGet]
        [Route("list-article")]
        [FrontAuth]
        public async Task<ResponseData<List<Article>>> ListArticle()
        {
           return await service.ListArticle();

        }
        [HttpPost]
        [Route("publish")]
        [FrontAuth]
        public async Task<ResponseData<PublishList>> Publish(PublishList request)
        {
             return await service.Publish(request);

        }
        [HttpGet]
        [Route("unpublish/{publishlistid}")]
        [FrontAuth]
        public async Task Unpublish(string publishlistid)
        {
            await service.Unpublish(publishlistid);
        }
        [HttpGet]
        [Route("list-all-publish")]
        [FrontAuth]
        public async Task<ResponseData<List<PublishList>>> ListPublish()
        {
            return await service.ListPublish();

        }
        [HttpGet]
        [Route("show-publish/{publislistid}")]
        [FrontAuth]
        public async Task<ResponseData<List<Article>>> ShowPublish(string publislistid)
        {
           return await service.ShowPublish(publislistid);

        }
    }
}


