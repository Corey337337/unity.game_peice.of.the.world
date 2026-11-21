using UnityEngine;

public class PortalProp : MonoBehaviour
{

    public bool toBeyondis = true;//я пока не продумал возвращение (а этот метод не особо рабочий)

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Portal portal = Portal.Instance;

            if (portal.isActive && Input.GetKeyDown(KeyCode.E))
            {
                if (toBeyondis)
                {
                    GetComponent<SceneChanger>().MoveToScene(2);
                }
                else
                {
                    GetComponent<SceneChanger>().MoveToScene(1);
                }
                
            }
            
            Debug.Log("Игрок вошел в зону");
        }
    }

    
}
