using Content.Shared.Actions;

// ReSharper disable CheckNamespace
namespace Content.Shared.PAI;

public sealed partial class PAIComponent : Component
{
    [DataField("PAIColor")]
    [AutoNetworkedField]
    public Color PAIColor = Color.LimeGreen;
}

[ByRefEvent]
public record struct PAIColorChangedEvent(Color color)
{
    public Color Color = color;
}
public sealed partial class PAIPDAActionEvent : InstantActionEvent
{
}

public sealed partial class PAIConsoleActionEvent : InstantActionEvent
{
}
