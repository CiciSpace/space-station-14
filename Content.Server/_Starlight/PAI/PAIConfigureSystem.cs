using Content.Server.Administration.Logs;
using Content.Shared._Starlight.PAI;
using Content.Shared.CCVar;
using Content.Shared.Database;
using Content.Shared.PAI;
using Robust.Shared.Configuration;

namespace Content.Server._Starlight.PAI;

public sealed partial class PAIConfigureSystem : EntitySystem
{
    [Dependency] private MetaDataSystem _metaData = default!;
    [Dependency] private IAdminLogManager _adminLog = default!;
    [Dependency] private IConfigurationManager _cfgManager = default!;

    private int _maxNameLength;
    public override void Initialize()
    {
        base.Initialize();
        Subs.BuiEvents<PAIComponent>(PAIConfigureUiKey.Key, subs =>
        {
            subs.Event<BoundUIOpenedEvent>(OnConfigureUIOpened);
            subs.Event<PAIRenameBuiMessage>(OnSetNameBuiMessage);
        });

        Subs.CVar(_cfgManager, CCVars.MaxNameLength, value => _maxNameLength = value, true);
    }

    private void OnConfigureUIOpened(EntityUid uid, PAIComponent component, BoundUIOpenedEvent args)
    {
    }

    private void OnSetNameBuiMessage(Entity<PAIComponent> ent, ref PAIRenameBuiMessage args)
    {
        if (args.Name.Length > _maxNameLength ||
            args.Name.Length == 0 ||
            string.IsNullOrWhiteSpace(args.Name) ||
            string.IsNullOrEmpty(args.Name))
            return;

        var name = args.Name.Trim();

        var metaData = MetaData(ent);

        if (metaData.EntityName.Equals(name, StringComparison.InvariantCulture))
            return;

        _adminLog.Add(LogType.Action, LogImpact.High, $"{ToPrettyString(args.Actor):player} set their pAI name to: {name}");
        _metaData.SetEntityName(ent, name, metaData, false);
    }
}
