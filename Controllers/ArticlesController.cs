using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly DataContext _context;
        // private IUserService _userService;
         private IMapper _mapper;
        // private readonly AppSettings _appSettings;

        public ArticlesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Article>> GetAll()
        {

            return _context.Articles.ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetArticle")]
        public ActionResult<Article> GetById(int Id)
        {
            var item = _context.Articles.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody]Article item)
        {
            Console.Write(item);
            if(item.Category=="")
            {
                item.Category="未分类";
            }
            _context.Articles.Add(item);
            _context.SaveChanges();

            return Ok();
            // return CreatedAtRoute("GetArticle", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, Article item)
        {
            var article = _context.Articles.Find(Id);
            if (article == null)
            {
                return NotFound();
            }
            article.Category = item.Category;
            article.Title = item.Title;
            article.Content = item.Content;



            _context.Articles.Update(article);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var article = _context.Articles.Find(Id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();
            return NoContent();
        }






    }
}
