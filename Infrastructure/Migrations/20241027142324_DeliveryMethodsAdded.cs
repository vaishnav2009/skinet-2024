using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryMethodsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if the table 'DeliveryMethods' exists, and create it if it doesn't
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DeliveryMethods')
                BEGIN
                    CREATE TABLE [DeliveryMethods] (
                        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        [ShortName] NVARCHAR(MAX) NOT NULL,
                        [DeliveryTime] NVARCHAR(MAX) NOT NULL,
                        [Description] NVARCHAR(MAX) NOT NULL,
                        [Price] DECIMAL(18,2) NOT NULL
                    );
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the table if it exists
            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.DeliveryMethods', 'U') IS NOT NULL
                BEGIN
                    DROP TABLE [DeliveryMethods];
                END
            ");
        }
    }
}
