using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public GameObject AttackZone;

    public float zoneDistance;

    private PlayerMovement pm;


    public void Awake()
    {
        pm = GetComponent<PlayerMovement>();
    }

    public void Attack()
    {
        Vector2 dir = pm.LastDirection;

        AttackZone.transform.localPosition = dir * zoneDistance;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        AttackZone.transform.localRotation = Quaternion.Euler(0, 0, angle);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        
    }
}
