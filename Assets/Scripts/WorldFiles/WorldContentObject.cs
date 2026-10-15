using UnityEngine;
using UnityEngine.UI;

public class WorldContentObject : MonoBehaviour
{

    //public string worldName;

    public Text worldName;

    public Vector2 seed;

    public WorldContentObject(Text wn, Vector2 s)
    {
        worldName = wn;
        seed = s;
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
