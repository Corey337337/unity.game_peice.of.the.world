using UnityEngine;

public class ItemUserComponent : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] InventoryUI inventoryUI;

    public void UseItem()
    {
        if (inventoryUI.SelectedIndex == -1)
        {
            return;
        }
        var slot = inventoryUI.SelectedSlot;
        slot.item.Use();
        slot.count -= 1; //<-- это слишком общее, надо поменять и уменьшение
                 //количествва сделать только от скриптов самих предметов


        inventory.RemoveItem();
    }

}
