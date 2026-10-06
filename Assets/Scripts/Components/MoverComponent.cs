using UnityEngine;

public class MoverComponent : MonoBehaviour
{

    public float speed;

    public SpriteRenderer spriteRenderer;

    public Vector2 LastDirection = Vector2.right;

    public Vector2 direction;


    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        if (direction != Vector2.zero)
        {
            LastDirection = direction;
        }

        if (dir.x != 0)
        {
            if (dir.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
