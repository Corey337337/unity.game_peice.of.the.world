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
        //Debug.Log("Вошёл: " + other.gameObject.name);
        //Debug.Log("Ожидаемый player: " + (player != null ? player.name : "NULL"));
        if (other.gameObject == player)
        {
            ApplyForceSpeed();
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Столкнулись с: " + collision.gameObject.name);
        if (collision.gameObject == player)
        {
            ApplyForceSpeed();
            Debug.Log("Коснулись: " + collision.gameObject.name);
        }
        
    }*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
