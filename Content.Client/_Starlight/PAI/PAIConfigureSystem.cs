using Content.Shared._Starlight.PAI;
using Content.Shared.PAI;
using Robust.Client.GameObjects;

namespace Content.Client._Starlight.PAI;

public sealed class PAIConfigureSystem : SharedPAIConfigureSystem
{
    [Dependency] private readonly SpriteSystem _sprite = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<PAIComponent, ComponentStartup>(OnComponentStartup);
        SubscribeLocalEvent<PAIComponent, AfterAutoHandleStateEvent>(OnAfterAutoState);
        SubscribeLocalEvent<PAIComponent, PAIColorChangedEvent>(OnColorChangedEvent);
    }

    private void OnAfterAutoState(Entity<PAIComponent> ent, ref AfterAutoHandleStateEvent args) =>
        RefreshScreenColor(ent);

    private void OnComponentStartup(EntityUid uid, PAIComponent paiComponent, ComponentStartup args) =>
        RefreshScreenColor((uid, paiComponent));

    private void OnColorChangedEvent(Entity<PAIComponent> ent, ref PAIColorChangedEvent args) =>
        RefreshScreenColor(ent);

    private void RefreshScreenColor(Entity<PAIComponent> ent)
    {
        if (!TryComp<SpriteComponent>(ent, out var sprite)) return;

        //_sprite.SetColor(ent.Owner, ent.Comp.PAIColor);
        if (_sprite.LayerMapTryGet((ent, sprite), "screen", out var layer, false))
        {
            _sprite.LayerSetColor((ent, sprite), layer, ent.Comp.PAIColor);
        }
    }
}
