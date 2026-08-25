using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Характеристики игрока")]
    public float speed;

    [Header("Параметры камеры")]
    public Camera camera;
    //public float z_position;

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2 (x, y).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        
    }

    public void CameraMovement()
    {
        Vector3 x_y_position = transform.position;
        //Debug.Log(x_y_position);
        x_y_position.z = -10f;
        camera.transform.position = x_y_position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraMovement();
    }
}
