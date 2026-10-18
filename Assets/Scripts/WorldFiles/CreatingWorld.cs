using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreatingWorld : MonoBehaviour
{
    public InputField inputField;
    public ScrollRect scrollRect;
    public WorldCard worldCardPrefab;


    [Header("Подтверждение удаления")]
    public GameObject confirmPanel;
    public Text confirmText;
    public Button deleteButton;
    public Button cancelButton;


    private WorldList list;

    private WorldCard cardToDelete;

    void Awake()
    {
        deleteButton.onClick.AddListener(ConfirmDelete);
        cancelButton.onClick.AddListener(CancelDelete);
    }

    public void CreateWorld()
    {
        WorldInfo info = new WorldInfo
        {
            id = Guid.NewGuid().ToString(),
            name = inputField.text,
            seed = new Vector2(Random.Range(0, 10000), Random.Range(0, 10000))
        };

        list.worlds.Add(info);
        WorldStorage.SaveList(list);
        SpawnCard(info);

    }

    public void SpawnCard(WorldInfo info)
    {
        WorldCard card = Instantiate(worldCardPrefab, scrollRect.content);
        card.Setup(info, DeleteWorld);
        card.transform.SetAsFirstSibling();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        list = WorldStorage.LoadList();
        foreach (WorldInfo info in list.worlds)
        {
            SpawnCard(info);
        }
    }

    public void DeleteWorld(WorldCard card)
    {
        cardToDelete = card;
        confirmText.text = "Вы уверены, что хотите удалить мир \"" + card.info.name + "\"?";
        confirmPanel.SetActive(true);
    }

    public void ConfirmDelete()
    {
        if (cardToDelete != null)
        {
            list.worlds.Remove(cardToDelete.info);
            WorldStorage.SaveList(list);
            WorldStorage.DeleteWorldData(cardToDelete.info.id);
            Destroy(cardToDelete.gameObject);
            cardToDelete = null;
        }
        confirmPanel.SetActive(false);
    }

    public void CancelDelete()
    {
        cardToDelete = null;
        confirmPanel.SetActive(false);
    }

}
