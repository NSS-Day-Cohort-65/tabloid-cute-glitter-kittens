using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tabloid.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageLocation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ImageLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ReactionId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReactions_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ImageLocation = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PublishDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriberUserProfileId = table.Column<int>(type: "integer", nullable: false),
                    ProviderUserProfileId = table.Column<int>(type: "integer", nullable: false),
                    BeginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_UserProfiles_ProviderUserProfileId",
                        column: x => x.ProviderUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_UserProfiles_SubscriberUserProfileId",
                        column: x => x.SubscriberUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "a0dc774e-272d-4593-b5ea-216c972afbff", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", 0, "769ec0ee-0b34-44dd-a82f-e92263337042", "bob@williams.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAENGXk3SmtSJUwYAGe39ApKAQo6/NvuRtk16mB1kpH48q6yPTtAG9lyc2EJU3eHfShg==", null, false, "2461e56c-c6c0-49f0-a1eb-126348a95aa6", false, "BobWilliams" },
                    { "a7d21fac-3b21-454a-a747-075f072d0cf3", 0, "9dd86be4-ef47-47f9-92ff-dc6f95d4e561", "jane@smith.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEFIq3vsJt9BOjS4qh+4sLy1KBjUX3ZWoLUlyrGxicVY13gYdL5A8/xdOumTevZjW7w==", null, false, "1927bf8e-bd6b-49eb-8b6e-37b6eb5ccca0", false, "JaneSmith" },
                    { "c806cfae-bda9-47c5-8473-dd52fd056a9b", 0, "0c49360f-a769-49a9-8167-572ca455b024", "alice@johnson.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEPJtmqOQw/JkYLrdXW5wE/KhtIgvZ+QSZvfOMa7iegi0o07NcYC+ZgtGbmlQY60iRg==", null, false, "e0488f31-1e29-47e3-91c1-f410511be94f", false, "AliceJohnson" },
                    { "d224a03d-bf0c-4a05-b728-e3521e45d74d", 0, "24fbdb26-258c-42d9-82b9-b5de8b2ceb8c", "Eve@Davis.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAENx1jNSCxEu7SQHWpBwUS6jGvy32NMUZOzGzCEoKElv8YYrxRVY5VHHJNIJu/BZ/eA==", null, false, "00b2b0a8-b23d-45de-82fd-5a652f71cbb2", false, "EveDavis" },
                    { "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", 0, "cd8ce6d0-19d2-46ca-a2ae-e6d3ec6f6eef", "john@doe.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEMcUkplK4qia09PkofOjY9EsTC9QN0Il/mbvW2xrTOUrfC+xiShNbjkbjaJX7U7MQg==", null, false, "a1d2e7e3-1e8e-48ab-889c-bb25bcc32f08", false, "JohnDoe" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "ed85cbfc-ae77-459f-9b20-a52d672a8b9c", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAED2sd6QC2Cwe5TSj63MIN1V0G8VIOxoI5Mt6a79G8qR8JkRdVI79Aoq4nu3yGUFsfA==", null, false, "be7f9d5e-0180-4fb6-8d97-899af6c0b8f7", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Promotional" },
                    { 2, "Informative" },
                    { 3, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "ImageLocation", "Name" },
                values: new object[,]
                {
                    { 1, "https://www.pngarts.com/files/1/Angry-Cat-PNG-Pic.png", "Angry" },
                    { 2, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/cbf84343-a8e7-43dd-93c9-de1278dca06c/d4ldn24-0317e21d-5971-4910-906a-acb3897c322f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwic3ViIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsImF1ZCI6WyJ1cm46c2VydmljZTpmaWxlLmRvd25sb2FkIl0sIm9iaiI6W1t7InBhdGgiOiIvZi9jYmY4NDM0My1hOGU3LTQzZGQtOTNjOS1kZTEyNzhkY2EwNmMvZDRsZG4yNC0wMzE3ZTIxZC01OTcxLTQ5MTAtOTA2YS1hY2IzODk3YzMyMmYucG5nIn1dXX0.Wqr8xFVHc5cegbsHK39-VgAHVglzjAgf85TxPwCXaas", "Happy" },
                    { 3, "https://cdn3.emoji.gg/emojis/9109_Sad_Cat_Thumbs_Up.png", "Sad" },
                    { 4, "https://cdn3.iconfinder.com/data/icons/cat-power-premium/120/cat_sing-1024.png", "Hungry" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CatLovers" },
                    { 2, "Caturday" },
                    { 3, "MeowMonday" },
                    { 4, "PawsAndWhiskers" },
                    { 5, "FelineFriends" },
                    { 6, "CatLife" },
                    { 7, "KittyLove" },
                    { 8, "CatsofInstagram" },
                    { 9, "Purrfect" },
                    { 10, "CatNap" },
                    { 11, "CatAdventures" },
                    { 12, "CatObsessed" },
                    { 13, "CatMom" },
                    { 14, "CatDad" },
                    { 15, "CatsOfTheWorld" },
                    { 16, "CuteCats" },
                    { 17, "FluffyFriends" },
                    { 18, "KittenLove" },
                    { 19, "WhiskerWednesday" },
                    { 20, "FurryFamily" },
                    { 21, "CatPhotography" },
                    { 22, "CatBehavior" },
                    { 23, "CatRescue" },
                    { 24, "CatHealth" },
                    { 25, "CatArt" },
                    { 26, "Kevin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 7 },
                    { 3, 3, 25 },
                    { 4, 4, 26 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "CreateDateTime", "FirstName", "IdentityUserId", "ImageLocation", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "https://robohash.org/numquamutut.png?size=150x150&set=set1", "Strator" },
                    { 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", "https://robohash.org/nisiautemet.png?size=150x150&set=set1", "Doe" },
                    { 3, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "a7d21fac-3b21-454a-a747-075f072d0cf3", "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1", "Smith" },
                    { 4, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "c806cfae-bda9-47c5-8473-dd52fd056a9b", "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1", "Johnson" },
                    { 5, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1", "Williams" },
                    { 6, new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eve", "d224a03d-bf0c-4a05-b728-e3521e45d74d", "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "PostReactions",
                columns: new[] { "Id", "PostId", "ReactionId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, 1, 4 },
                    { 2, 4, 2, 2 },
                    { 3, 3, 4, 3 },
                    { 4, 2, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreateDateTime", "ImageLocation", "IsApproved", "PublishDateTime", "Title", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 3, "Spent the day at the beach with my cat friends. 🏖️ Perfect weather and even better company! ☀️😄😾", new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(906), "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David has Fun in the Sun", 1 },
                    { 2, 1, "Huge discounts this weekend only at John's Cat Cabana! Grab your favorite items right meow at 30% off. Don't miss out! 💥🛍️😾", new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(941), "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flash Sale Alert!", 2 },
                    { 3, 2, "Did you know that eating some fruits and vegetables can make you sick? Learn more about the benefits of a balanced diet in our latest blog post. Link in bio! Cats like watermelon 🥦🍎😾", new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(943), "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Healthy Eating Tips", 3 },
                    { 4, 2, "Did you know that having a cat can reduce stress and increase happiness? Learn more about the perks of being a cat parent in our blog post. Link in bio! 🐾😻", new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(945), "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Benefits of Cat Ownership", 4 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "ProviderUserProfileId", "SubscriberUserProfileId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(991), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, new DateTime(2023, 10, 9, 13, 27, 45, 829, DateTimeKind.Local).AddTicks(1001), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserProfileId",
                table: "Comments",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_ReactionId",
                table: "PostReactions",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_UserProfileId",
                table: "PostReactions",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserProfileId",
                table: "Posts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ProviderUserProfileId",
                table: "Subscriptions",
                column: "ProviderUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriberUserProfileId",
                table: "Subscriptions",
                column: "SubscriberUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
