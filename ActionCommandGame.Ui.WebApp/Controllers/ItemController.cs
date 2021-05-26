using System.Linq;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Ui.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
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
    }
}