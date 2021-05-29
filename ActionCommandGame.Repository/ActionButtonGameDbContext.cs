using ActionCommandGame.Model;
using ActionCommandGame.Repository.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Repository
{
    public class ActionButtonGameDbContext: IdentityDbContext
    {
        public ActionButtonGameDbContext(DbContextOptions<ActionButtonGameDbContext> options): base(options)
        {
            
        }

        public DbSet<PositiveGameEvent> PositiveGameEvents { get; set; }
        public DbSet<NegativeGameEvent> NegativeGameEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureRelationships();

            base.OnModelCreating(modelBuilder);
        }

        public void Initialize()
        {
            GeneratePositiveGameEvents();
            GenerateNegativeGameEvents();
            GenerateAttackItems();
            GenerateDefenseItems();
            GenerateFoodItems();
            GenerateDecorativeItems();

            //God Mode Item
            Items.Add(new Item
            {
                Name = "GOD MODE",
                Description = "This is almost how a GOD must feel.",
                Attack = 1000000,
                Defense = 1000000,
                Fuel = 1000000,
                ActionCooldownSeconds = 1,
                Price = 10000000
            });

            Players.Add(new Player { Name = "Jimmy B", Money = 100 });
            Players.Add(new Player { Name = "Firmin Crets", Money = 100000, Experience = 2000 });
            Players.Add(new Player { Name = "Filip Mars", Money = 500, Experience = 5 });
            Players.Add(new Player { Name = "Ronny King", Money = 12345, Experience = 200 });

            SaveChanges();
        }

        private void GeneratePositiveGameEvents()
        {
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "An average slope on an average day", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The biggest jump you ever saw", Description = "You chickend out and boarded next to it, watching actual cool snowboarders do sick tricks on the jump. Your eyes start to water up and you ride home.", Probability = 500 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A lot of mist, no boarding this time, but you play boardgames inside the chalet", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A regular backpack", Description = "You hold it to the light and seek in it to find the name of the owner, but it remains empty. You give it to your friend as a gift, the bag was ugly anyway.", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Snow", Description = "Woohoo! Snow!", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A euro on the skilift", Money = 1, Experience = 1, Probability = 2000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A colorful hat that is not your size", Money = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Nobody, you're the first one on the slope. Going down the slope clearing your head", Money = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A fresh prepared slope. So smooth", Money = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "An epic trick your friend landed after 42 tries and you were filming. The clip is awesome", Money = 5, Experience = 3, Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A flat part of the slope. You stand on the back of your board on one leg. Balance increases", Money = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "One snowboard boot. Where's the other one?", Money = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "10 euros on the floor of the bathroom at the apres ski", Money = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A swiss knife. Looks new", Money = 12, Experience = 6, Probability = 700 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Sunglasses that are too small for your head", Money = 20, Experience = 8, Probability = 650 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Warm ski gloves. Too bad they're not your size, you sell them", Money = 30, Experience = 10, Probability = 500 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A friend who bets you couldn't do a backflip. But you did. Showoff", Money = 50, Experience = 13, Probability = 400 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A long rail. You grind it halfway until you lost your balance. Only 1 bruise, nice", Money = 60, Experience = 15, Probability = 400 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A small jump. You do a frontflip off of it. Easy", Money = 100, Experience = 40, Probability = 350 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A halfpipe. You go for it and do pretty okay all the way, no bruises this time", Money = 140, Experience = 50, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A badass coat. You look fly now", Money = 160, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A trumpet. Not sure how it got here", Money = 160, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A bottle of champagne", Money = 180, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A really cool snowboard with stickers and stuff", Money = 300, Experience = 100, Probability = 110 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The other snowboard boot!", Money = 300, Experience = 100, Probability = 80 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A Charizard Pokémon card in good condition", Money = 400, Experience = 150, Probability = 200 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Your future girlfriend/boyfriend", Money = 500, Experience = 150, Probability = 150 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Seppe Smits giving you a high five after you did a 720 Triple McTwist", Money = 1000, Experience = 200, Probability = 100 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The elixir of snowboarding superpowers", Money = 60000, Experience = 1500, Probability = 5 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The snowboard of the legend, Shaun White", Money = 3000, Experience = 400, Probability = 30 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A brand new Go Pro camera that is not released yet", Money = 2000, Experience = 350, Probability = 30 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The key to a mansion in the middle of the slopes, with a pool and sauna. Aww yeeea", Money = 20000, Experience = 1000, Probability = 10 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The biggest jump again, but now you don't think, you just do. And you landed the dopest trick while everybody was watching from the apres ski. You're a legend now and everybody loves you for eternity.", Money = 30000, Experience = 1500, Probability = 10 });
        }

        public void GenerateNegativeGameEvents()
        {
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Bottle leak",
                Description = "As you are sitting on the skilift, you feel your backpack is getting wet because your bottle of water is leaking",
                DefenseWithGearDescription = "Your snowboard gear is waterproof and you just feel a bit cold",
                DefenseWithoutGearDescription = "Your clothes are frozen to your back. You pull your clothes from your skin. Ouch!",
                DefenseLoss = 2,
                Probability = 100
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Skilift exit",
                Description = "As you are coming to the exit of the skilift, you didn't expect the lift to go this fast and the person next to you is swinging his arms",
                DefenseWithGearDescription = "With your Matrix-like moves (and your gear), you keep your balance while the others of the skilift fall down",
                DefenseWithoutGearDescription = "The person next to you hits you in the face by accident and you all fall. People are mad because you guys are blocking the exit",
                DefenseLoss = 3,
                Probability = 50
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Ice spot",
                Description = "As you are boarding, you hear noise coming from under your board and you start to slip",
                DefenseWithGearDescription = "Your gear prevents you from falling and you keep sliding. You continue on the snow",
                DefenseWithoutGearDescription = "You lose your balance and you fell on your butt on the hard ice. That hurt!",
                DefenseLoss = 2,
                Probability = 100
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Failed trick attempt",
                Description = "As you are approaching a big jump, you legs start to wiggle and you  can't avoid the jump anymore",
                DefenseWithGearDescription = "You land on your back but the backplate of your gear caught the fall. You walk away like it was nothing",
                DefenseWithoutGearDescription = "You land on your back. That looked painful",
                DefenseLoss = 3,
                Probability = 50
            });
        }

        private void GenerateAttackItems()
        {
            Items.Add(new Item { Name = "Basic snowboard", Attack = 50, Price = 50 });
            Items.Add(new Item { Name = "Basic snowboard with flames on it", Attack = 300, Price = 300 });
            Items.Add(new Item { Name = "Turbo snowboard with boosters", Attack = 500, Price = 500 });
            Items.Add(new Item { Name = "Special snowboard with auto-balancer and nitro", Attack = 5000, Price = 15000 });
            Items.Add(new Item { Name = "Diamond snowboard with the smoothest surface", Attack = 50, Price = 1000000 });
        }

        private void GenerateDefenseItems()
        {
            Items.Add(new Item { Name = "Secondhand worn smelly snowboardgear", Defense = 20, Price = 20 });
            Items.Add(new Item { Name = "Snowboardgear from your cousin", Defense = 150, Price = 200 });
            Items.Add(new Item { Name = "Basic snowboardgear. And a helmet!", Defense = 500, Price = 1000 });
            Items.Add(new Item { Name = "Cool snowboardgear. Looking fly", Defense = 2000, Price = 10000 });
            Items.Add(new Item { Name = "Burton snowboardsuit with temperature regulator", Defense = 2000, Price = 10000 });
            Items.Add(new Item { Name = "Versace snowboard outfit. Most stylish gear of the slopes", Defense = 20000, Price = 10000 });
        }

        private void GenerateFoodItems()
        {
            Items.Add(new Item { Name = "Coca cola", ActionCooldownSeconds = 50, Fuel = 4, Price = 8 });
            Items.Add(new Item { Name = "Energy Bar", ActionCooldownSeconds = 45, Fuel = 5, Price = 10 });
            Items.Add(new Item { Name = "Energy drinks - six pack", ActionCooldownSeconds = 30, Fuel = 30, Price = 300 });
            Items.Add(new Item { Name = "Pizza", ActionCooldownSeconds = 25, Fuel = 100, Price = 500 });
            Items.Add(new Item { Name = "Gourmet", ActionCooldownSeconds = 25, Fuel = 100, Price = 500 });
            Items.Add(new Item { Name = "All you can eat sushi", ActionCooldownSeconds = 15, Fuel = 500, Price = 10000 });
#if DEBUG
            Items.Add(new Item { Name = "Developer Food", ActionCooldownSeconds = 1, Fuel = 1000, Price = 1 });
#endif
        }

        private void GenerateDecorativeItems()
        {
            Items.Add(new Item { Name = "Rubiks cube", Description = "You can solve it while waiting in the skilift.", Price = 10 });
            Items.Add(new Item { Name = "Beer pong set", Description = "If you're planning to have a party.", Price = 20 });
            Items.Add(new Item { Name = "Cosy slippers in the shape of Homer Simpson", Description = "Makes you feel cosy in the chalet.", Price = 30 });
            Items.Add(new Item { Name = "Big ass boombox", Description = "That's loud.", Price = 1000 });
        }

    }
}
