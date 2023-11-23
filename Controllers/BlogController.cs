using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            BlogModel model = new BlogModel();
            var currentUser = await _userManager.GetUserAsync(User);

            if (_context.blogPostModel != null)
            {
                model.Posts = _context.blogPostModel.ToList();
            }

            if (currentUser != null && _context.UserPrimaryInfo != null)
            {
                // Filter UserPrimaryInfo records by the current user's ID
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
            BlogModel blogModel = new BlogModel();

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

            return View(blogModel);
        }


        [HttpPost]
        public async Task<ActionResult> AddComment(int? id, [Bind("TitleComment,Comment")] CommentModel commentModel)
        {
            // Assuming you have a property for the currently signed-in user
            var currentUser = await _userManager.GetUserAsync(User);
            BlogPostModel? blogPostModel = new BlogPostModel();

            if (currentUser != null)
            {
                commentModel.UserId = currentUser.Id;
                //commentModel.BlogPostId = blogPostModel.Id;
                commentModel.TitleComment = commentModel.TitleComment;
                commentModel.Comment = commentModel.Comment;

                // Add the comment to the database
                _context.CommentModel.Add(commentModel);
                await _context.SaveChangesAsync();

                // Redirect back to the blog post details page
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the current user is not found
                return NotFound("Current user not found.");
            }
        }
        private bool BlogModelExists(int id)
        {
            return _context.BlogModel.Any(e => e.Id == id);
        }
    }
}
