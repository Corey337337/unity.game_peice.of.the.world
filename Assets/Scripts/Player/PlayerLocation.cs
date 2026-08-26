using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class PlayerLocation : MonoBehaviour
{
    public void PlayerSpawn()
    {
        transform.position = new Vector3(7, 7, 0);
    }
}
