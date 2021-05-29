using System;
using System.Collections.Generic;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Services
{
    public class PlayerService: IPlayerService
    {
        private readonly ActionButtonGameDbContext _database;

        public PlayerService(ActionButtonGameDbContext database)
        {
            _database = database;
        }

        public Player Get(int id)
        {
            return _database.Players
                .Include(p => p.CurrentFuelPlayerItem.Item)
                .Include(p => p.CurrentAttackPlayerItem.Item)
                .Include(p => p.CurrentDefensePlayerItem.Item)
                .SingleOrDefault(p => p.Id == id);
        }

        public IList<Player> Find()
        {
            return _database.Players
                .Include(p => p.CurrentFuelPlayerItem.Item)
                .Include(p => p.CurrentAttackPlayerItem.Item)
                .Include(p => p.CurrentDefensePlayerItem.Item)
                .ToList();
        }

        public Player Create(Player player)
        {
            //check if player already is in db
            var searchPlayer = _database.Players.SingleOrDefault(p => p.Name == player.Name);

            if (searchPlayer != null)
            {
                Console.Write(player.Name + " is already in the db!");
                
                //return same object
                return player;
            }
            else
            {
                //create new player object
                var newPlayer = new Player()
                {
                    Name = player.Name,
                    Money = 0
                };
                
                //save in db
                _database.Players.Add(newPlayer);
                _database.SaveChanges();
                Console.Write("New player added to db: " + newPlayer.Name + ". ");
                
                //return the new player
                return newPlayer;
            }
        }

        public Player Update(int id, Player player)
        {
            //check if new playername already is in db
            var searchPlayer = _database.Players.SingleOrDefault(p => p.Name == player.Name);
            
            if (searchPlayer != null)
            {
                Console.Write(player.Name + " is already in the db!");
                
                //return same object, should be an error message
                return player;
            }
            else
            {
                //get logged in player
                var loggedInPlayer = Get(id);
                
                //edit player properties
                loggedInPlayer.Name = player.Name;
                
                //save in db
                _database.Players.Update(loggedInPlayer);
                _database.SaveChanges();
            
                return loggedInPlayer;
            }
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
