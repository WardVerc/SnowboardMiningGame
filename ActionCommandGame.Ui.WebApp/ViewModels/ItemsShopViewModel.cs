using System.Collections.Generic;
using ActionCommandGame.Model;

namespace ActionCommandGame.Ui.WebApp.ViewModels
{
    public class ItemsShopViewModel
    {
        public IList<Item> AllItems { get; set; }
        public Player CurrentPlayer { get; set; }
        public int ItemId { get; set; }
        public int CurrentPlayerId { get; set; }
    }
}