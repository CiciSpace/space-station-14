using Content.Shared._Starlight.PAI;
using Content.Shared.PAI;

namespace Content.Server._Starlight.PAI;

public sealed partial class PAIConfigureSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        Subs.BuiEvents<PAIComponent>(PAIConfigureUiKey.Key, subs =>
        {
            subs.Event<BoundUIOpenedEvent>(OnConfigureUIOpened);
        });
    }

    private void OnConfigureUIOpened(EntityUid uid, PAIComponent component, BoundUIOpenedEvent args)
    {
    }
}
