using UnityEngine;

public class AttackAimComponent : MonoBehaviour
{

    public GameObject AttackZone;

    public float zoneDistance;

    public Vector2 originOffset;

    private MoverComponent mover;

    public void Awake()
    {
        mover = GetComponent<MoverComponent>();
    }

    public void AimZoneWork()
    {
        Vector2 dir = mover.LastDirection;

        AttackZone.transform.localPosition = originOffset + dir * zoneDistance;

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
        
    }
}
