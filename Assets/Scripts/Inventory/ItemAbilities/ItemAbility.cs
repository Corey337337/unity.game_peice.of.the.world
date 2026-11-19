using UnityEngine;

public abstract class ItemAbility : ScriptableObject
{
    public abstract void Use(GameObject user, InventorySlot slot);
}