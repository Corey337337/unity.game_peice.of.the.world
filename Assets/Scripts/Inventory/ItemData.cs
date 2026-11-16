using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool stackable = true;
    public int maxStack;
    [TextArea] public string description;


    public event Action OnUse;

    public void Use()
    {
        Debug.Log($"Использовали предмет: {itemName}");
        OnUse?.Invoke(); //подписчики это срипты абилок самого предмета
    }

}