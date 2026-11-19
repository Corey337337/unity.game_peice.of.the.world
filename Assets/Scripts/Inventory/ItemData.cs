using System;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool stackable = true;
    public int maxStack;
    [TextArea] public string description;


    //public event Action OnUse;
    public ItemAbility[] abilities;

    public void Use(GameObject user, InventorySlot slot)
    {
        Debug.Log($"Использовали предмет: {itemName}");
        foreach (var a in abilities)
            a.Use(user, slot);
    }

}