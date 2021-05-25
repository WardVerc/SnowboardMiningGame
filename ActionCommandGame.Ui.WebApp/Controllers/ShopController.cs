using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Ui.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;

        public ShopController(IItemService itemService, IPlayerService playerService, IGameService gameService)
        {
            _itemService = itemService;
            _playerService = playerService;
            _gameService = gameService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            //Get all items, sorted by Price
            var allItems = _itemService.Find().OrderBy(i=>i.Price).ToList();
            
            //Get current logged in player
            var currentPlayer = _playerService.Find().SingleOrDefault(p => User.Identity != null && p.Name == User.Identity.Name);

            if (currentPlayer != null)
            {
                var model = new ItemsShopViewModel()
                {
                    AllItems = allItems,
                    CurrentPlayer = currentPlayer,
                    ItemId = 0,
                    CurrentPlayerId = currentPlayer.Id
                };
                return View(model);
            }
            
            //need errorhandling instead of redirecting to home
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Index(ItemsShopViewModel model)
        {
            if (model.ItemId != 0 && model.CurrentPlayerId != 0)
            {
                var result = _gameService.Buy(model.CurrentPlayerId, model.ItemId);
                
            }
            return RedirectToAction("Index");
        }
    }
}