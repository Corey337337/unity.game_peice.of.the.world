using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] SlotUI slotPrefab;
    [SerializeField] Transform container;

    SlotUI[] slotUIs;

    public int SelectedIndex { get; private set; } = -1;
    public InventorySlot SelectedSlot =>
        SelectedIndex >= 0 ? inventory.slots[SelectedIndex] : null;

    public event Action<int> OnSelectionChanged;

    void Start()
    {
        slotUIs = new SlotUI[inventory.slots.Length];
        for (int i = 0; i < slotUIs.Length; i++)
        {
            int index = i;
            slotUIs[i] = Instantiate(slotPrefab, container);
            slotUIs[i].Clicked += _ => Select(index);
        }
        inventory.OnChanged += Refresh;
        Refresh();
    }

    void OnDestroy()
    {
        if (inventory != null)
            inventory.OnChanged -= Refresh;
    }

    void Select(int index)
    {
        if (inventory.slots[index].IsEmpty || index == SelectedIndex)
            SetSelected(-1);
        else
            SetSelected(index);
    }

    void SetSelected(int index)
    {
        if (SelectedIndex == index) return;
        SelectedIndex = index;
        UpdateHighlights();
        OnSelectionChanged?.Invoke(SelectedIndex);
    }

    void Refresh()
    {
        for (int i = 0; i < slotUIs.Length; i++)
            slotUIs[i].Set(inventory.slots[i]);

        if (SelectedIndex >= 0 && inventory.slots[SelectedIndex].IsEmpty)
            SetSelected(-1);
        else
            UpdateHighlights();
    }

    void UpdateHighlights()
    {
        for (int i = 0; i < slotUIs.Length; i++)
            slotUIs[i].SetSelected(i == SelectedIndex);
    }
}
