using System.Linq;
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

        public ShopController(IItemService itemService, IPlayerService playerService)
        {
            _itemService = itemService;
            _playerService = playerService;
        }
        [Authorize]
        public IActionResult Index()
        {
            //Get all items, sorted by Price
            var allItems = _itemService.Find().OrderBy(i=>i.Price).ToList();
            var currentPlayer = _playerService.Find().SingleOrDefault(p => User.Identity != null && p.Name == User.Identity.Name);
            
            var model = new ItemsShopViewModel()
            {
                AllItems = allItems,
                CurrentPlayer = currentPlayer
            };
            return View(model);
        }
    }
}