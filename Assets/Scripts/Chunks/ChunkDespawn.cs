using UnityEngine;
using System.Collections;

public class ChunkDespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        var wait = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return wait;
            if (!World.Instance.HasChanckAt(transform.position))
            {
                Destroy(gameObject);
            }
        }

    }
}
