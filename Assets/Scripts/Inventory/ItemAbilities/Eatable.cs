using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Abilities/Eatable")]
public class Eatable : ItemAbility
{
    public float heal;

    //public ItemData item;

    //public GameObject user; //по факту только игрок

    public override void Use(GameObject user, InventorySlot slot) //доделать
    {
        var hp = user.GetComponent<HealthComponent>();
        if (hp.health < hp.maxHealth)
        {
            hp.Healing(heal);
            slot.count--;
            Debug.Log($"Предмет потратился");

        }
    }


    //private void OnEnable()
    //{
    //    item.OnUse += Eat;
    //    Debug.Log($"Предмет родился");
    //}

    //private void OnDisable()
    //{
    //    item.OnUse -= Eat;
    //    Debug.Log($"Предмет умер");
    //}
}
