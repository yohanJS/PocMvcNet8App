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
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comment
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommentModel.ToListAsync());
        }

        //[HttpPost]
        //public async Task<ActionResult> AddComment([Bind("Id,TitleComment,Comment")] CommentModel commentModel)
        //{
        //    // Assuming you have a property for the currently signed-in user
        //    var currentUser = await _userManager.GetUserAsync(User);

        //    if (currentUser != null)
        //    {
        //        commentModel.UserId = currentUser.Id;
        //        //commentModel.BlogPostId = blogPostModel.Id;
        //        commentModel.TitleComment = commentModel.TitleComment;
        //        commentModel.Comment = commentModel.Comment;

        //        // Add the comment to the database
        //        _context.CommentModel.Add(commentModel);
        //        await _context.SaveChangesAsync();

        //        // Redirect back to the blog post details page
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // Handle the case where the current user is not found
        //        return NotFound("Current user not found.");
        //    }
        //}
        [HttpPost]
        public async Task<ActionResult> AddComment(int blogPostId, [Bind("Id,NewComment.TitleComment,NewComment.Comment")] BlogPostModel blogPostModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            CommentModel commentModel = new CommentModel();

            if (currentUser != null)
            {
                //commentModel.UserId = currentUser.Id;
                //commentModel.BlogPostId = blogPostModel.Id;
                //commentModel.TitleComment = blogPostModel.NewComment.TitleComment;
                //commentModel.Comment = blogPostModel.NewComment.Comment;

                //_context.CommentModel.Add(commentModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Blog", new { id = blogPostId });
            }
            else
            {
                return NotFound("Current user not found.");
            }
        }


        // GET: Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.CommentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentModel == null)
            {
                return NotFound();
            }

            return View(commentModel);
        }

        // GET: Comment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BlogPostId,Title,Content,Created")] CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commentModel);
        }

        // GET: Comment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.CommentModel.FindAsync(id);
            if (commentModel == null)
            {
                return NotFound();
            }
            return View(commentModel);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BlogPostId,Title,Content,Created")] CommentModel commentModel)
        {
            if (id != commentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentModelExists(commentModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(commentModel);
        }

        // GET: Comment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.CommentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentModel == null)
            {
                return NotFound();
            }

            return View(commentModel);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentModel = await _context.CommentModel.FindAsync(id);
            if (commentModel != null)
            {
                _context.CommentModel.Remove(commentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentModelExists(int id)
        {
            return _context.CommentModel.Any(e => e.Id == id);
        }
    }
}
