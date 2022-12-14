using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.Models;


namespace ParkingApp.Controllers
{
    public class SpacesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        public SpacesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: Spaces
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByEmailAsync(User?.Identity?.Name);
            var userId = Convert.ToString(user.Id);
            var applicationDbContext = _context.spaces.Where(s => s.UserId == userId);
            return View(await applicationDbContext.ToListAsync());
        }

        //Get: Locations
        public async Task<IActionResult> searchSpace(string SearchString)
        {
            /*var findOnly = _context.spaces.Where(a => a.Local_Govt.Equals("Area"));
            return View(findOnly.ToListAsync());*/
            ViewData["CurrentAera"] =SearchString;
            var area = from a in _context.spaces
                       select a;
            if (!String.IsNullOrEmpty(SearchString))
            {
                area = area.Where(a => a.Local_Govt.Contains(SearchString));  //does the searching
            }
            return View(area); //if found return here
        }

        [HttpGet]
        public IActionResult SearchResult(Space ar)
        {
            if (ar.Local_Govt == null)
            {
                return View();
            } 

            var spacelot1 = from b in _context.bookings where(ar.Local_Govt == b.Local_Govt)
                            select b;
            var spacelot = _context.spaces.Where(r=> !spacelot1.Any( la => la.Local_Govt == r.Local_Govt )).Include(x=> x.Local_Govt).ToList(); 
            foreach (var item in spacelot)
            {
                if (item.Local_Govt == ar.Local_Govt)
                {
                    ar..Add(item);
                }
            }
            return View(ar);
        }

        // GET: Spaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.spaces == null)
            {
                return NotFound();
            }

            var space = await _context.spaces
                .Include(s => s.UserId)
                .FirstOrDefaultAsync(m => m.id == id);
            if (space == null)
            {
                return NotFound();
            }

            return View(space);
        }

        // GET: Spaces/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Spaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Address,Local_Govt,Status,No_Slot,UserId,Open_Time,Close_Time,Daily_Parking,Weekly_Parking,Monthly_Parking,Parking_Desc")] Space space)
        {

            var user = await userManager.FindByEmailAsync(space.UserId);
            if (user != null)
            {
                space.ApplicationUser = user;
                space.UserId = user.Id;

            }
           
             if (ModelState.IsValid)
            {
                _context.Add(space);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(space);
        }

        // GET: Spaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.spaces == null)
            {
                return NotFound();
            }

            var space = await _context.spaces.FindAsync(id);
            if (space == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", space.UserId);
            return View(space);
        }

        // POST: Spaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Address,Local_Govt,Status,No_Slot,Open_Time,Close_Time,UserId,Daily_Parking,Weekly_Parking,Monthly_Parking,Parking_Desc")] Space space)
        {
            if (id != space.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(space);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaceExists(space.id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", space.UserId);
            return View(space);
        }


       /* public async Task<IActionResult> SearchFor ()
        {
            var applicationDbContext = _context.spaces.Include(s => s.Local_Govt);
            return View(await applicationDbContext.ToListAsync());
        }*/

        // GET: Spaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.spaces == null)
            {
                return NotFound();
            }

            var space = await _context.spaces
                .Include(s => s.UserId)
                .FirstOrDefaultAsync(m => m.id == id);
            if (space == null)
            {
                return NotFound();
            }

            return View(space);
        }

        

        // POST: Spaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.spaces == null)
            {
                return Problem("Entity set 'ApplicationDbContext.spaces'  is null.");
            }
            var space = await _context.spaces.FindAsync(id);
            if (space != null)
            {
                _context.spaces.Remove(space);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaceExists(int id)
        {
          return _context.spaces.Any(e => e.id == id);
        }
    }
}
