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
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ArticlesController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]        
        [HttpGet]
        public ActionResult<List<article>> GetAll()
        {
            
            return _context.articles.ToList();
        }

        [AllowAnonymous]  
        [HttpGet("{id}", Name = "GetArticle")]
        public ActionResult<article> GetById(int id)
        {
            var item = _context.articles.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(article item)
        {
            _context.articles.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetArticle", new {  gid = item.id }, item);
        }



        
    }
}
