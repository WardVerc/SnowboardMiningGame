using System;
using System.Collections.Generic;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;

namespace ActionCommandGame.Services
{
    public class ItemService: IItemService
    {
        private readonly ActionButtonGameDbContext _database;

        public ItemService(ActionButtonGameDbContext database)
        {
            _database = database;
        }

        public Item Get(int id)
        {
            return _database.Items.SingleOrDefault(i => i.Id == id);
        }

        public IList<Item> Find()
        {
            return _database.Items.ToList();
        }

        public Item Create(Item item)
        {
            //check if item already is in db
            var searchItem = _database.Items.SingleOrDefault(p => p.Name == item.Name);

            if (searchItem != null)
            {
                Console.Write(item.Name + " is already in the db!");
                
                //return same object
                return item;
            }
            else
            {
                //save in db
                _database.Items.Add(item);
                _database.SaveChanges();
                Console.Write("New item added to db: " + item.Name + ". ");

                //return the new item
                return item;
            }
        }

        public Item Update(int id, Item item)
        {
            if (_database.Items.Count(i => i.Name == item.Name) > 1)
            {
                Console.Write(item.Name + " is already in the db!");
                
                return item;
            } else
            {
                var dbItem = Get(id);
                if (dbItem != null)
                {
                    dbItem.Name = item.Name;
                    dbItem.Description = item.Description;
                    dbItem.Fuel = item.Fuel;
                    dbItem.Attack = item.Attack;
                    dbItem.Defense = item.Defense;
                    dbItem.Price = item.Price;
                    dbItem.ActionCooldownSeconds = item.ActionCooldownSeconds;

                    _database.Items.Update(dbItem);
                    _database.SaveChanges();
                }
            }

            return item;
        }

        public bool Delete(int id)
        {
            var searchItem = _database.Items.SingleOrDefault(p => p.Id == id);
            if (searchItem != null)
            {
                _database.Items.Remove(searchItem);
                _database.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
