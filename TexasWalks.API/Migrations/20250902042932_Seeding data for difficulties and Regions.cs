using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TexasWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatafordifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2741d36f-4932-4448-8f78-ab458f163fad"), "Medium" },
                    { new Guid("3dcf8f49-d451-4c87-a270-365c1da9d2c1"), "Easy" },
                    { new Guid("6ace00c4-4ac4-4b69-b832-965438d482c0"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0b42603b-e20a-4365-9996-042057541580"), "WGN", "Wellington", "image.jpg" },
                    { new Guid("132f75be-ab4c-460a-821e-149e7899c5b9"), "BOP", "Bay Of Plenty", "image.jpg" },
                    { new Guid("2ff57e7d-2a87-4038-92b3-6907fd9f3da6"), "STL", "Southland", "image.jpg" },
                    { new Guid("8a34d69b-e451-489b-b37a-830687ca47d8"), "NSN", "Nelson", "image.jpg" },
                    { new Guid("f6874358-c635-4b21-a401-b5c3f6eafec2"), "NTL", "Northland",null},
                    { new Guid("f959f132-ff89-4ca5-a870-b6e5b4eec0c4"), "COP", "Coppel", "image.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2741d36f-4932-4448-8f78-ab458f163fad"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3dcf8f49-d451-4c87-a270-365c1da9d2c1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6ace00c4-4ac4-4b69-b832-965438d482c0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0b42603b-e20a-4365-9996-042057541580"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("132f75be-ab4c-460a-821e-149e7899c5b9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2ff57e7d-2a87-4038-92b3-6907fd9f3da6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8a34d69b-e451-489b-b37a-830687ca47d8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f6874358-c635-4b21-a401-b5c3f6eafec2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f959f132-ff89-4ca5-a870-b6e5b4eec0c4"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Easy" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), "Medium" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", "image.jpg" },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", "image.jpg" },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "image.jpg" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "image.jpg" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", "image.jpg" },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "COP", "Coppel", "image.jpg" }
                });
        }
    }
}
