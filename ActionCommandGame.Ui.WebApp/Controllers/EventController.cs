using System;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Ui.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var model = new EventManagementViewModel()
            {
                AllPositiveGameEvents = _positiveGameEventService.Find().OrderByDescending(g => g.Probability).ToList(),
                AllNegativeGameEvents = _negativeGameEventService.Find().OrderByDescending(g => g.Probability).ToList()
            };
            
            return View(model);
        }
        
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditPositive(PositiveGameEvent gameEvent)
        {
            if (gameEvent != null)
            {
                _positiveGameEventService.Update(gameEvent.Id, gameEvent);
            }

            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditNegative(int negativeEventId)
        {
            var searchEvent = _negativeGameEventService.Get(negativeEventId);
            if (searchEvent != null)
            {
                return View(searchEvent);
            }

            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditNegative(NegativeGameEvent gameEvent)
        {
            if (gameEvent != null)
            {
                _negativeGameEventService.Update(gameEvent.Id, gameEvent);
            }

            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin")]
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
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteNegative(int negativeEventId)
        {
            var searchEvent = _negativeGameEventService.Get(negativeEventId);
            if (searchEvent == null)
            {
                Console.Write("Negative event id was not found in db! " + negativeEventId);
            }
            else
            {
                _negativeGameEventService.Delete(negativeEventId);
            }

            return RedirectToAction("Index");
        }
    }
}