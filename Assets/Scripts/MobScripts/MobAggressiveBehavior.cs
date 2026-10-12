using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MobAggressiveBehavior : MonoBehaviour
{
    public float аggressDistance;
    public float stopDistance;

    private MoverComponent mover;
    private MobsWalkBehaviour walkBehaviour;

    //private AttackComponent attacker;

    private bool isChasing = false;

    private GameObject player;

    public bool CheckDistance()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= аggressDistance)
        {
            return true;
        }
        return false;
    }

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mover = GetComponent<MoverComponent>();
        walkBehaviour = GetComponent<MobsWalkBehaviour>();
        //attacker = GetComponent<AttackComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckDistance())
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
