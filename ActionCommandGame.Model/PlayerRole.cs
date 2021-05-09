using Microsoft.AspNetCore.Identity;

namespace ActionCommandGame.Model
{
    public class PlayerRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }
}