using System;
using UnityEngine;
using UnityEngine.UI;

public class WorldCard : MonoBehaviour
{

    //public string worldName;

    public Text worldName;
    public Button deleteButton;
    public WorldInfo info;

    Action<WorldCard> onDelete;

    public void Setup(WorldInfo worldInfo, Action<WorldCard> deleteCallback)
    {
        info = worldInfo;
        worldName.text = info.name;

        onDelete = deleteCallback;
        deleteButton.onClick.AddListener(OnDeleteClicked);
    }

    public void OnDeleteClicked()
    {
        if (onDelete != null)
        {
            onDelete?.Invoke(this);
        }
    }

    public void SelectWorld() 
    {
        GameSession.CurrentWorld = info;
    }
}
