using UnityEngine;

public class SurfaceComponent : MonoBehaviour
{
    public float forceSpeed;

    public GameObject player;

    public void ApplyForceSpeed()
    {
        player.GetComponent<PlayerMovement>().speed = forceSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            ApplyForceSpeed();
        }
    }

}
