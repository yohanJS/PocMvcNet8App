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
using PocMvcNet8App.Services;

namespace PocMvcNet8App.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService _imageService;

        public BlogPostController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IImageService imageService)
        {
            _context = context;
            _userManager = userManager; // Initialize UserManager
            _imageService = imageService;
        }

        // GET: BlogPost
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null && _context.blogPostModel != null)
            {
                // Filter UserPrimaryInfo records by the current user's ID
                var blogPostModelList = await _context.blogPostModel
                    .Include(u => u.User)
                    .Where(u => u.UserId == currentUser.Id)
                    .ToListAsync();

                return View(blogPostModelList);
            }
            else
            {
                // Handle the case where the current user is not found
                return NotFound("Current user not found.");
            }
        }

        // GET: BlogPost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPostModel = await _context.blogPostModel
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPostModel == null)
            {
                return NotFound();
            }

            return View(blogPostModel);
        }

        // GET: BlogPost/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: BlogPost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ImageData,ImageType,ImageFile,Title,Content,CreatedDate,Author")] BlogPostModel blogPostModel)
        {
            BlogPostModel model = new BlogPostModel();
            if (ModelState.IsValid)
            {
                // Get the current user
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null)
                {
                    // Set the UserId property to the current user's ID
                    blogPostModel.UserId = currentUser.Id;

                    if (blogPostModel.ImageFile != null)
                    {
                        blogPostModel.ImageData = await _imageService.ConvertFileToByteArrayAsync(blogPostModel.ImageFile);
                        blogPostModel.ImageType = blogPostModel.ImageFile.ContentType;
                    }
                    else
                    {
                        blogPostModel.ImageFile = null;
                    }

                    _context.Add(blogPostModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the case where the current user is not found
                    return NotFound("Current user not found.");
                }
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", blogPostModel.UserId);
            return View(blogPostModel);
        }

        // GET: BlogPost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPostModel = await _context.blogPostModel.FindAsync(id);
            if (blogPostModel == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", blogPostModel.UserId);
            return View(blogPostModel);
        }

        // POST: BlogPost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ImageData,ImageType,Title,Content,CreatedDate,Author")] BlogPostModel blogPostModel)
        {
            if (id != blogPostModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPostModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostModelExists(blogPostModel.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", blogPostModel.UserId);
            return View(blogPostModel);
        }

        // GET: BlogPost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPostModel = await _context.blogPostModel
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPostModel == null)
            {
                return NotFound();
            }

            return View(blogPostModel);
        }

        // POST: BlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPostModel = await _context.blogPostModel.FindAsync(id);
            if (blogPostModel != null)
            {
                _context.blogPostModel.Remove(blogPostModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostModelExists(int id)
        {
            return _context.blogPostModel.Any(e => e.Id == id);
        }
    }
}
