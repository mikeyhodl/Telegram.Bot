// GENERATED FILE - DO NOT MODIFY MANUALLY
namespace Telegram.Bot.Types;

/// <summary>Represents a location to which a chat is connected.</summary>
public partial class ChatLocation
{
    /// <summary>The location to which the supergroup is connected. Can't be a live location.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public Location Location { get; set; } = default!;

    /// <summary>Location address; 1-64 characters, as defined by the chat owner</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Address { get; set; } = default!;
}
