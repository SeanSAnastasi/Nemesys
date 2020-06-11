
using System.Collections.Generic;

using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Areas.Identity.Data;
using Nemesys.Models;
using System.Linq;

namespace Nemesys.Seeds
{
    
    public class AdminSeed
    {
        private readonly UserManager<User> _userManager;
        private NemesysDBContext _context;
        private readonly SignInManager<User> _signInManager;
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public AdminSeed(UserManager<User> userManager, NemesysDBContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            
        }

        public void SeedAdmin()
        {
            _context.Database.EnsureCreated();
           
            if (!_context.Users.Any())
            {
                var user = new User { UserName = "Admin", Email = "nemesysadmin@gmail.com" };
                var result = _userManager.CreateAsync(user, "P@ssword123");
                user.EmailConfirmed = true;
                Admin admin = new Admin()
                {
                    User = user

                };
                _context.Admin.Add(admin);
                _context.SaveChanges();
            }
            
            
        }
    }
}
