using Robust.Client.UserInterface;

namespace Content.Client._Starlight.PAI;

public sealed class PAIConfigureBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private PAIConfigureWindow? _window;

    public PAIConfigureBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();

        _window = this.CreateWindow<PAIConfigureWindow>();
        _window.Open();
    }
}
