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
            //new player so we only need a name
            //-> name is validated in front end
            
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
                
                //return de nieuwe player
                return newPlayer;
            }
            
            //throw new System.NotImplementedException();
        }

        public Player Update(int id, Player player)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
