using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Характеристики игрока")]
    public float speed;

    [SerializeField] public SpriteRenderer spriteRenderer;

    public Vector2 LastDirection = Vector2.right;

    [Header("Параметры камеры")]
    public Camera CameraObject;

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        if (direction != Vector2.zero)
        {
            LastDirection = direction;
        }
            

        if (x != 0)
        {
            if (x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

        }
        /*
        if(x == -1)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }*/


        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        
    }
    
    public void CameraMovement()
    {
        Vector3 x_y_position = transform.position;
        x_y_position.z = -10f;
        CameraObject.transform.position = x_y_position;
    }

    void Update()
    {
        Movement();
        CameraMovement();
    }
}
