using System.Collections.Generic;
using ActionCommandGame.Model;

namespace ActionCommandGame.Ui.WebApp.ViewModels
{
    public class EventManagementViewModel
    {
        public IList<PositiveGameEvent> AllPositiveGameEvents { get; set; }
        public IList<NegativeGameEvent> AllNegativeGameEvents { get; set; }
        public int EventId { get; set; }
    }
}