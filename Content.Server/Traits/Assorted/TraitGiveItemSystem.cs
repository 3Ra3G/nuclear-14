using Content.Shared.Hands.EntitySystems;
using Content.Shared.Hands.Components;

namespace Content.Server.Traits.Assorted;

public sealed class TraitGiveItemSystem : EntitySystem
{
    [Dependency] private readonly SharedHandsSystem _hands = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<TraitGiveItemComponent, MapInitEvent>(OnMapInit);
    }

    private void OnMapInit(EntityUid uid, TraitGiveItemComponent component, ref MapInitEvent args)
    {
        var coords = Transform(uid).Coordinates;
        var item = EntityManager.SpawnEntity(component.Item, coords);

        if (component.EquipInHands)
            _hands.TryPickupAnyHand(uid, item, false);
    }
}

