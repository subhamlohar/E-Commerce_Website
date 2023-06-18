using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubhamBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class orderHeaderUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PymentDueDate",
                table: "OrderHeaders",
                newName: "PaymentDueDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDueDate",
                table: "OrderHeaders",
                newName: "PymentDueDate");
        }
    }
}
