﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ActionCommandGame.Model;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Ui.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        public Player currentPlayer;
        
        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IPlayerService playerService, IGameService gameService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _playerService = playerService;
            _gameService = gameService;
        }

        //Authorize, so this page is only accessable when user is logged in
        //logged in = cookie is found with correct user+password combo
        //is done via app.UseAuthentication() in Startup.cs
        [Authorize]
        public IActionResult Index()
        {
            
            return View();
        }
        
        public IActionResult HitButton()
        {
            if (currentPlayer == null)
            {
                //get player from db (dont have id, so can't use Get() in playerService
                var dbPlayer = _playerService.Find().SingleOrDefault(p => p.Name == User.Identity.Name);
                        
                //set currentPlayer to this Player
                currentPlayer = dbPlayer;
            }
            
            //PerformAction and get the result from it
            var result = _gameService.PerformAction(currentPlayer.Id);
            
            Console.Write("Knop geklikt: " + result);
            
            
            
            //update currentPlayer
            
            //show result also on Index View

            return RedirectToAction("Index");
        }
        
        
        
        /* Logging in/out and Registering section */
        
        //Show log in page
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(PlayerViewModel player)
        {

            if (ModelState.IsValid)
            {
                //get the user via usermanager (= cookie stored in browser)
                var user = await _userManager.FindByNameAsync(player.Name);

                if (user != null)
                {
                    //log in with signinmanager
                    var signInResult = await _signInManager.PasswordSignInAsync(user, player.Password, false, false);

                    //if log in with signinmanager succeeded, go back to homepage
                    //and also set the currentPlayer to the logged in Player
                    if (signInResult.Succeeded)
                    {
                        //get player from db (dont have id, so can't use Get() in playerService
                        var dbPlayer = _playerService.Find().SingleOrDefault(p => p.Name == player.Name);
                        
                        //set currentPlayer to this Player
                        currentPlayer = dbPlayer;
                        
                        Console.Write("Current player's name (logged in): " + currentPlayer.Name + ". ");
                        
                        //go to Home page
                        return RedirectToAction("Index");
                    }
                }

            }

            //if login failed, just return the same page
            return View();
        }
        
        //Show register page
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(PlayerViewModel player)
        {

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
                    //if result succeeded -> no user with this name already exists
                    //so no check on name is needed
                    
                    //log in with signinmanager
                    var signInResult = await _signInManager.PasswordSignInAsync(user, player.Password, false, false);

                    //if log in with signinmanager succeeded, go back to homepage
                    //and also create a new Player
                    //and set currentPlayer to this Player
                    if (signInResult.Succeeded)
                    {
                        //use Create from PlayerService to save in db
                        //validation and filling in fields correctly is done in the service layer
                        var playerModel = new Player()
                        {
                            Name = player.Name
                        };
                        var returnedPlayer = _playerService.Create(playerModel);

                        //set currentPlayer to returnedPlayer
                        currentPlayer = returnedPlayer;
                        Console.Write("Current player's name (registered): " + currentPlayer.Name + ". ");
                        
                        //go to Home page
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