using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Abilities/PortalActivation")]
public class PortalActivation : ItemAbility
{
    public override void Use(GameObject user, InventorySlot slot)
    {
        Portal portal = Portal.Instance;

        if (portal == null || portal.isActive) return;

        if (slot.count >= portal.stones)
        {
            slot.count -= portal.stones;
            portal.Activate();
            Debug.Log("Все порталы активированы!");
        }
    }
}
