using UnityEngine;
using UnityEngine.UI;

public class WorldCard : MonoBehaviour
{

    //public string worldName;

    public Text worldName;

    public WorldInfo info;

    public void Setup(WorldInfo worldInfo)
    {
        info = worldInfo;
        worldName.text = info.name;
    }

    public void SelectWorld() 
    {
        GameSession.CurrentWorld = info;
    }
}
