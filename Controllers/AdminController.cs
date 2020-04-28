using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nemesys.Areas.Identity.Data;
using Nemesys.Models;

namespace Nemesys.Controllers
{
    public class AdminController : Controller
    {
        private SignInManager<User> _signinManager;
        private UserManager<User> _userManager;
        private NemesysDBContext _context;
        public AdminController(SignInManager<User> signInManager, UserManager<User> userManager, NemesysDBContext context)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            if (_signinManager.IsSignedIn(User))
            {
                
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var admin = _context.Admin.SingleOrDefault(c => c.User.Id == userId);
                if (admin != null)
                {
                    return View();
                }
                
            }
            
                return NotFound();
            
            
        }
    }
}