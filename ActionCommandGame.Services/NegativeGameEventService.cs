using System;
using System.Collections.Generic;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Helpers;

namespace ActionCommandGame.Services
{
    public class NegativeGameEventService: INegativeGameEventService
    {
        private readonly ActionButtonGameDbContext _database;

        public NegativeGameEventService(ActionButtonGameDbContext database)
        {
            _database = database;
        }

        public NegativeGameEvent Get(int id)
        {
            throw new NotImplementedException();
        }

        public NegativeGameEvent GetRandomNegativeGameEvent()
        {
            var gameEvents = Find();
            return GameEventHelper.GetRandomNegativeGameEvent(gameEvents);
        }

        public IList<NegativeGameEvent> Find()
        {
            return _database.NegativeGameEvents.ToList();
        }

        public NegativeGameEvent Create(NegativeGameEvent gameEvent)
        {
            //check if event already is in db
            var searchEvent = _database.NegativeGameEvents.SingleOrDefault(p => p.Name == gameEvent.Name);

            if (searchEvent != null)
            {
                Console.Write(gameEvent.Name + " is already in the db!");
                
                //return same object
                return gameEvent;
            }
            else
            {
                //save in db
                _database.NegativeGameEvents.Add(gameEvent);
                _database.SaveChanges();
                Console.Write("New event added to db: " + gameEvent.Name + ". ");
                
                //return the new event
                return gameEvent;
            }
        }

        public NegativeGameEvent Update(int id, NegativeGameEvent gameEvent)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
