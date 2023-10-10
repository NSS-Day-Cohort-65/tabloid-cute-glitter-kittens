using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tabloid.Models;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Data;
public class TabloidDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReaction> PostReactions { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public TabloidDbContext(DbContextOptions<TabloidDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                UserName = "JohnDoe",
                Email = "john@doe.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                UserName = "JaneSmith",
                Email = "jane@smith.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                UserName = "AliceJohnson",
                Email = "alice@johnson.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                UserName = "BobWilliams",
                Email = "bob@williams.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                UserName = "EveDavis",
                Email = "Eve@Davis.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

        });
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
            },

        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                ImageLocation = "https://robohash.org/numquamutut.png?size=150x150&set=set1",
                CreateDateTime = new DateTime(2022, 1, 25),
                IsActive = true
            },
             new UserProfile
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                CreateDateTime = new DateTime(2023, 2, 2),
                ImageLocation = "https://robohash.org/nisiautemet.png?size=150x150&set=set1",
                IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                IsActive = true
            },
            new UserProfile
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Smith",
                CreateDateTime = new DateTime(2022, 3, 15),
                ImageLocation = "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1",
                IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                IsActive = true
            },
            new UserProfile
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Johnson",
                CreateDateTime = new DateTime(2023, 6, 10),
                ImageLocation = "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1",
                IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                IsActive = true
            },
            new UserProfile
            {
                Id = 5,
                FirstName = "Bob",
                LastName = "Williams",
                CreateDateTime = new DateTime(2023, 5, 15),
                ImageLocation = "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1",
                IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                IsActive = true
            },
            new UserProfile
            {
                Id = 6,
                FirstName = "Eve",
                LastName = "Davis",
                CreateDateTime = new DateTime(2022, 10, 18),
                ImageLocation = "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1",
                IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                IsActive = true
            }
        });
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category{ Id = 1, Name = "Promotional"},
            new Category{ Id = 2, Name = "Informative"},
            new Category{ Id = 3, Name = "Personal"},
        });
        modelBuilder.Entity<Post>().HasData(new Post[]
        {
            new Post{ Id = 1, Title = "David has Fun in the Sun", Content ="Spent the day at the beach with my cat friends. 🏖️ Perfect weather and even better company! ☀️😄😾", ImageLocation="", CreateDateTime = DateTime.Now, CategoryId = 3, UserProfileId = 1},
            new Post{ Id = 2, Title = "Flash Sale Alert!", Content ="Huge discounts this weekend only at John's Cat Cabana! Grab your favorite items right meow at 30% off. Don't miss out! 💥🛍️😾", ImageLocation="", CreateDateTime = DateTime.Now, CategoryId = 1, UserProfileId = 2},
            new Post{ Id = 3, Title = "Healthy Eating Tips", Content ="Did you know that eating some fruits and vegetables can make you sick? Learn more about the benefits of a balanced diet in our latest blog post. Link in bio! Cats like watermelon 🥦🍎😾", ImageLocation="", CreateDateTime = DateTime.Now, CategoryId = 2, UserProfileId = 3},
            new Post{ Id = 4, Title = "The Benefits of Cat Ownership", Content ="Did you know that having a cat can reduce stress and increase happiness? Learn more about the perks of being a cat parent in our blog post. Link in bio! 🐾😻", ImageLocation="", CreateDateTime = DateTime.Now, CategoryId = 2, UserProfileId = 4},
        });
        modelBuilder.Entity<Tag>().HasData(new Tag[]
        {
            new Tag { Id = 1, Name = "CatLovers" },
            new Tag { Id = 2, Name = "Caturday" },
            new Tag { Id = 3, Name = "MeowMonday" },
            new Tag { Id = 4, Name = "PawsAndWhiskers" },
            new Tag { Id = 5, Name = "FelineFriends" },
            new Tag { Id = 6, Name = "CatLife" },
            new Tag { Id = 7, Name = "KittyLove" },
            new Tag { Id = 8, Name = "CatsofInstagram" },
            new Tag { Id = 9, Name = "Purrfect" },
            new Tag { Id = 10, Name = "CatNap" },
            new Tag { Id = 11, Name = "CatAdventures" },
            new Tag { Id = 12, Name = "CatObsessed" },
            new Tag { Id = 13, Name = "CatMom" },
            new Tag { Id = 14, Name = "CatDad" },
            new Tag { Id = 15, Name = "CatsOfTheWorld" },
            new Tag { Id = 16, Name = "CuteCats" },
            new Tag { Id = 17, Name = "FluffyFriends" },
            new Tag { Id = 18, Name = "KittenLove" },
            new Tag { Id = 19, Name = "WhiskerWednesday" },
            new Tag { Id = 20, Name = "FurryFamily" },
            new Tag { Id = 21, Name = "CatPhotography" },
            new Tag { Id = 22, Name = "CatBehavior" },
            new Tag { Id = 23, Name = "CatRescue" },
            new Tag { Id = 24, Name = "CatHealth" },
            new Tag { Id = 25, Name = "CatArt" },
            new Tag { Id = 26, Name = "Kevin" }
        });
        modelBuilder.Entity<Reaction>().HasData(new Reaction[]
        {
            new Reaction { Id = 1, Name = "Angry", ImageLocation = "https://www.pngarts.com/files/1/Angry-Cat-PNG-Pic.png"},
            new Reaction { Id = 2, Name = "Happy", ImageLocation = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/cbf84343-a8e7-43dd-93c9-de1278dca06c/d4ldn24-0317e21d-5971-4910-906a-acb3897c322f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwic3ViIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsImF1ZCI6WyJ1cm46c2VydmljZTpmaWxlLmRvd25sb2FkIl0sIm9iaiI6W1t7InBhdGgiOiIvZi9jYmY4NDM0My1hOGU3LTQzZGQtOTNjOS1kZTEyNzhkY2EwNmMvZDRsZG4yNC0wMzE3ZTIxZC01OTcxLTQ5MTAtOTA2YS1hY2IzODk3YzMyMmYucG5nIn1dXX0.Wqr8xFVHc5cegbsHK39-VgAHVglzjAgf85TxPwCXaas"},
            new Reaction { Id = 3, Name = "Sad", ImageLocation = "https://cdn3.emoji.gg/emojis/9109_Sad_Cat_Thumbs_Up.png"},
            new Reaction { Id = 4, Name = "Hungry", ImageLocation="https://cdn3.iconfinder.com/data/icons/cat-power-premium/120/cat_sing-1024.png"}
        });
        modelBuilder.Entity<Subscription>().HasData(new Subscription[]
        {
            new Subscription { Id = 1, ProviderUserProfileId = 1, SubscriberUserProfileId = 2, BeginDateTime = DateTime.Now},
            new Subscription { Id = 2, ProviderUserProfileId = 2, SubscriberUserProfileId = 1, BeginDateTime = DateTime.Now},
            new Subscription { Id = 3, ProviderUserProfileId = 4, SubscriberUserProfileId = 3, BeginDateTime = DateTime.Now},
        });
        modelBuilder.Entity<PostReaction>().HasData(new PostReaction[]
        {
            new PostReaction { Id = 1, PostId = 1, ReactionId = 1, UserProfileId = 4 },
            new PostReaction { Id = 2, PostId = 4, ReactionId = 2, UserProfileId = 2 },
            new PostReaction { Id = 3, PostId = 3, ReactionId = 4, UserProfileId = 3 },
            new PostReaction { Id = 4, PostId = 2, ReactionId = 3, UserProfileId = 1 },
        });
        modelBuilder.Entity<PostTag>().HasData(new PostTag[]
        {
            new PostTag { Id = 1, PostId = 1, TagId = 1},
            new PostTag { Id = 2, PostId = 2, TagId = 7},
            new PostTag { Id = 3, PostId = 3, TagId = 25},
            new PostTag { Id = 4, PostId = 4, TagId = 26},
        });
    }
}