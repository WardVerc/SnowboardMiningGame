using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Ui.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IPlayerItemService _playerItemService;

        public ItemController(IItemService itemService, IPlayerItemService playerItemService)
        {
            _itemService = itemService;
            _playerItemService = playerItemService;
        }
        
        // GET
        public IActionResult Index()
        {
            //Get all items from db
            var items = _itemService.Find().OrderBy(i=>i.Price).ToList();
            
            var model = new ItemManagementViewModel()
            {
                AllItems = items
            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ItemManagementViewModel model)
        {
            var newItem = model.Item;

            if (newItem != null)
            {
                _itemService.Create(newItem);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            var item = _itemService.Get(itemId);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (item != null)
            {
                _itemService.Update(item.Id, item);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int itemId)
        {
            if (itemId != 0)
            {
                //check if item is equipped by players
                //I put this here in controller instead of itemService.Delete
                // because want to keep services modular
                var playerItems = _playerItemService.FindByItem(itemId);
                if (playerItems.Count > 0)
                {
                    foreach (var playerItem in playerItems)
                    {
                        _playerItemService.Delete(playerItem.Id);
                    }
                }
                _itemService.Delete(itemId);
            }

            return RedirectToAction("Index");
        }
    }
}