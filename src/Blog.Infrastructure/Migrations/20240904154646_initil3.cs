using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initil3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Users_user_id",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_FileCvs_Users_user_id",
                table: "FileCvs");

            migrationBuilder.DropForeignKey(
                name: "FK_PetProjects_Users_user_id",
                table: "PetProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_user_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_user_id",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetProjects",
                table: "PetProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.EnsureSchema(
                name: "certificate");

            migrationBuilder.EnsureSchema(
                name: "pet_project");

            migrationBuilder.EnsureSchema(
                name: "post");

            migrationBuilder.EnsureSchema(
                name: "token");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "blog",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "blog",
                newSchema: "token");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "blog",
                newSchema: "post");

            migrationBuilder.RenameTable(
                name: "PetProjects",
                newName: "blog",
                newSchema: "pet_project");

            migrationBuilder.RenameTable(
                name: "Certificates",
                newName: "blog",
                newSchema: "certificate");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_user_id",
                schema: "token",
                table: "blog",
                newName: "IX_blog_user_id3");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_user_id",
                schema: "post",
                table: "blog",
                newName: "IX_blog_user_id2");

            migrationBuilder.RenameIndex(
                name: "IX_PetProjects_user_id",
                schema: "pet_project",
                table: "blog",
                newName: "IX_blog_user_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_user_id",
                schema: "certificate",
                table: "blog",
                newName: "IX_blog_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                schema: "user",
                table: "blog",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_expired",
                schema: "token",
                table: "blog",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog",
                schema: "user",
                table: "blog",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog",
                schema: "token",
                table: "blog",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog",
                schema: "post",
                table: "blog",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog",
                schema: "pet_project",
                table: "blog",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog",
                schema: "certificate",
                table: "blog",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "certificate",
                table: "blog",
                column: "user_id",
                principalSchema: "user",
                principalTable: "blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "pet_project",
                table: "blog",
                column: "user_id",
                principalSchema: "user",
                principalTable: "blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "post",
                table: "blog",
                column: "user_id",
                principalSchema: "user",
                principalTable: "blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "token",
                table: "blog",
                column: "user_id",
                principalSchema: "user",
                principalTable: "blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileCvs_blog_user_id",
                table: "FileCvs",
                column: "user_id",
                principalSchema: "user",
                principalTable: "blog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "certificate",
                table: "blog");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "pet_project",
                table: "blog");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "post",
                table: "blog");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_blog_user_id",
                schema: "token",
                table: "blog");

            migrationBuilder.DropForeignKey(
                name: "FK_FileCvs_blog_user_id",
                table: "FileCvs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog",
                schema: "user",
                table: "blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog",
                schema: "token",
                table: "blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog",
                schema: "post",
                table: "blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog",
                schema: "pet_project",
                table: "blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog",
                schema: "certificate",
                table: "blog");

            migrationBuilder.DropColumn(
                name: "is_expired",
                schema: "token",
                table: "blog");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "token",
                newName: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "pet_project",
                newName: "PetProjects");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "certificate",
                newName: "Certificates");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id3",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id2",
                table: "Posts",
                newName: "IX_Posts_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id1",
                table: "PetProjects",
                newName: "IX_PetProjects_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id",
                table: "Certificates",
                newName: "IX_Certificates_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetProjects",
                table: "PetProjects",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Users_user_id",
                table: "Certificates",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileCvs_Users_user_id",
                table: "FileCvs",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetProjects_Users_user_id",
                table: "PetProjects",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_user_id",
                table: "Posts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_user_id",
                table: "RefreshTokens",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
