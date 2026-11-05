[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int count;
    public bool IsEmpty
    {
        get { return item == null; }
    }
}
