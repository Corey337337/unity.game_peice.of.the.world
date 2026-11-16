using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text countText;
    [SerializeField] GameObject highlight;

    public event Action<SlotUI> Clicked;

    public void Set(InventorySlot slot)
    {
        if (slot.IsEmpty)
        {
            icon.enabled = false;
            countText.text = "";
            return;
        }

        icon.enabled = true;
        icon.sprite = slot.item.icon;
        countText.text = slot.count > 1 ? slot.count.ToString() : "";
    }

    public void SetSelected(bool selected)
    {
        if (highlight != null) highlight.SetActive(selected);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Клик по слоту");
        if (eventData.button == PointerEventData.InputButton.Left)
            Clicked?.Invoke(this);
    }
}
