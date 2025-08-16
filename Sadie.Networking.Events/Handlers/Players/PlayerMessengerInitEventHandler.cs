using Sadie.API.Networking.Client;
using Sadie.API.Networking.Events.Handlers;
using Sadie.Db.Models.Constants;
using Sadie.Networking.Writers.Players.Friendships;
using Sadie.Shared.Attributes;

namespace Sadie.Networking.Events.Handlers.Players;

[PacketId(EventHandlerId.PlayerMessengerInit)]
public class PlayerMessengerInitEventHandler(
    ServerPlayerConstants playerConstants)
    : INetworkPacketEventHandler
{
    public async Task HandleAsync(INetworkClient client)
    {
        await client.WriteToStreamAsync(new PlayerMessengerInitWriter
        {
            UserFriendLimit = playerConstants.MaxFriendships,
            NormalFriendLimit = playerConstants.MaxFriendships,
            ExtendedFriendLimit = playerConstants.MaxFriendships,
            FriendshipCategories = []
        });
    }
}