using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public InventorySlot[] slots;
    public int size;
    public event Action OnChanged;


    void Awake()
    {
        Debug.Log("Inventory Awake, size = " + size, this);
        slots = new InventorySlot[size];
        for(int i = 0; i < size; i++)
        {
            slots[i] = new InventorySlot();
        }
    }

    public bool Add(ItemData item, int amount = 1)
    {
        if (item.stackable)
        {
            foreach (var s in slots)
            {
                if (s.item == item && s.count < item.maxStack)
                {
                    int add = Math.Min(amount, item.maxStack - s.count);

                    s.count += add;
                    amount -= add;

                    if (amount == 0)
                    {
                        OnChanged?.Invoke();
                        return true;
                    }
                }
            }
        }

        foreach (var s in slots)
        {
            if (s.IsEmpty)
            {
                s.item = item;
                s.count = Math.Min(amount, item.maxStack);
                amount -= s.count;

                if(amount == 0)
                {
                    OnChanged?.Invoke();
                    return true;
                }
            }
        }

        OnChanged?.Invoke();
        return true;

    }


}
