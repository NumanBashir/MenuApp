using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApp.Migrations
{
    /// <inheritdoc />
    public partial class updatelinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.arla.com/recordid/028FC826-276D-42A7-8E2E5E1E6F5F13B7/pizza-margherita-med-burrata.jpg?format=jpg&width=1200&height=630&mode=crop&crop=(0,1568,0,-54)");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.allrecipes.com/thmb/XDFvpo7BXQ7_s920fAp28qox0PY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/279460-Old-Bay-Seafood-Boil-ddmfs-139-4x3-aa189a5c09104659957fe6fcb715c4bd.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fmandekogebogen.dk%2Fsalatpizza.1114.html&psig=AOvVaw1oDK58q7KvBsVpSKZrXP32&ust=1718097000159000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCOiZ853Y0IYDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.allrecipes.com%2Frecipe%2F279460%2Fold-bay-seafood-boil%2F&psig=AOvVaw0l5bQBmH_gqs_lfPQ0qZVM&ust=1718097032272000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCOC_1qzY0IYDFQAAAAAdAAAAABAw");
        }
    }
}
