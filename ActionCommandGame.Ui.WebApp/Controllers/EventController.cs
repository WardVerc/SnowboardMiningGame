using System;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Ui.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IPositiveGameEventService _positiveGameEventService;
        private readonly INegativeGameEventService _negativeGameEventService;

        public EventController(IPositiveGameEventService positiveGameEventService,
            INegativeGameEventService negativeGameEventService)
        {
            _positiveGameEventService = positiveGameEventService;
            _negativeGameEventService = negativeGameEventService;
        }
        
        // GET
        public IActionResult Index()
        {
            var model = new EventManagementViewModel()
            {
                AllPositiveGameEvents = _positiveGameEventService.Find().OrderByDescending(g => g.Probability).ToList(),
                AllNegativeGameEvents = _negativeGameEventService.Find().OrderByDescending(g => g.Probability).ToList()
            };
            
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(EventManagementViewModel model)
        {
            if (model.PositiveGameEvent != null)
            {
                _positiveGameEventService.Create(model.PositiveGameEvent);
            }

            if (model.NegativeGameEvent != null)
            {
                _negativeGameEventService.Create(model.NegativeGameEvent);
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPositive(int positiveEventId)
        {
            var searchEvent = _positiveGameEventService.Get(positiveEventId);
            if (searchEvent != null)
            {
                return View(searchEvent);
            }

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult EditPositive(PositiveGameEvent gameEvent)
        {
            if (gameEvent != null)
            {
                _positiveGameEventService.Update(gameEvent.Id, gameEvent);
            }

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult DeletePositive(int positiveEventId)
        {
            var searchEvent = _positiveGameEventService.Get(positiveEventId);
            if (searchEvent == null)
            {
                Console.Write("Positive event id was not found in db! " + positiveEventId);
            }
            else
            {
                _positiveGameEventService.Delete(positiveEventId);
            }

            return RedirectToAction("Index");
        }
    }
}