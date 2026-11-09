using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;
    public int count = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inv = other.GetComponent<Inventory>();
        if (inv != null && inv.Add(data, count))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = data.icon;
    }
}
