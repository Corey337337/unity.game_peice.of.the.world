using UnityEngine;

public class Generation : MonoBehaviour  //экспериментальный скрипт генерации блоков
{
   

    // пока что один префаб который назначается в инспекторе
    // потом будет рандомная генерация из списка (шансы и прочее прошипу позже)
    public Block blockPrefab; 

    public void GeneratePlace()
    {
       for (int i = 0; i < 5; i++)
       {
            for (int j = 0; j < 5; j++)
            {
                Instantiate(blockPrefab, new Vector3(i, j, 0), Quaternion.identity);
            }
       }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GeneratePlace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
