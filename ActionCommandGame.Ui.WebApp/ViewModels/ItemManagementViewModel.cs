using System.Collections.Generic;
using ActionCommandGame.Model;

namespace ActionCommandGame.Ui.WebApp.ViewModels
{
    public class ItemManagementViewModel
    {
        public IList<Item> AllItems { get; set; }
        public int ItemId { get; set; }
    }
}