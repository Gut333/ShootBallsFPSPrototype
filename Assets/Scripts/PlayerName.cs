using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public string playerName;
    public string saveName;

    public Text inputText;
    public Text loadedName;

    private void Update()
    {
        playerName = PlayerPrefs.GetString("name", "none");
        loadedName.text = playerName;
    }

    public void SetName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
    }

}
