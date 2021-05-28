using System;
using System.Collections.Generic;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Helpers;

namespace ActionCommandGame.Services
{
    public class PositiveGameEventService: IPositiveGameEventService
    {
        private readonly ActionButtonGameDbContext _database;

        public PositiveGameEventService(ActionButtonGameDbContext database)
        {
            _database = database;
        }

        public PositiveGameEvent Get(int id)
        {
            return _database.PositiveGameEvents.SingleOrDefault(i => i.Id == id);
        }

        public PositiveGameEvent GetRandomPositiveGameEvent(bool hasAttackItem)
        {
            var query = _database.PositiveGameEvents.AsQueryable();

            //If we don't have an attack item, we can only get low-reward items.
            if (!hasAttackItem)
            {
                query = query.Where(p => p.Money < 50);
            }

            var gameEvents = query.ToList();

            return GameEventHelper.GetRandomPositiveGameEvent(gameEvents);
        }

        public IList<PositiveGameEvent> Find()
        {
            return _database.PositiveGameEvents.ToList();
        }

        public PositiveGameEvent Create(PositiveGameEvent gameEvent)
        {
            //check if event already is in db
            var searchEvent = _database.PositiveGameEvents.SingleOrDefault(p => p.Name == gameEvent.Name);

            if (searchEvent != null)
            {
                Console.Write(gameEvent.Name + " is already in the db!");
                
                //return same object
                return gameEvent;
            }
            else
            {
                //save in db
                _database.PositiveGameEvents.Add(gameEvent);
                _database.SaveChanges();
                Console.Write("New event added to db: " + gameEvent.Name + ". ");
                
                //return the new event
                return gameEvent;
            }
        }

        public PositiveGameEvent Update(int id, PositiveGameEvent gameEvent)
        {
            if (_database.PositiveGameEvents.Count(i => i.Name == gameEvent.Name) > 1)
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
                    dbEvent.Money = gameEvent.Money;
                    dbEvent.Experience = gameEvent.Experience;
                    dbEvent.Probability = gameEvent.Probability;

                    _database.PositiveGameEvents.Update(dbEvent);
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
                _database.PositiveGameEvents.Remove(searchEvent);
                _database.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
