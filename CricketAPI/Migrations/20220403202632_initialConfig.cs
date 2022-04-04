using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CricketAPI.Migrations
{
    public partial class initialConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Battings",
                keyColumn: "Id",
                keyValue: new Guid("274fe76b-91ad-4ef1-bf07-bd25d8925273"));

            migrationBuilder.DeleteData(
                table: "Battings",
                keyColumn: "Id",
                keyValue: new Guid("be5c0c50-668d-4f55-97ec-bf3dd95bf16f"));

            migrationBuilder.DeleteData(
                table: "Battings",
                keyColumn: "Id",
                keyValue: new Guid("d30fab19-0ac0-4875-9479-15edd6384dae"));

            migrationBuilder.DeleteData(
                table: "Battings",
                keyColumn: "Id",
                keyValue: new Guid("fee0d6c9-0249-4f52-94e6-5cb4686e49b4"));

            migrationBuilder.DeleteData(
                table: "Bowlings",
                keyColumn: "Id",
                keyValue: new Guid("d7678a77-628b-407e-b6a8-c13b8b9de529"));

            migrationBuilder.DeleteData(
                table: "Bowlings",
                keyColumn: "Id",
                keyValue: new Guid("de967516-2d69-4721-a055-1ce917a55fcd"));

            migrationBuilder.DeleteData(
                table: "Bowlings",
                keyColumn: "Id",
                keyValue: new Guid("efe01505-b8b2-4038-aa72-84aa060380a0"));

            migrationBuilder.DeleteData(
                table: "Bowlings",
                keyColumn: "Id",
                keyValue: new Guid("ffecdf7f-dcab-4bef-9e36-e9df5373a01e"));

            migrationBuilder.DeleteData(
                table: "GmeLocations",
                keyColumn: "Id",
                keyValue: new Guid("5074cab6-aabf-460e-a90f-6f982033714d"));

            migrationBuilder.DeleteData(
                table: "GmeLocations",
                keyColumn: "Id",
                keyValue: new Guid("8a327c74-f7f7-4a2b-973e-dd2178d329ee"));

            migrationBuilder.DeleteData(
                table: "GmeLocations",
                keyColumn: "Id",
                keyValue: new Guid("cd8ce9de-84c1-44a6-92e7-42707f78ac8a"));

            migrationBuilder.DeleteData(
                table: "GmeLocations",
                keyColumn: "Id",
                keyValue: new Guid("dd068f1b-30f2-41f4-9e21-2f7ee42fde1b"));

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: new Guid("724966b4-738e-4c6e-a5db-41e77f6a23d5"));

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: new Guid("78717cc7-4111-4414-8303-5d5cbbf52139"));

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: new Guid("89a144e7-e231-4994-8427-0ffe484b4a62"));

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: new Guid("af553dcb-03ae-4d8c-8f64-3a2e90a57c83"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("07950e05-2ac6-4566-bcf4-37a475d134c0"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("31964ae0-bb3e-4f14-b201-8cc64a866f46"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("5e0da44f-0c77-4811-9509-71d3f5a4e055"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("b78f32c7-caa6-4a27-8043-ca8d704d18be"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Date", "Opponent" },
                values: new object[,]
                {
                    { new Guid("b78f32c7-caa6-4a27-8043-ca8d704d18be"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bury" },
                    { new Guid("5e0da44f-0c77-4811-9509-71d3f5a4e055"), new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eccles" },
                    { new Guid("07950e05-2ac6-4566-bcf4-37a475d134c0"), new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Worsley" },
                    { new Guid("31964ae0-bb3e-4f14-b201-8cc64a866f46"), new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilmslow" }
                });

            migrationBuilder.InsertData(
                table: "Battings",
                columns: new[] { "Id", "Boundaries", "GameId", "Out", "Runs", "Sixes" },
                values: new object[,]
                {
                    { new Guid("fee0d6c9-0249-4f52-94e6-5cb4686e49b4"), 5, new Guid("b78f32c7-caa6-4a27-8043-ca8d704d18be"), true, 42, 3 },
                    { new Guid("d30fab19-0ac0-4875-9479-15edd6384dae"), 2, new Guid("5e0da44f-0c77-4811-9509-71d3f5a4e055"), false, 11, 0 },
                    { new Guid("be5c0c50-668d-4f55-97ec-bf3dd95bf16f"), 10, new Guid("07950e05-2ac6-4566-bcf4-37a475d134c0"), true, 72, 2 },
                    { new Guid("274fe76b-91ad-4ef1-bf07-bd25d8925273"), 5, new Guid("31964ae0-bb3e-4f14-b201-8cc64a866f46"), true, 33, 2 }
                });

            migrationBuilder.InsertData(
                table: "Bowlings",
                columns: new[] { "Id", "GameId", "Maidens", "Overs", "Runs", "Wickets" },
                values: new object[,]
                {
                    { new Guid("ffecdf7f-dcab-4bef-9e36-e9df5373a01e"), new Guid("b78f32c7-caa6-4a27-8043-ca8d704d18be"), 1, 6, 34, 3 },
                    { new Guid("de967516-2d69-4721-a055-1ce917a55fcd"), new Guid("5e0da44f-0c77-4811-9509-71d3f5a4e055"), 2, 8, 41, 2 },
                    { new Guid("d7678a77-628b-407e-b6a8-c13b8b9de529"), new Guid("07950e05-2ac6-4566-bcf4-37a475d134c0"), 4, 5, 18, 0 },
                    { new Guid("efe01505-b8b2-4038-aa72-84aa060380a0"), new Guid("31964ae0-bb3e-4f14-b201-8cc64a866f46"), 3, 11, 42, 5 }
                });

            migrationBuilder.InsertData(
                table: "GmeLocations",
                columns: new[] { "Id", "GameId", "Ground", "Home" },
                values: new object[,]
                {
                    { new Guid("dd068f1b-30f2-41f4-9e21-2f7ee42fde1b"), new Guid("b78f32c7-caa6-4a27-8043-ca8d704d18be"), "Whalley Range", true },
                    { new Guid("8a327c74-f7f7-4a2b-973e-dd2178d329ee"), new Guid("5e0da44f-0c77-4811-9509-71d3f5a4e055"), "Bury", false },
                    { new Guid("cd8ce9de-84c1-44a6-92e7-42707f78ac8a"), new Guid("07950e05-2ac6-4566-bcf4-37a475d134c0"), "Worsley", false },
                    { new Guid("5074cab6-aabf-460e-a90f-6f982033714d"), new Guid("31964ae0-bb3e-4f14-b201-8cc64a866f46"), "Whalley Range", true }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "By", "GameId", "Method", "Won" },
                values: new object[,]
                {
                    { new Guid("89a144e7-e231-4994-8427-0ffe484b4a62"), 42, new Guid("b78f32c7-caa6-4a27-8043-ca8d704d18be"), "Runs", true },
                    { new Guid("af553dcb-03ae-4d8c-8f64-3a2e90a57c83"), 7, new Guid("5e0da44f-0c77-4811-9509-71d3f5a4e055"), "Wickets", false },
                    { new Guid("78717cc7-4111-4414-8303-5d5cbbf52139"), 5, new Guid("07950e05-2ac6-4566-bcf4-37a475d134c0"), "Wickets", true },
                    { new Guid("724966b4-738e-4c6e-a5db-41e77f6a23d5"), 110, new Guid("31964ae0-bb3e-4f14-b201-8cc64a866f46"), "Runs", false }
                });
        }
    }
}
