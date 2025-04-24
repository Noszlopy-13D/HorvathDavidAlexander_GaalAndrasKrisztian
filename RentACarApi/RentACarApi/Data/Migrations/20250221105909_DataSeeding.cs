using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACarApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hétköznapi" },
                    { 2, "Luxus" },
                    { 3, "Sport" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Benzin" },
                    { 2, "Dízel" },
                    { 3, "Benzin-Hibrid" },
                    { 4, "Dízel-Hibrid" },
                    { 5, "Elektromos" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "BMW" },
                    { 3, "Volkswagen" },
                    { 4, "Audi" },
                    { 5, "Ford" },
                    { 6, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "C-Osztály" },
                    { 2, 1, "E-Osztály" },
                    { 3, 3, "Passat" },
                    { 4, 5, "Focus" },
                    { 5, 6, "Corolla" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "FuelTypeId", "HorsePower", "Km", "ModelId", "PricePerKm", "Year" },
                values: new object[,]
                {
                    { 1, 1, "A Volkswagen Passat egy tágas és kényelmes szedán, ideális hosszabb utakra és városi közlekedésre egyaránt. Gazdaságos fogyasztás, modern technológia és megbízható teljesítmény jellemzi. Automata váltóval, klímával és tágas csomagtérrel rendelkezik, tökéletes választás üzleti és családi utakhoz.", 1, 150, 121322, 3, 50, 2016 },
                    { 2, 1, "A Ford Focus egy dinamikus és megbízható kompakt autó, amely ideális választás városi közlekedéshez és hosszabb utakhoz egyaránt. Alacsony fogyasztás, kényelmes utastér és modern biztonsági felszereltség jellemzi.", 2, 120, 98500, 4, 45, 2018 },
                    { 3, 1, "A Toyota Corolla egy legendásan tartós és gazdaságos modell, amely kiváló vezetési élményt nyújt. Kényelmes beltér, megbízható motor és alacsony fenntartási költségek teszik népszerűvé.", 1, 132, 75000, 5, 48, 2020 },
                    { 4, 2, "A Mercedes E-Osztály egy elegáns és tágas prémium szedán, amely kimagasló komfortot és technológiai innovációt kínál. Automata váltó, bőr belső és fejlett vezetéstámogató rendszerek biztosítják a luxus élményt.", 2, 190, 105000, 2, 80, 2017 },
                    { 5, 3, "A Mercedes C-Osztály sportos megjelenése és erőteljes motorja garantálja a dinamikus vezetési élményt. Kiváló gyorsulás, prémium belső tér és modern technológia jellemzi.", 1, 204, 60200, 1, 100, 2019 },
                    { 6, 3, "A Toyota Corolla hibrid változata környezetbarát és takarékos megoldást kínál azok számára, akik modern és hatékony autót keresnek. Csendes üzemmód, alacsony fogyasztás és megbízható teljesítmény jellemzi.", 3, 180, 50000, 5, 90, 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
