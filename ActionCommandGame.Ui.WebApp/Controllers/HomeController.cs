using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ActionCommandGame.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ActionCommandGame.Ui.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        
        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Authorize, so this page is only accessable when user is logged in
        //logged in = cookie is found with correct user+password combo
        //is done via app.UseAuthentication() in Startup.cs
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        
        //Log in
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Player player)
        {

            if (ModelState.IsValid)
            {

                //get the user via usermanager (= cookie stored in browser)
                var user = await _userManager.FindByNameAsync(player.Name);

                if (user != null)
                {
                    //sign in with signinmanager
                    var signInResult = await _signInManager.PasswordSignInAsync(user, player.Password, false, false);

                    //if sign in with signinmanager succeeded, go back to homepage
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }

            }

            //if login failed, just return the same page
            return View();
        }
        
        //Register
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(Player player)
        {

            //not valid because not all fields are returned in 'player'
            if (ModelState.IsValid)
            {
                
                
                
                
                //create new user for in the cookie - to store in the browser
                var user = new IdentityUser()
                {
                    UserName = player.Name
                };

                //create new cookie and store the username+password combo in the cookie and save cookie in the browser
                var result = await _userManager.CreateAsync(user, player.Password);

                if (result.Succeeded)
                {
                    //sign in with signinmanager
                    var signInResult = await _signInManager.PasswordSignInAsync(user, player.Password, false, false);

                    //if sign in with signinmanager succeeded, go back to homepage
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                
                }
            }
            
            
            //if registering failed, just return the same page
            return View();
        }

        //Log out
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}