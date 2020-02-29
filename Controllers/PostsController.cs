using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SilverTest.API.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SilverTest.API.Models;
using Microsoft.AspNetCore.Authorization;
using SilverTest.API.Controllers.ActionFilters;

namespace SilverTest.API.Controllers
{
    [TypeFilter(typeof(ValidateAuthHeaderAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        public PostsController(DataContext context)
        {
            _context = context;

        }
        [HttpGet, ActionName("GetPosts")]
        public async Task<ActionResult> GetPosts()
        {
            var values = await _context.Posts.ToListAsync();

            return Ok(values);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var value = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost (Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            // return Ok();
            // return RedirectToAction(nameof(GetPosts));
            return Ok(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest("ID mismatch");
            } else if (!await _context.Posts.AnyAsync( x => x.Id == id) ){
                return BadRequest("No such ID");
            }

            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound("No Such Post");
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok( id+ " deleted.");
        }
        

    }
}