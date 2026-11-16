using UnityEngine;

public class Eatable : MonoBehaviour
{
    public float heal;

    public ItemData item;

    public GameObject user; //по факту только игрок

    public void Eat() //доделать
    {
        var hp = user.GetComponent<HealthComponent>();
        if (hp.health < hp.maxHealth)
        {
            user.GetComponent<HealthComponent>().Healing(heal);
            InventorySlot[] slots = user.GetComponent<Inventory>().slots;

            foreach (var s in slots)
            {
                if (s.item == item)
                {
                    s.count -= 1;
                }
                break;
            }
        }  
    }


    private void OnEnable()
    {
        item.OnUse += Eat;
    }

    private void OnDisable()
    {
        item.OnUse -= Eat;
    }
}
