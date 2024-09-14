using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delete_at",
                schema: "blog",
                table: "post_file");

            migrationBuilder.DropColumn(
                name: "uploaded_at",
                schema: "blog",
                table: "post_file");

            migrationBuilder.DropColumn(
                name: "delete_at",
                schema: "blog",
                table: "pet_project_file");

            migrationBuilder.DropColumn(
                name: "uploaded_at",
                schema: "blog",
                table: "pet_project_file");

            migrationBuilder.DropColumn(
                name: "delete_at",
                schema: "blog",
                table: "certificate_file");

            migrationBuilder.DropColumn(
                name: "uploaded_at",
                schema: "blog",
                table: "certificate_file");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "blog",
                table: "post_file",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "blog",
                table: "pet_project_file",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "blog",
                table: "certificate_file",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "blog",
                table: "post_file",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "blog",
                table: "pet_project_file",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "blog",
                table: "certificate_file",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_at",
                schema: "blog",
                table: "post_file",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "uploaded_at",
                schema: "blog",
                table: "post_file",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_at",
                schema: "blog",
                table: "pet_project_file",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "uploaded_at",
                schema: "blog",
                table: "pet_project_file",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "delete_at",
                schema: "blog",
                table: "certificate_file",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "uploaded_at",
                schema: "blog",
                table: "certificate_file",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
