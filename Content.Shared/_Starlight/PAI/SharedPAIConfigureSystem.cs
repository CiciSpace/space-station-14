using Content.Shared.Toggleable;

namespace Content.Shared._Starlight.PAI;
using Content.Shared.PAI;


public abstract partial class SharedPAIConfigureSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        Subs.BuiEvents<PAIComponent>(PAIConfigureUiKey.Key, subs =>
        {
            subs.Event<PAISelectColorBuiMessage>(OnPAIColorChanged);
        });
    }

    private void OnPAIColorChanged(Entity<PAIComponent> ent, ref PAISelectColorBuiMessage args)
    {
        if (ent.Comp.PAIColor == args.Color) return;

        ent.Comp.PAIColor = args.Color;
        Dirty(ent, ent.Comp);

        var ev = new PAIColorChangedEvent(args.Color);
        RaiseLocalEvent(ent, ref ev);
    }
}
