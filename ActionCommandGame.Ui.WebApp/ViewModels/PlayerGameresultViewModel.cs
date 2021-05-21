using ActionCommandGame.Model;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Ui.WebApp.ViewModels
{
    public class PlayerGameresultViewModel
    {
        public Player CurrentPlayer { get; set; }
        public ServiceResult<GameResult> Result { get; set; }
    }
}