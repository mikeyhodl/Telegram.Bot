using Telegram.Bot.Types.Enums;
using Xunit;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class InputMediaTypeConverterTests
{
    [Theory]
    [InlineData(InputMediaType.Photo, "photo")]
    [InlineData(InputMediaType.Video, "video")]
    [InlineData(InputMediaType.Animation, "animation")]
    [InlineData(InputMediaType.Audio, "audio")]
    [InlineData(InputMediaType.Document, "document")]
    public void Should_Convert_InputMediaType_To_String(InputMediaType inputMediaType, string value)
    {
        InputMedia inputMedia = new() { Type = inputMediaType };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = JsonSerializer.Serialize(inputMedia, JsonBotAPI.Options);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(InputMediaType.Photo, "photo")]
    [InlineData(InputMediaType.Video, "video")]
    [InlineData(InputMediaType.Animation, "animation")]
    [InlineData(InputMediaType.Audio, "audio")]
    [InlineData(InputMediaType.Document, "document")]
    public void Should_Convert_String_To_InputMediaType(InputMediaType inputMediaType, string value)
    {
        InputMedia expectedResult = new() { Type = inputMediaType };
        string jsonData = @$"{{""type"":""{value}""}}";

        InputMedia? result = JsonSerializer.Deserialize<InputMedia>(jsonData, JsonBotAPI.Options);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_InputMediaType()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        InputMedia? result = JsonSerializer.Deserialize<InputMedia>(jsonData, JsonBotAPI.Options);

        Assert.NotNull(result);
        Assert.Equal((InputMediaType)0, result.Type);
    }

    [Fact]
    public void Should_Throw_JsonException_For_Incorrect_InputMediaType()
    {
        InputMedia inputMedia = new() { Type = (InputMediaType)int.MaxValue };

        // ToDo: add InputMediaType.Unknown ?
        //    protected override string GetStringValue(InputMediaType value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(inputMedia, JsonBotAPI.Options));
    }


    class InputMedia
    {
        [JsonRequired]
        public InputMediaType Type { get; init; }
    }
}
