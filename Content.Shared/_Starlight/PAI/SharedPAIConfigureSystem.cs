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

