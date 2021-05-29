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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;

        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IPlayerService playerService, IGameService gameService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _playerService = playerService;
            _gameService = gameService;
            _roleManager = roleManager;
        }

        [Authorize]
        public IActionResult Index(PlayerGameresultViewModel model)
        {
            var currentPlayer = _playerService.Find().SingleOrDefault(p => User.Identity != null && p.Name == User.Identity.Name);
            
            model.CurrentPlayer = currentPlayer;
 
            return View(model);
        }
        
        [Authorize]
        public IActionResult HitButton()
        {
            var currentPlayer = _playerService.Find().SingleOrDefault(p => User.Identity != null && p.Name == User.Identity.Name);

            //PerformAction and get the result from it
            if (currentPlayer != null)
            {
                //perform action
                var result = _gameService.PerformAction(currentPlayer.Id);
                
                //get player stats
                var playerWithStats = _playerService.Get(currentPlayer.Id);

                //show result also on Index View
                var model = new PlayerGameresultViewModel()
                {
                    CurrentPlayer = playerWithStats,
                    Result = result
                };
                
                return View("Index", model);
            }
            
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Leaderboards()
        {
            var playerList = _playerService.Find().OrderByDescending(p => p.Experience).ToList();
            return View(playerList);
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
                //create new user for in the cookie
                var user = new IdentityUser()
                {
                    UserName = player.Name
                };

                //create new cookie and store the username+password combo in the cookie
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
                        _playerService.Create(playerModel);
                        
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
            var currentIdentityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            
            //uncomment following line to add Admin role on Logout
            //await _roleManager.CreateAsync(new IdentityRole("Admin"));

            if (currentIdentityUser != null)
            {
                //uncomment following line to add Admin role on Logout
                //await _userManager.AddToRoleAsync(currentIdentityUser, "Admin");
                
                await _signInManager.SignOutAsync();
            }
            
            return RedirectToAction("Index");
        }
        
        //Edit profile
        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var currentPlayer = _playerService.Find().SingleOrDefault(p => User.Identity != null && p.Name == User.Identity.Name);

            return View(currentPlayer);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(Player newPlayer)
        {
            var currentPlayer = _playerService.Find().SingleOrDefault(p => User.Identity != null && p.Name == User.Identity.Name);
            
            if (currentPlayer != null)
            {
                //get the user via usermanager (= cookie stored in browser)
                var user = await _userManager.FindByNameAsync(currentPlayer.Name);
                
                if (user != null)
                {
                    //update name of Identity
                    user.UserName = newPlayer.Name;
                    user.NormalizedUserName = newPlayer.Name.ToUpper();
                    
                    await _userManager.UpdateAsync(user);
                    
                    //log out
                    await _signInManager.SignOutAsync();
                
                    //update name of Player
                    _playerService.Update(currentPlayer.Id, newPlayer);
                }
            }

            return RedirectToAction("Index");
        }

    }
}