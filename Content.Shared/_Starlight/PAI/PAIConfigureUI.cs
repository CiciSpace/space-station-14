using Content.Shared._Starlight.TextToSpeech;
using Robust.Shared.Serialization;

namespace Content.Shared._Starlight.PAI;

[Serializable, NetSerializable]
public enum PAIConfigureUiKey : byte
{
    Key,
}

[Serializable, NetSerializable]
public sealed class PAIRenameBuiMessage(string name) : BoundUserInterfaceMessage
{
    public string Name = name;
}
[Serializable, NetSerializable]
public sealed class PAISelectVoiceBuiMessage(string voiceId) : BoundUserInterfaceMessage
{
    public string VoiceId = voiceId;
}

[Serializable, NetSerializable]
public sealed class PAISelectColorBuiMessage(Color color) : BoundUserInterfaceMessage
{
    public Color Color = color;
}
