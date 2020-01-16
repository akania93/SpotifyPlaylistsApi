using Microsoft.EntityFrameworkCore.Migrations;

namespace SpotifyPlaylistsApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaylistCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Favourite = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DurationMs = table.Column<long>(nullable: false),
                    ExternalUrlSpotify = table.Column<string>(nullable: true),
                    PreviewUrl = table.Column<string>(nullable: true),
                    PlaylistsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ExternalUrlSpotify = table.Column<string>(nullable: true),
                    TracksId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Tracks_TracksId",
                        column: x => x.TracksId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1L, "Blues" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2L, "Country" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 3L, "Disco polo" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 4L, "Elektroniczna" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 5L, "Folk" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 6L, "Filmowa" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 7L, "Hip-hop" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 8L, "Jazz" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 9L, "Metal" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 10L, "Pop" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 11L, "Poważna" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 12L, "Reggae" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 13L, "Rock" });

            migrationBuilder.InsertData(
                table: "PlaylistCategories",
                columns: new[] { "Id", "Value" },
                values: new object[] { 14L, "Inne" });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_TracksId",
                table: "Artists",
                column: "TracksId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PlaylistsId",
                table: "Tracks",
                column: "PlaylistsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "PlaylistCategories");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
