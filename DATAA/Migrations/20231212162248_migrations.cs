using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATAA.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "chatRooms",
                columns: table => new
                {
                    RoomID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameRoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatRooms", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_chatRooms_UserProfile_Admin",
                        column: x => x.Admin,
                        principalTable: "UserProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chatRooms_UserProfile_UserID",
                        column: x => x.UserID,
                        principalTable: "UserProfile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    ChatUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDuser1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDuser2 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.ChatUserID);
                    table.ForeignKey(
                        name: "FK_ChatUsers_UserProfile_IDuser1",
                        column: x => x.IDuser1,
                        principalTable: "UserProfile",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ChatUsers_UserProfile_IDuser2",
                        column: x => x.IDuser2,
                        principalTable: "UserProfile",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "chatRoomUsers",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatRoomUsers", x => new { x.UserID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_chatRoomUsers_UserProfile_UserID",
                        column: x => x.UserID,
                        principalTable: "UserProfile",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_chatRoomUsers_UserProfile_UserID1",
                        column: x => x.UserID1,
                        principalTable: "UserProfile",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_chatRoomUsers_chatRooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "chatRooms",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    chatRoomID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    chatUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_ChatUsers_chatUserID",
                        column: x => x.chatUserID,
                        principalTable: "ChatUsers",
                        principalColumn: "ChatUserID");
                    table.ForeignKey(
                        name: "FK_Messages_UserProfile_SenderUserID",
                        column: x => x.SenderUserID,
                        principalTable: "UserProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_chatRooms_chatRoomID",
                        column: x => x.chatRoomID,
                        principalTable: "chatRooms",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chatRooms_Admin",
                table: "chatRooms",
                column: "Admin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chatRooms_UserID",
                table: "chatRooms",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_chatRoomUsers_RoomID",
                table: "chatRoomUsers",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_chatRoomUsers_UserID1",
                table: "chatRoomUsers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_IDuser1",
                table: "ChatUsers",
                column: "IDuser1");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_IDuser2",
                table: "ChatUsers",
                column: "IDuser2");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_chatRoomID",
                table: "Messages",
                column: "chatRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_chatUserID",
                table: "Messages",
                column: "chatUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUserID",
                table: "Messages",
                column: "SenderUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chatRoomUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropTable(
                name: "chatRooms");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
