namespace Content.Server.Traits.Assorted;

[RegisterComponent]
public sealed partial class TraitGiveItemComponent : Component
{
    [DataField(required: true)]
    public string Item = default!;

    [DataField]
    public bool EquipInHands = true;
}