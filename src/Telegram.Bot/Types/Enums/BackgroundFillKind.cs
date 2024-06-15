﻿namespace Telegram.Bot.Types.Enums;

/// <summary>
/// Represents different types of background fills.
/// </summary>
[JsonConverter(typeof(BackgroundFillKindConverter))]
public enum BackgroundFillKind
{
    /// <summary>
    /// A solid fill background.
    /// </summary>
    Solid = 1,

    /// <summary>
    /// A gradient fill background.
    /// </summary>
    Gradient,

    /// <summary>
    /// A freeform gradient fill background.
    /// </summary>
    FreeformGradient,
}