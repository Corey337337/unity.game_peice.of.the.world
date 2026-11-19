using UnityEngine;

public class MoverComponent : MonoBehaviour
{

    public float speed;

    public SpriteRenderer spriteRenderer;

    public Vector2 LastDirection = Vector2.right;

    public Vector2 direction;


    public Animator animator;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        if (direction != Vector2.zero)
        {
            LastDirection = direction;
            //if (animator != null)
            //{
            //    animator.SetTrigger("isMoving");
            //}
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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
