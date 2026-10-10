using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class MobsWalkBehaviour : MonoBehaviour
{
    public MoverComponent mover;

    public bool isWalking = false;

    //public LocationInfo loc;

    public void chooseWay()
    {
        int randomX = Random.Range(-1, 2);
        int randomY = Random.Range(-1, 2);
        Debug.Log($"x = {randomX}, y = {randomY}");
        Vector2 dir = new Vector2(randomX, randomY);
        mover.SetDirection(dir);
        
    }

    private float walkDuration;
    IEnumerator WalkingRoutine()
    {
        isWalking = true;
        chooseWay();
        walkDuration = Random.Range(4, 11);
        Debug.Log($"ходит - {walkDuration} сек");
        yield return new WaitForSeconds(walkDuration);
        mover.SetDirection(new Vector2(0,0));
        yield return new WaitForSeconds(1f);
        isWalking = false;
    }

    void OnEnable()
    {
        isWalking = false;
        StopAllCoroutines();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (!isWalking)
        {
            StartCoroutine(WalkingRoutine());
        }
    }
}
