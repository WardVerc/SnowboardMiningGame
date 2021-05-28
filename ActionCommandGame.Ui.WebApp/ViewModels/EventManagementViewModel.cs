using System.Collections.Generic;
using ActionCommandGame.Model;

namespace ActionCommandGame.Ui.WebApp.ViewModels
{
    public class EventManagementViewModel
    {
        public IList<PositiveGameEvent> AllPositiveGameEvents { get; set; }
        public IList<NegativeGameEvent> AllNegativeGameEvents { get; set; }
        public PositiveGameEvent PositiveGameEvent { get; set; }
        public NegativeGameEvent NegativeGameEvent { get; set; }
        public int PositiveEventId { get; set; }
        public int NegativeEventId { get; set; }
    }
}