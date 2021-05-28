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
            return _database.NegativeGameEvents.SingleOrDefault(i => i.Id == id);
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
            if (_database.NegativeGameEvents.Count(i => i.Name == gameEvent.Name) > 1)
            {
                Console.Write(gameEvent.Name + " is already in the db!");
                
                return gameEvent;
            } else
            {
                var dbEvent = Get(id);
                if (dbEvent != null)
                {
                    dbEvent.Name = gameEvent.Name;
                    dbEvent.Description = gameEvent.Description;
                    dbEvent.DefenseWithGearDescription = gameEvent.DefenseWithGearDescription;
                    dbEvent.DefenseWithoutGearDescription = gameEvent.DefenseWithoutGearDescription;
                    dbEvent.DefenseLoss = gameEvent.DefenseLoss;
                    dbEvent.Probability = gameEvent.Probability;

                    _database.NegativeGameEvents.Update(dbEvent);
                    _database.SaveChanges();
                }
            }

            return gameEvent;
        }

        public bool Delete(int id)
        {
            var searchEvent = Get(id);
            if (searchEvent != null)
            {
                _database.NegativeGameEvents.Remove(searchEvent);
                _database.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
