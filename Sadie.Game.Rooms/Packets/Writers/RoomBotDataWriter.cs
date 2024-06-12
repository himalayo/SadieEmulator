﻿using Sadie.API.Game.Rooms.Bots;
using Sadie.Networking.Serialization;
using Sadie.Networking.Serialization.Attributes;
using Sadie.Shared.Unsorted.Game.Avatar;
using Sadie.Shared.Unsorted.Networking;

namespace Sadie.Game.Rooms.Packets.Writers;

[PacketId(ServerPacketId.RoomUserData)]
public class RoomBotDataWriter : AbstractPacketWriter
{
    public required ICollection<IRoomBot> Bots { get; init; }

    public override void OnConfigureRules()
    {
        Override(GetType().GetProperty(nameof(Bots))!, writer =>
        {
            writer.WriteInteger(Bots.Count);

            foreach (var bot in Bots)
            {
                var botData = bot.Bot;
                
                writer.WriteInteger(bot.Id);
                writer.WriteString(botData.Username);
                writer.WriteString(botData.Motto);
                writer.WriteString(botData.FigureCode);
                writer.WriteInteger(botData.Id);
                writer.WriteInteger(bot.Point.X);
                writer.WriteInteger(bot.Point.Y);
                writer.WriteString(bot.PointZ + "");
                writer.WriteInteger((int) bot.Direction);
                writer.WriteInteger(3);
                writer.WriteString(botData.Gender == AvatarGender.Male ? "M" : "F");
                writer.WriteInteger(bot.Bot.PlayerId);
                writer.WriteString("");
                writer.WriteInteger(10);
                writer.WriteInteger(0);
                writer.WriteInteger(1);
                writer.WriteInteger(2);
                writer.WriteInteger(3);
                writer.WriteInteger(4);
                writer.WriteInteger(5);
                writer.WriteInteger(6);
                writer.WriteInteger(7);
                writer.WriteInteger(8);
                writer.WriteInteger(9);
            }
        });
    }
}