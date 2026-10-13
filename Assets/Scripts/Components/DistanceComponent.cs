using UnityEngine;

public class DistanceComponent : MonoBehaviour
{

    public bool CheckDistance(float dist, GameObject target)
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance <= dist)
        {
            return true;
        }
        return false;
    }

   
}
