using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PocMvcNet8App.Data;
using PocMvcNet8App.Models;

namespace PocMvcNet8App.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager; // Initialize UserManager
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            BlogModel? model = new BlogModel();

            // If not in cache, fetch data from the database
            model = new BlogModel();
            var currentUser = await _userManager.GetUserAsync(User);

            if (_context.blogPostModel != null)
            {
                model.Posts = await _context.blogPostModel.FromSqlRaw("spblogPostModel_GetAllBlogs").ToListAsync();
            }

            if (currentUser != null && _context.UserPrimaryInfo != null)
            {
                var user = await _context.UserPrimaryInfo
                    .Include(u => u.User)
                    .Where(u => u.UserId == currentUser.Id)
                    .ToListAsync();

                model.users = user.ToList();
            }

            return View(model);
        }

        // GET: Blog/Details/ofId
        public IActionResult Details(int? id)
        {
            BlogModel? blogModel = new BlogModel();
            BlogPostModel? blogPostModel = new BlogPostModel();

            if (id == null)
            {
                return NotFound();
            }

            if (_context.blogPostModel != null)
            {
                //filter the post by the ID
                blogModel.Posts = _context.blogPostModel
                    .Where(post => post.Id == id)
                    .ToList();
            }

            if (blogModel.Posts != null) 
            {
                blogPostModel = blogModel.Posts.FirstOrDefault();
            }
            if (_context.CommentModel != null && blogPostModel != null)
            {
                blogPostModel.Comments = _context.CommentModel
                    .Where(comment => comment.BlogPostId == id).ToList();
            }
            if (_context.SubCommentModel != null)
            {

                CommentModel commentModel = new CommentModel();
                if (_context.CommentModel != null && _context.CommentModel.Any())
                {
                    commentModel = _context.CommentModel.FirstOrDefault(comment => comment.BlogPostId == id);
                }

                blogPostModel.SubComments = _context.SubCommentModel.ToList();
            }

            return View(blogPostModel);
        }
        private bool BlogModelExists(int id)
        {
            return _context.BlogModel.Any(e => e.Id == id);
        }
    }
}
