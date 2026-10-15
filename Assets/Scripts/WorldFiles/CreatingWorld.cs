using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreatingWorld : MonoBehaviour
{
    public InputField inputField;
    public ScrollRect scrollRect;

    public WorldContentObject worldCardPrefab;

    //private string userText;
    private Vector2 seed;


    public void CreateWorld()
    {

        string userText = inputField.text;
        seed = new Vector2(Random.Range(0, 10000), Random.Range(0, 10000));
        Debug.Log("сгенерировалось: " + seed);
        WorldContentObject worldCard = Instantiate(worldCardPrefab, scrollRect.content);
        worldCard.worldName.text = userText;
        worldCard.seed = seed;
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
