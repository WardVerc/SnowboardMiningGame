using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ActionCommandGame.Model.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace ActionCommandGame.Model
{
    public class Player: IdentityUser
    {
        //this model is only for front end purposes, no db involved here
        public Player()
        {
            Inventory = new List<PlayerItem>();
        }

        public new int Id { get; set; }
        
        [Display(Name = "Player's name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Length of name must be in range of 4-20.")]
        public string Name { get; set; }
        
        //password only needed for front end 
        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Length of password must be in range of 4-20.")]
        public string Password { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        public DateTime LastActionExecutedDateTime { get; set; }

        public int? CurrentFuelPlayerItemId { get; set; }
        public PlayerItem CurrentFuelPlayerItem { get; set; }
        public int? CurrentAttackPlayerItemId { get; set; }
        public PlayerItem CurrentAttackPlayerItem { get; set; }
        public int? CurrentDefensePlayerItemId { get; set; }
        public PlayerItem CurrentDefensePlayerItem { get; set; }

        public IList<PlayerItem> Inventory { get; set; }

    }
}
