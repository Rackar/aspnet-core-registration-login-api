﻿using System;
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
    public class CommentsController : ControllerBase
    {
        private readonly DataContext _context;
        // private IUserService _userService;
        //  private IMapper _mapper;
        // private readonly AppSettings _appSettings;

        public CommentsController(DataContext context)
        {
            _context = context;
            // _mapper=mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Comment>> GetAll()
        {

            return _context.Comments.ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetArticleComments")]
        public ActionResult<Comment> GetByArticleId(int Id)
        {
            var itemArti = _context.Articles.Find(Id);
            var item = _context.Comments.Find(itemArti.Id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetArticleComments")]
        public ActionResult<Comment> GetById(int Id)
        {
            var item = _context.Comments.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }



        // [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody]Comment item)
        {
            Console.Write(item);
            
            _context.Comments.Add(item);
            _context.SaveChanges();

            return Ok();
            // return CreatedAtRoute("GetArticle", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, Comment item)
        {
            var comment = _context.Comments.Find(Id);
            if (comment == null)
            {
                return NotFound();
            }

            comment.Content = item.Content;



            _context.Comments.Update(comment);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var comment = _context.Comments.Find(Id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return NoContent();
        }






    }
}
