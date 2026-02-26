using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkDocsClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FolderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 260, nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CurrentVersionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DocumentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VersionNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    UploadByUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SizeBytes = table.Column<long>(type: "INTEGER", nullable: false),
                    Sha256 = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    BlobPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ChangeNote = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnerUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentFolderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResourceType = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GrantedToUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    GrantedByUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    RootFolderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FolderId",
                table: "Documents",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FolderId_Name",
                table: "Documents",
                columns: new[] { "FolderId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerUserId",
                table: "Documents",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentVersions_DocumentId",
                table: "DocumentVersions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentVersions_DocumentId_VersionNumber",
                table: "DocumentVersions",
                columns: new[] { "DocumentId", "VersionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerUserId",
                table: "Folders",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerUserId_ParentFolderId_Name",
                table: "Folders",
                columns: new[] { "OwnerUserId", "ParentFolderId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGrants_ResourceType_ResourceId_GrantedToUserId",
                table: "PermissionGrants",
                columns: new[] { "ResourceType", "ResourceId", "GrantedToUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentVersions");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "PermissionGrants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
