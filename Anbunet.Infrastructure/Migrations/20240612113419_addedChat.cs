using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anbunet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_PrivateMessages_PrivateMessageId",
                table: "Message");

            migrationBuilder.DropTable(
                name: "PrivateMessages");

            migrationBuilder.RenameColumn(
                name: "PrivateMessageId",
                table: "Message",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_PrivateMessageId",
                table: "Message",
                newName: "IX_Message_ChatId");

            migrationBuilder.AddColumn<long>(
                name: "MessageId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUser",
                columns: table => new
                {
                    ChatsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUser", x => new { x.ChatsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ChatUser_Chats_ChatsId",
                        column: x => x.ChatsId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MessageId",
                table: "Users",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chats_ChatId",
                table: "Message",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Message_MessageId",
                table: "Users",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chats_ChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Message_MessageId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ChatUser");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Users_MessageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Message",
                newName: "PrivateMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatId",
                table: "Message",
                newName: "IX_Message_PrivateMessageId");

            migrationBuilder.CreateTable(
                name: "PrivateMessages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessages", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Message_PrivateMessages_PrivateMessageId",
                table: "Message",
                column: "PrivateMessageId",
                principalTable: "PrivateMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
