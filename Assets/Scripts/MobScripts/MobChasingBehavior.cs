using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MobChasingBehavior : MonoBehaviour
{
    public float аggressDistance;
    public float stopDistance;

    private MoverComponent mover;
    private MobsWalkBehaviour walkBehaviour;
    private DistanceComponent dist;

    private bool isChasing = false;

    private GameObject player;

    /*
    public bool CheckDistance()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= аggressDistance)
        {
            return true;
        }
        return false;
    }*/

    private void StartChase()
    {
        isChasing = true;
        walkBehaviour.StopAllCoroutines(); 
        walkBehaviour.enabled = false;
    }

    private void Chase()
    {
        Vector2 toPlayer = player.transform.position - transform.position;

        if (toPlayer.magnitude > stopDistance)
            mover.SetDirection(toPlayer);
        else
            mover.SetDirection(Vector2.zero);
    }

    private void StopChase()
    {
        isChasing = false;
        mover.SetDirection(Vector2.zero);
        walkBehaviour.enabled = true;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mover = GetComponent<MoverComponent>();
        walkBehaviour = GetComponent<MobsWalkBehaviour>();
        dist = GetComponent<DistanceComponent>();
        //attacker = GetComponent<AttackComponent>();
    }

    void Update()
    {
        if (dist.CheckDistance(аggressDistance, player))
        {
            if (!isChasing)
            {
                StartChase();
            }
            Chase();
        }
        else if (isChasing)
        {
            StopChase();
        }
    }
}
