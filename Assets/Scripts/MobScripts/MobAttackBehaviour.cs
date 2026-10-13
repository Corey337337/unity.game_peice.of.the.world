using UnityEngine;

public class MobAttackBehaviour : MonoBehaviour
{

    public float waitSeconds; //задержка перед атакой
    public float distanceToBit;

    private AttackComponent attacker;
    private AttackAimComponent aim;
    private DistanceComponent dist;


    private GameObject player;

    //логика перемещения зоны^ вып
    //попытка атаки^ вып
    //задержка


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aim = GetComponent<AttackAimComponent>();
        attacker = GetComponent<AttackComponent>();
        dist = GetComponent<DistanceComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dist.CheckDistance(distanceToBit, player))
        {
            attacker.TryAttack();
        }
        aim.AimZoneWork();
    }
}
