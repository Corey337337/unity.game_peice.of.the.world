using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public void CameraMovement()
    {
        Vector3 pos = target.position;
        pos.z = -10f;
        transform.position = pos;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }
}
