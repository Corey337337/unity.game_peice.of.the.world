using UnityEngine;

public class SurfaceComponent : MonoBehaviour
{
    public float forceSpeed;

    public GameObject player;

    public void ApplyForceSpeed()
    {
        player.GetComponent<MoverComponent>().speed = forceSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            ApplyForceSpeed();
        }
    }

}
