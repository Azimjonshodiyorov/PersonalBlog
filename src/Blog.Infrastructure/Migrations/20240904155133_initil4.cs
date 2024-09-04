using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initil4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_FileCvs",
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

            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.RenameTable(
                name: "FileCvs",
                newName: "file_cv",
                newSchema: "blog");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "user",
                newName: "user",
                newSchema: "blog");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "token",
                newName: "refresh_token",
                newSchema: "blog");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "post",
                newName: "post",
                newSchema: "blog");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "pet_project",
                newName: "pet_project",
                newSchema: "blog");

            migrationBuilder.RenameTable(
                name: "blog",
                schema: "certificate",
                newName: "certificate",
                newSchema: "blog");

            migrationBuilder.RenameIndex(
                name: "IX_FileCvs_user_id",
                schema: "blog",
                table: "file_cv",
                newName: "IX_file_cv_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id3",
                schema: "blog",
                table: "refresh_token",
                newName: "IX_refresh_token_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id2",
                schema: "blog",
                table: "post",
                newName: "IX_post_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id1",
                schema: "blog",
                table: "pet_project",
                newName: "IX_pet_project_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_user_id",
                schema: "blog",
                table: "certificate",
                newName: "IX_certificate_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_file_cv",
                schema: "blog",
                table: "file_cv",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                schema: "blog",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refresh_token",
                schema: "blog",
                table: "refresh_token",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post",
                schema: "blog",
                table: "post",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pet_project",
                schema: "blog",
                table: "pet_project",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_certificate",
                schema: "blog",
                table: "certificate",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_certificate_user_user_id",
                schema: "blog",
                table: "certificate",
                column: "user_id",
                principalSchema: "blog",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_file_cv_user_user_id",
                schema: "blog",
                table: "file_cv",
                column: "user_id",
                principalSchema: "blog",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pet_project_user_user_id",
                schema: "blog",
                table: "pet_project",
                column: "user_id",
                principalSchema: "blog",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_user_user_id",
                schema: "blog",
                table: "post",
                column: "user_id",
                principalSchema: "blog",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_token_user_user_id",
                schema: "blog",
                table: "refresh_token",
                column: "user_id",
                principalSchema: "blog",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_certificate_user_user_id",
                schema: "blog",
                table: "certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_file_cv_user_user_id",
                schema: "blog",
                table: "file_cv");

            migrationBuilder.DropForeignKey(
                name: "FK_pet_project_user_user_id",
                schema: "blog",
                table: "pet_project");

            migrationBuilder.DropForeignKey(
                name: "FK_post_user_user_id",
                schema: "blog",
                table: "post");

            migrationBuilder.DropForeignKey(
                name: "FK_refresh_token_user_user_id",
                schema: "blog",
                table: "refresh_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                schema: "blog",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refresh_token",
                schema: "blog",
                table: "refresh_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post",
                schema: "blog",
                table: "post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pet_project",
                schema: "blog",
                table: "pet_project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_file_cv",
                schema: "blog",
                table: "file_cv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_certificate",
                schema: "blog",
                table: "certificate");

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
                name: "user",
                schema: "blog",
                newName: "blog",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "refresh_token",
                schema: "blog",
                newName: "blog",
                newSchema: "token");

            migrationBuilder.RenameTable(
                name: "post",
                schema: "blog",
                newName: "blog",
                newSchema: "post");

            migrationBuilder.RenameTable(
                name: "pet_project",
                schema: "blog",
                newName: "blog",
                newSchema: "pet_project");

            migrationBuilder.RenameTable(
                name: "file_cv",
                schema: "blog",
                newName: "FileCvs");

            migrationBuilder.RenameTable(
                name: "certificate",
                schema: "blog",
                newName: "blog",
                newSchema: "certificate");

            migrationBuilder.RenameIndex(
                name: "IX_refresh_token_user_id",
                schema: "token",
                table: "blog",
                newName: "IX_blog_user_id3");

            migrationBuilder.RenameIndex(
                name: "IX_post_user_id",
                schema: "post",
                table: "blog",
                newName: "IX_blog_user_id2");

            migrationBuilder.RenameIndex(
                name: "IX_pet_project_user_id",
                schema: "pet_project",
                table: "blog",
                newName: "IX_blog_user_id1");

            migrationBuilder.RenameIndex(
                name: "IX_file_cv_user_id",
                table: "FileCvs",
                newName: "IX_FileCvs_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_certificate_user_id",
                schema: "certificate",
                table: "blog",
                newName: "IX_blog_user_id");

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
                name: "PK_FileCvs",
                table: "FileCvs",
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
    }
}
